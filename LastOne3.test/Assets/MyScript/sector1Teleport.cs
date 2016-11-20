using UnityEngine;
using System.Collections;

public class sector1Teleport : MonoBehaviour {
	public GameObject characterAni;
	public GameObject[] off_obj;
	public GameObject[] on_obj;
	public GameObject respawn;
	public bool start;
	public bool end;
	static private bool falling;
	static private bool inputKey;
	private InputProcess data;
	private int offsizeArr;
	private int onsizeArr;


	// Use this for initialization
	void Start () {
		offsizeArr = off_obj.Length;
		onsizeArr = on_obj.Length;
		data = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<InputProcess> ();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (inputKey);
		if (inputKey) {
			if (Input.anyKeyDown) {
				Debug.Log ("HI dead");
				//data.falling = false;
				OnObject();
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Character" || col.tag == "FpsCtrl") {
			//bool isfalling = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<InputProcess> ().falling;
			if (start) {
				Debug.Log ("startzone");
				//data.falling = true;
				falling = true;
			} else if (end) {
				Debug.Log ("endzone");
				if (falling) {
					Debug.Log ("fallinglog");
					OffObject (col);
				}
			}
		}
	}
	void OnObject(){
		if (end) {
			off_obj [0].SetActive (false);
			off_obj [1].SetActive (true);
			off_obj [2].SetActive (true);
			off_obj [3].SetActive (true);
			for (int i = 0; i < onsizeArr; ++i) {
				on_obj [i].SetActive (false);
			}
			off_obj [0].transform.position = respawn.transform.position;
			off_obj [1].transform.position = respawn.transform.position;
			data.NowMode = 0;

			data.closeCamera ();

			falling = false;
			inputKey = false;
		}
	}
	void OffObject(Collider col){
		for (int i = 0; i < offsizeArr; ++i) {
			off_obj [i].SetActive (false);
		}
		for (int i = 0; i < onsizeArr; ++i) {
			on_obj [i].SetActive (true);
		}


		on_obj [0].transform.position = col.transform.position;
		on_obj [0].transform.position += new Vector3 (2, 5, -5);

		Vector3 relativePos = col.transform.position - on_obj[0].transform.position;
		Quaternion r2 = Quaternion.LookRotation (relativePos);

		on_obj[0].transform.rotation = Quaternion.Slerp(on_obj[0].transform.rotation,r2,1.0f);
		on_obj [1].transform.position = col.transform.position;
		inputKey = true;
	}
	IEnumerator Respawn(Transform tr){
		yield return new WaitForSeconds (1.0f);

	}
}
