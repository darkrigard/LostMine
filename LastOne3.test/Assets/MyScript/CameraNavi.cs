using UnityEngine;
using System.Collections;

public class CameraNavi : MonoBehaviour {
	public GameObject[] points;
	private int arr_lenth;
	private Vector3[] vector;
	private bool rotate;
	public float camspeed;
	private Quaternion r1, r2 = Quaternion.identity;
	public float startTime;
	private float nowTime;
	//private CharacterController obj;
	//private Rigidbody rig;
	public int nowNum;
	// Use this for initialization
	void Start () {
		//startTime = 3.0f;
		//camspeed = 0.04f;
		rotate = false;
		//obj = GetComponent<CharacterController> ();
		//rig = GetComponent<Rigidbody> ();
		nowNum = 0;
		arr_lenth = points.Length;
		vector = new Vector3[arr_lenth];
		for (int i = 0; i < arr_lenth; ++i) {
			vector [i] = points [i].transform.position;
		}
		//vector = points [0].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (nowTime < startTime) {
			nowTime += Time.deltaTime;
		} 
		else {
			if (nowNum == arr_lenth) {
				CameraAnimation tmp = GameObject.Find ("CameraAnimation").GetComponent<CameraAnimation> ();
				tmp.start = true;
				gameObject.SetActive (false);
			} else {
				if (rotate) {
					rotate = false;
					//Debug.Log ("1: " + transform.rotation);
					//transform.LookAt (vector [nowNum]);
					//transform.rotation = Quaternion.SlerpUnclamped(transform.rotation,r2,Time.deltaTime * 0.7f);
					//Debug.Log ("2: " + transform.rotation);
				} else {
					//transform.rotation = Quaternion.Slerp (transform.rotation, r2, Time.deltaTime * 3f);
					Vector3 relativePos = vector [nowNum] - transform.position;
					r2 = Quaternion.LookRotation (relativePos);
					transform.rotation = Quaternion.Slerp (transform.rotation, r2, Time.deltaTime * 3f);
					transform.position = Vector3.MoveTowards (transform.position, vector [nowNum], camspeed);
				}
			}
		}

		if (Input.GetKeyDown ("f")){	// 'f' 키 입력 시 카메라 애니메이션 스킵
			nowNum = arr_lenth;
		}
		//obj.Move(vector);
		//rig.AddForceAtPosition(Vector3.forward,vector);
	}

	void OnTriggerEnter(Collider col){
		Debug.Log ("hi");
		if (col.tag == "navipoint") {
			Debug.Log ("change");

			nowNum += 1;
			rotate = col.GetComponent<ifRotate> ().rotate;

			col.gameObject.SetActive (false);
		}
	}
	void OnCollisionEnter(Collision col){
		Debug.Log ("hello");
		if (col.collider.tag == "navipoint") {
			Debug.Log ("change");
			nowNum += 1;
			col.gameObject.SetActive (false);
		}
	}
}
