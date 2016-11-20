using UnityEngine;
using System.Collections;

public class Stage2BallEnemyScript2 : MonoBehaviour {
	public float speed;
	int dir = -1;
	float ballMove2 = 0;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//ballMove += speed * Time.deltaTime * dir;
		ballMove2 += speed * dir;

		if (ballMove2 > 0.6f)
			dir *= -1;
		else if (ballMove2 < -0.6f)
			dir *= -1;

		transform.Translate (ballMove2, 0, 0);
	}
}

