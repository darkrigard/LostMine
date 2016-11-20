using UnityEngine;
using System.Collections;

public class MainEvent : MonoBehaviour {

	public GameObject[] SetEvent;
	private float timer;
	public float limitTime;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (timer);
	}


	void OnTriggerStay(Collider col){
		if (col.tag == "collidebox") {
			timer += Time.deltaTime;

		}

		if (timer>=limitTime){
			Destroy (col.gameObject);
			Destroy (SetEvent[0]);
		}
	}

//	void OnTriggerStay(Collider col){
//		if (col.tag == "collidebox") { 
//			if (col.gameObject.name == "0.Collider") {
//				myDestroyObject (0, col);
//			} else if (col.gameObject.name == "1.Collider") {
//				myDestroyObject (1, col);
//			}	else if (col.gameObject.name == "2.Collider") {
//				myDestroyObject (3, col);
//			}	else if (col.gameObject.name == "dropColl1") {
//				myDestroyObject (4, col);
//			}	else if (col.gameObject.name == "dropColl2") {
//				myDestroyObject (5, col);
//			}	else if (col.gameObject.name == "dropColl3") {
//				myDestroyObject (6, col);
//			}	else if (col.gameObject.name == "dropColl4") {
//				myDestroyObject (7, col);
//			}
//
//
//		} 
//
//
//	}
//

	void OnGUI(){



	}

}
