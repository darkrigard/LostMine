using UnityEngine;
using System.Collections;

public class InputProcessStage3 : MonoBehaviour {

	public GameObject[] CameraMode;
	public int NowMode;
	public GameObject Player;
	public GameObject Fps_controll;
	public bool falling = false;

	// Use this for initialization
	void Start () {
		NowMode = 1;
		CameraMode [0].SetActive (true);
		CameraMode [1].SetActive (false);
		CameraMode [2].SetActive (false);
		Fps_controll.SetActive (false);
		Player.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		ChangeCamera ();
		//if (NowMode == 0) {
		//	PositionSet (0);
		//} else {
		//	PositionSet (1);
		//}
	}

	void ChangeCamera(){
		if (Input.GetKeyDown ("1") && NowMode != 0) {
			NowMode = 0;
			CameraMode [0].SetActive (false);
			CameraMode [1].SetActive (false);
			CameraMode [2].SetActive (false);
			Fps_controll.SetActive (true);
			Player.SetActive (false);
			Vector3 tmp = new Vector3(Player.transform.position.x,Player.transform.position.y+1.5f,Player.transform.position.z);
			Fps_controll.transform.position = tmp;
			//PositionSet (0);
		} else if (Input.GetKeyDown ("2") && NowMode != 1) {
			NowMode = 1;
			CameraMode [0].SetActive (true);
			CameraMode [1].SetActive (false);
			CameraMode [2].SetActive (false);
			Fps_controll.SetActive (false);
			Player.SetActive (true);
			//PositionSet (1);
			Vector3 tmp = new Vector3(Fps_controll.transform.position.x,Fps_controll.transform.position.y,Fps_controll.transform.position.z);
			Player.transform.position = tmp;
			Player.transform.forward = new Vector3 (0, 0, 1);
		} else if (Input.GetKeyDown ("3")&& NowMode != 2) {
			NowMode = 2;
			CameraMode [0].SetActive (false);
			CameraMode [1].SetActive (true);
			CameraMode [2].SetActive (false);
			Fps_controll.SetActive (false);
			Player.SetActive (true);
			Vector3 tmp = new Vector3 (Fps_controll.transform.position.x, Fps_controll.transform.position.y, Fps_controll.transform.position.z);
			//transform.Rotate (new Vector3 (180, 180, 0));
			Player.transform.position = tmp;
			//PositionSet (1);
		} else if (Input.GetKeyDown ("4") && NowMode != 3) {
			NowMode = 3;
			CameraMode [0].SetActive (false);
			CameraMode [1].SetActive (false);
			CameraMode [2].SetActive (true);
			Fps_controll.SetActive (false);
			Player.SetActive (true);
			Vector3 tmp = new Vector3(Fps_controll.transform.position.x,Fps_controll.transform.position.y,Fps_controll.transform.position.z);
			Player.transform.position = tmp;
			//PositionSet (1);
			Player.transform.forward = new Vector3 (1, 0, 0);
		}
	}

	public void closeCamera(){
		CameraMode [0].SetActive (false);
		CameraMode [1].SetActive (false);
		CameraMode [2].SetActive (false);
	}

	void PositionSet(int flag){
		if (flag == 0) { // 1인칭으로 갈때
			Vector3 tmp = new Vector3(Fps_controll.transform.position.x,Fps_controll.transform.position.y+1.5f,Fps_controll.transform.position.z);
			Fps_controll.transform.position = tmp;
			Player.transform.position = Fps_controll.transform.position;
			Fps_controll.transform.position = Player.transform.position;
		} else if (flag == 1) { // 2번키
			Fps_controll.transform.position = Player.transform.position;
			Player.transform.position = Fps_controll.transform.position;
		} else if (flag == 2) { // 3번키
			Player.transform.position = Fps_controll.transform.position;
		} else if (flag == 3) { // 4번키
			Player.transform.position = Fps_controll.transform.position;
		}
	}
}
