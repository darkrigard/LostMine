using UnityEngine;
using System.Collections;

public class TutoEvent : MonoBehaviour {

	public GameObject[] SetEvent;
	private float timer;
	public float limitTime;

	public string Playerline;
	private float lineTimer;

	public GameObject mgr;

	bool check2Button;
	float checktime;

	InputProcess data;
	// Use this for initialization
	void Start () {
		data = mgr.GetComponent<InputProcess> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerLinefunc ();
		//Debug.Log (check2Button);

		if (check2Button == true) {
			checktime += Time.deltaTime;
			if (checktime > 3.0f) {
				SetEvent [2].SetActive (false);
				check2Button = false;
			}
		}

	}
	void EventUpdatedTime(){
		timer += Time.deltaTime;
		//Debug.Log (timer);
	}
	void myDestroyObject(int i,Collider col){
		SetEvent [i].SetActive (true);
		if(timer >limitTime){
			timer = 0;
			Destroy(col.gameObject);
			SetEvent [i].SetActive (false);
			if (i == 1) {
				check2Button = true;
				SetEvent [2].SetActive (true);
			}
		}
		EventUpdatedTime();
	}

	void PlayerLinefunc(){
		lineTimer += Time.deltaTime;
//
//		if (lineTimer > 2.0)
//		Playerline = new string ("뭐지? 죽은건가? 방금 분명히 사고당했는데?");
//		if (lineTimer > 4.0)
//		Playerline = new string ("너의 무의식 안이다.");
//		if (lineTimer > 6.0)
//		Playerline = new string ("당신은 뭐야?");
//		if (lineTimer > 8.0)
//		Playerline = new string ("너의 영혼을 거둬갈 존재다. ");
//		if (lineTimer > 10.0)
//		Playerline = new string ("여기서 나가지 못하면 ");
//		if (lineTimer > 12.0)
//		Playerline = new string ("너의 영혼은 나의 것이다......");
//

	}

	void OnTriggerExit(Collider col){
		if (col.tag == "collidebox") {
			Destroy (col.gameObject);
			SetEvent [0].SetActive (false);
			SetEvent [1].SetActive (false);
			SetEvent [4].SetActive (false);
			SetEvent [5].SetActive (false);
			SetEvent [6].SetActive (false);
			SetEvent [7].SetActive (false);
		}

	}

	void OnTriggerStay(Collider col){
		if (col.tag == "collidebox") { 
			if (col.gameObject.name == "0.Collider") {
				myDestroyObject (0, col);
			} else if (col.gameObject.name == "1.Collider") {
				myDestroyObject (1, col);
			}	else if (col.gameObject.name == "2.Collider") {
				myDestroyObject (3, col);
			}	else if (col.gameObject.name == "dropColl1") {
					myDestroyObject (4, col);
			}	else if (col.gameObject.name == "dropColl2") {
					myDestroyObject (5, col);
			}	else if (col.gameObject.name == "dropColl3") {
				myDestroyObject (6, col);
			}	else if (col.gameObject.name == "dropColl4") {
				myDestroyObject (7, col);
			}

			//트리거 존 대화를 넣으십시오.
			//Debug.Log ("asd1");
		} 
		//if (col.gameObject.name == "1.WarpCollide") {
		//	DestroyObject(1,col);
			//트리거 존 대화를 넣으십시오.
		//	Debug.Log ("asd2");

		//}
		//else {
//			Debug.Log ("asd3");
//
//			for(int i = 0 ; i < 2; ++i){
//				SetEvent [i].SetActive (false);
//
//			}

		//}
//			else if (col.gameObject.name == "2.WarpCollide") {
//			DestroyObject(2,col);
//			Debug.Log ("asd2");
//
//		} 

		//다음에 쓰겠습니당.

			//else if (col.gameObject.name == "3") {
//			DestroyObject(2,col);
//		} else if (col.gameObject.name == "4") {
//			DestroyObject(3,col);
//		}
		
		//	else if (col.gameObject.name == "5") {
//			DestroyObject(4,col);
//		} else if (col.gameObject.name == "6") {
//			DestroyObject(5,col);
//		} else if (col.gameObject.name == "7") {
//			DestroyObject(6,col);
//		} else if (col.gameObject.name == "8") {
//			DestroyObject(7,col);
//		} else if (col.gameObject.name == "9") {
//			DestroyObject(8,col);
//		} else if (col.gameObject.name == "10") {
//			DestroyObject(9,col);
//		}
		

		
	}


	void OnGUI(){



	}
}
