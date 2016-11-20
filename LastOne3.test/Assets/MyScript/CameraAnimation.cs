using UnityEngine;
using System.Collections;

public class CameraAnimation : MonoBehaviour {

	public GameObject[] off_obj;
	public float countTime;
	private int arr_lenth;
	public bool start;
	// Use this for initialization
	void Start () {
		countTime = 0;
		Debug.Log (off_obj.Length);
		arr_lenth = off_obj.Length;
	}
	
	// Update is called once per frame
	void Update () {
		countTime += Time.deltaTime;
		if (start) {
			for (int i = 0; i < arr_lenth; ++i) {
				off_obj [i].SetActive (true);
			}
			gameObject.SetActive (false);
		}
	}
}
