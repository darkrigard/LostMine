using UnityEngine;
using System.Collections;

public class Stage2WallEnemy : MonoBehaviour {
	public float speed;
	int dir = 1;
	float wallMove = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//wallMove = speed * Time.deltaTime * dir;
		wallMove += speed * dir;

		if (wallMove > 0.5f)
			dir *= -1;
		else if (wallMove < -0.5f)
			dir *= -1;

		transform.Translate (wallMove, 0, 0);
	}
}
