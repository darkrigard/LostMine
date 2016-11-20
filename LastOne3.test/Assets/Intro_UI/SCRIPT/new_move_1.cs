using UnityEngine;
using System.Collections;

public class new_move_1 : MonoBehaviour {

    public GameObject obj;

    float UpAndDown = 0;

    int dir = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        UpAndDown += Time.deltaTime * dir;

        if (UpAndDown > 2.0f)
            dir *= -1;
        else if (UpAndDown < -3.0f)
            dir *= -1;
        obj.transform.Translate(UpAndDown / 300, 0, 0);

		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			Application.LoadLevel ("MainStage");
		}

    }
}
