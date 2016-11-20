using UnityEngine;
using System.Collections;

public class deadzone : MonoBehaviour {
	public GameObject respawn;
	private bool dead;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		Debug.Log ("colcolcol");
		if (col.collider.tag == "Character") {
			col.transform.position = respawn.transform.position;
		} else if (col.collider.tag == "FpsCtrl") {
			col.transform.position = respawn.transform.position;
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.tag == "Character") {
			StartCoroutine (Respawn(col.transform));
			//dead = true;
			//Respawn ();
			//col.transform.position = respawn.transform.position;
		} else if (col.tag == "FpsCtrl") {
			StartCoroutine (Respawn(col.transform));
			//dead = true;
			//Respawn ();
			//col.transform.position = respawn.transform.position;
		}
	}

	IEnumerator Respawn(Transform tr){
		yield return new WaitForSeconds (2.0f);
		//Application.LoadLevel ("GAMEOVER_UI");
		tr.position = respawn.transform.position;
	}
}
