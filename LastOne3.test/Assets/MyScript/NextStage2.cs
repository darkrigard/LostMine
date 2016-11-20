using UnityEngine;
using System.Collections;

public class NextStage2 : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider col){
		Application.LoadLevel (8);
	}
}
