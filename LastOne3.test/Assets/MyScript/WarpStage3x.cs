using UnityEngine;
using System.Collections;

public class WarpStage3x : MonoBehaviour {
	/// <summary>
	/// / 0은 x //  1 -> y // 2 -> z
	/// </summary>
	public BoxCollider box;
	public int Mode;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Character") {
			if (Mode == 0) {
				Vector3 tmp = new Vector3 (box.transform.position.x, col.transform.position.y, col.transform.position.z);
				col.transform.position = tmp;
			}else if (Mode == 1) {
				Vector3 tmp = new Vector3 (col.transform.position.x, box.transform.position.y, col.transform.position.z);
				col.transform.position = tmp;
			}
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.collider.tag == "Character") {
			Debug.Log ("HI");
			if (Mode == 0) {
				Vector3 tmp = new Vector3 (box.transform.position.x, col.transform.position.y, col.transform.position.z);
				col.transform.position = tmp;
			}
		}
	}
}
