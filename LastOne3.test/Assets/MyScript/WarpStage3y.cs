using UnityEngine;
using System.Collections;

public class WarpStage3y : MonoBehaviour {
	/// <summary>
	/// / 0은 x //  1 -> y // 2 -> z
	/// </summary>
	public BoxCollider box;
	public int Mode;
	private InputProcessStage3 data;
	// Use this for initialization
	void Start () {
		data = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<InputProcessStage3> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Character") {
			if (Mode == 0 && data.NowMode == 2) {
				Vector3 tmp = new Vector3 (col.transform.position.x - 3, box.transform.position.y, col.transform.position.z );
				col.transform.position = tmp;
			}else if (Mode == 1 && data.NowMode == 2) {
				Vector3 tmp = new Vector3 (col.transform.position.x + 2, box.transform.position.y, col.transform.position.z);
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

