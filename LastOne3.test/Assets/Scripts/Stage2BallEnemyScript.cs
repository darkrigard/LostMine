using UnityEngine;
using System.Collections;

public class Stage2BallEnemyScript : MonoBehaviour {
	public float speed;
	int dir = 1;
	float ballMove = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//ballMove += speed * Time.deltaTime * dir;
		ballMove += speed * dir;

		if (ballMove > 0.3f)
			dir *= -1;
		else if (ballMove < -0.3f)
			dir *= -1;

		transform.Translate (ballMove, 0, 0);
	}
}
