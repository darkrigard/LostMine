using UnityEngine;
using System.Collections;

public class upup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.up * 0.01f);
	}
}
