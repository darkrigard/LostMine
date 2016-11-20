using UnityEngine;
using System.Collections;

public class CameraStage2Script : MonoBehaviour {
	public GameObject[] MyCam;
	public int mode = 4;
	public GameObject PlayerPosition;

	float TurnSpeed;

	Vector3 turnVec3;

	// Use this for initialization
	void Start () {
		TurnSpeed = 2f;
	}

	// Update is called once per frame
	void Update () {

		turnVec3 = new Vector3 (0, Input.GetAxis ("Mouse X"), 0);

		transform.Rotate (turnVec3 * TurnSpeed);

		if (Input.GetKeyDown ("q")) {
			if (mode == 0) {
				MyCam [0].SetActive (false);
				MyCam [1].SetActive (true);
				MyCam [2].SetActive (false);
				mode = 1;
			} else if (mode == 1) {
				MyCam [0].SetActive (false);
				MyCam [1].SetActive (false);
				MyCam [2].SetActive (true);
				mode = 2;
			} else if (mode == 2) {
				MyCam [0].SetActive (true);
				MyCam [1].SetActive (false);
				MyCam [2].SetActive (false);
				mode = 0;
			}
		}
		if (mode == 0) {
			MyCam [0].transform.position = new Vector3 (PlayerPosition.transform.position.x, PlayerPosition.transform.position.y + 5, PlayerPosition.transform.position.z);
		} 
		 if(mode == 1){
			MyCam [1].transform.position = new Vector3 (PlayerPosition.transform.position.x + 5, PlayerPosition.transform.position.y, PlayerPosition.transform.position.z);
		}
		if(mode == 2){
			MyCam [2].transform.position = new Vector3 (PlayerPosition.transform.position.x + 5, PlayerPosition.transform.position.y + 5, PlayerPosition.transform.position.z);
		}
		if(mode == 4){
			MyCam [0].SetActive (false);
			MyCam [1].SetActive (true);
			MyCam [2].SetActive (false);
			mode = 1;

		}
	}
}

