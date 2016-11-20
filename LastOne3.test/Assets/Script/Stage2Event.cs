using UnityEngine;
using System.Collections;

public class Stage2Event : MonoBehaviour {

	public GameObject[] SetEvent;
	private float[] timer;
	public float[] limitTime;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; ++i) {
			SetEvent[i].SetActive ( false);
		}
		timer = new float[5];


	}

	// Update is called once per frame
	void Update () {

			
	}
		


	void OnTriggerStay(Collider col){
		if (col.gameObject.name == "Sector1") {
			SetEvent [0].SetActive (true);
			timer[0] += Time.deltaTime;
			if (timer[0]>=limitTime[0]){
				timer[0] = 0;
				Debug.Log ("1");
				Destroy (col.gameObject);
				//Destroy (SetEvent[0]);
			}
		}
		else if (col.gameObject.name == "Sector2") {
			SetEvent [1].SetActive (true);
			timer[1] += Time.deltaTime;
			if (timer[1]>=limitTime[1]){
				timer[1] = 0;
				Debug.Log ("2");
				Destroy (col.gameObject);
				//Destroy (SetEvent[1]);
			}
		}
		else if (col.gameObject.name == "Sector3") {
			SetEvent [2].SetActive (true);
			timer[2] += Time.deltaTime;
			if (timer[2]>=limitTime[2]){
				timer[2] = 0;
				Debug.Log ("3");
				Destroy (col.gameObject);
				//Destroy (SetEvent[2]);
			}
		}
		else if (col.gameObject.name == "Sector4") {
			SetEvent [3].SetActive (true);
			timer[3] += Time.deltaTime;
			if (timer[3]>=limitTime[3]){
				timer[3] = 0;
				Debug.Log ("4");
				Destroy (col.gameObject);
				//Destroy (SetEvent[3]);
			}
		}
		else if (col.gameObject.name == "Sector5") {
			SetEvent [4].SetActive (true);
			timer[4] += Time.deltaTime;
			if (timer[4]>=limitTime[4]){
				timer[4] = 0;
				Debug.Log ("5");
				Destroy (col.gameObject);
				//Destroy (SetEvent[4]);
			}
		}

	}
	void OnTriggerExit(Collider col){
		if (col.tag == "collidebox") {
			//Destroy (col.gameObject);
			for (int i = 0; i < 5; ++i) {
				SetEvent[i].SetActive (false);
			}		


		}



	}
}
