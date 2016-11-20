using UnityEngine;
using System.Collections;

public class InteractScript : MonoBehaviour {


	public float interactDistance = 5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Ray ray = new Ray (transform.position, transform.forward);
			RaycastHit hit;
			if(Physics.Raycast (ray,out hit, interactDistance))
			{
				if(hit.collider.CompareTag ("Door"))
				{
					hit.collider.transform.parent.GetComponent<DoorScript>().ChangeDoorState();
				}
			}
		}
	
	}
}
