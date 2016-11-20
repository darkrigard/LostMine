using UnityEngine;
using System.Collections;

public class Zprojection : MonoBehaviour {
	public GameObject Player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tmp = new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 2);
		transform.position = tmp;
	}
}
