using UnityEngine;
using System.Collections;

public class Stair_mv : MonoBehaviour {

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

        if (UpAndDown > 1.0f)
            dir *= -1;
        else if (UpAndDown < -1.0f)
            dir *= -1;
        obj.transform.Translate(UpAndDown / 300, UpAndDown / 300, 0);

    }
}
