using UnityEngine;
using System.Collections;

public class UIsprite : MonoBehaviour {
	public float count_time = 0;
	public GameObject sprite;
	public bool UIset;
	// Use this for initialization
	void Start () {
		UIset = true;
	}
	
	// Update is called once per frame
	void Update () {
		//if(count_time < 5){
		//	count_time += Time.deltaTime;
		//}
		//else{
		//	if(UIset){
		//		sprite.SetActive(false);
		//		UIset = false;
		//	}
		//}
	}
}
