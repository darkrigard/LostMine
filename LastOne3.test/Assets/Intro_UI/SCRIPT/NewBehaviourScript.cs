using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject obj;

    float UpAndDown = 0;

    int dir = 1;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        UpAndDown += Time.deltaTime*dir;

        if (UpAndDown > 1.0f)
            dir *= -1;
        else if(UpAndDown < -1.0f)
            dir *= -1;
        obj.transform.Translate(0,UpAndDown/1500, 0);
        	
	}
}
