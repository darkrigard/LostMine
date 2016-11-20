using UnityEngine;
using System.Collections;


public class Stage3LifeTimeScript : MonoBehaviour {
	public GUIText _guiTime;
	public int personLife = 3;

	void Update ()
	{

		if (personLife == 3) {
			if (GameObject.FindGameObjectsWithTag ("Drop").Length == 2) {
				personLife--;
			}
		}
		if (personLife == 2) {
			if (GameObject.FindGameObjectsWithTag ("Drop").Length == 1) {
				personLife--;
			}
		}
	}

	void OnGUI()
	{
		string timeStr;
		timeStr = "" + (int)personLife  + " Life " ;
		_guiTime.text = timeStr;
	}
	// Use this for initialization
	void Start () {

	}
}

