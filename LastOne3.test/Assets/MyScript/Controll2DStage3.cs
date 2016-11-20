using UnityEngine;
using System.Collections;

public class Controll2DStage3 : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float TurnSpeed;
	public bool boxIn=false;
	private int dir;
	private Vector3 moveDirection = Vector3.zero;
	private InputProcessStage3 data;
	private Animation anim;
	public GameObject respawn;

	void Start(){
		data = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<InputProcessStage3> ();
		anim = GetComponent<Animation> ();
		anim.Play ("Looking_around");
	}

	void Update() {
		//Debug.Log(Input.GetAxis("Horizontal") + " : : " + Input.GetAxis("Vertical"));
		CharacterController controller = GetComponent<CharacterController>(); // 캐릭터 콘트롤러 참조
		if (controller.isGrounded) { // 땅에 있으면
			//anim.Play("Looking_around");
			if (data.NowMode == 2) {
				if (boxIn == false) {
					if (Input.GetKeyDown ("a") || Input.GetKeyDown ("d") || Input.GetKeyDown ("w") || Input.GetKeyDown ("s")) {
						if (anim.IsPlaying ("walk") == false)
							anim.Play ("walk");
					}
				} else if (boxIn == true) {
					if (Input.GetKeyDown ("a") || Input.GetKeyDown ("d") || Input.GetKeyDown ("w") || Input.GetKeyDown ("s")) {
						if (anim.IsPlaying ("Going_asleep") == false)
							anim.Play ("Sneaking");
					}
				}

				if(Input.GetKeyUp ("a") || Input.GetKeyUp ("d")|| Input.GetKeyUp ("w")|| Input.GetKeyUp ("s")){
					anim.Play ("Looking_around");
				}
				moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")); // 전후좌우 조정
				moveDirection = transform.TransformDirection(moveDirection);// .. 축을 바꾼다. 월드 좌표로
				moveDirection *= speed;  // 움직임의 속도를 제어...
				// 회 전 
				{
					if (moveDirection != Vector3.zero) {
						Quaternion targetRot = Quaternion.LookRotation (moveDirection);
						Quaternion frameRot = Quaternion.RotateTowards (transform.rotation, targetRot, TurnSpeed * Time.deltaTime);
						transform.rotation = frameRot;
					}
				}
			} else if (data.NowMode == 1) {
				if (Input.GetKeyDown ("a")) {
					//transform.Rotate (new Vector3 (0, 180, 0));
					transform.rotation = Quaternion.LookRotation(new Vector3 (0, 0, 1));
					dir = -1;
					//moveDirection = new Vector3 (0, 0, 1);
				} else if (Input.GetKeyDown ("d")) {
					//transform.Rotate (new Vector3 (0, 180, 0));
					transform.rotation = Quaternion.LookRotation(new Vector3 (0, 0, -1));
					dir = 1;
					//moveDirection = new Vector3 (0, 0, -1);
				}
				if (Input.GetKeyDown ("a") || Input.GetKeyDown ("d")) {
					if (anim.IsPlaying ("walk") == false)
						anim.Play ("walk");
				} else if(Input.GetKeyUp ("a") || Input.GetKeyUp ("d")){
					anim.Play ("Looking_around");
				}
				moveDirection = new Vector3 (0, 0, dir * Input.GetAxis ("Horizontal"));
				moveDirection = transform.TransformDirection(moveDirection);// .. 축을 바꾼다. 월드 좌표로
				moveDirection *= speed;  // 움직임의 속도를 제어...
				// 전후좌우 조정
			}
			else if (data.NowMode == 3) {
				if (Input.GetKeyDown ("s")) {
					// transform.Rotate (new Vector3 (0, 180, 0));
					transform.rotation = Quaternion.LookRotation(new Vector3 (1, 0, 0));
					dir = 1;
					//moveDirection = new Vector3 (0, 0, 1);
				} else if (Input.GetKeyDown ("w")) {
					//transform.Rotate (new Vector3 (0, 180, 0));
					transform.rotation = Quaternion.LookRotation(new Vector3 (1, 0, 0));
					dir = -1;
					//moveDirection = new Vector3 (0, 0, -1);
				}
				if (Input.GetKeyDown ("s") || Input.GetKeyDown ("w")) {
					if (anim.IsPlaying ("walk") == false)
						anim.Play ("walk");
				} else if(Input.GetKeyUp ("s") || Input.GetKeyUp ("w")){
					anim.Play ("Looking_around");
				}
				moveDirection = new Vector3 (Input.GetAxis ("Vertical"), 0, 0); // 전후좌우 조정
				moveDirection = transform.TransformDirection(moveDirection);// .. 축을 바꾼다. 월드 좌표로
				moveDirection *= speed;  // 움직임의 속도를 제어...
				//transform.Rotate (new Vector3 (0, 180, 0));
			}

			if (Input.GetButton("Jump")){ // 점프 버튼 누르
				moveDirection.y = jumpSpeed;  // 해당 y값에 대입... 점프 한다.
				anim.Play("Jump_runing");
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;  // y값에 조절 중력 가속도라고 보면 된다.
		controller.Move(moveDirection * Time.deltaTime);  // 콘트롤러는 이 모든 데이터를 참조하여 움직인다.. 시간 개념으로..
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "organicBox") {
			if (data.NowMode == 2) {
				boxIn = true;
				//anim.Play ("Going_asleep");
				//StartCoroutine (Respawn (col.transform));
			}
		} 
		else if (col.tag == "organicBoxOut") { 
			boxIn = false;
		}
	}

	IEnumerator Respawn(Transform tr){
		yield return new WaitForSeconds (2.0f);
		//Application.LoadLevel ("GAMEOVER_UI");
		//tr.position = respawn.transform.position;
		Application.LoadLevel ("Stage3");
	}

}
