using UnityEngine;
using System.Collections;


public class Stage3Clock : MonoBehaviour {
	public GUIText _guiTime;
	public float _timeCnt;
	public float nowTime = 100.0f;
	// Update is called once per frame
	void Update () 
	{
		_timeCnt += Time.deltaTime;
		if(nowTime < 1.0f)
			Application.LoadLevel (5);
	}
	/// <summary>
	/// Raises the GU event.
	/// 시간표시
	/// </summary>
	void OnGUI()
	{
		string timeStr;
		if (_timeCnt > 1) {
			_timeCnt = 0;
			nowTime -= 1;
		}
		if(nowTime%60 < 10)
			timeStr = "" + (int)nowTime/60 + " : " + "0" + nowTime%60 + _timeCnt.ToString(".00");
		else
			timeStr = "" + (int)nowTime/60 + " : " + nowTime%60 + _timeCnt.ToString(".00");
		_guiTime.text = timeStr;
	}
	// Use this for initialization
	void Start () {
		nowTime = 100;
	}
}

