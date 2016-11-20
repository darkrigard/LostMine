using UnityEngine;
using System.Collections;

public class DispMsg : MonoBehaviour {
	public static int lengthMsg;
	public static bool flgDisp = false;
	public static float waitTime = 0;

	public static string dispMsg;

	//float nextTime = 0;

	public GUIStyle msgWnd;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

	public static void dispMessage (string msg)
	{
		dispMsg = msg;
	}

	void OnGUI(){
		const float screenWidth = 1136;

		const float msgwWidth = 800;
		const float msgwHeight = 200;
		const float msgwPosX = (screenWidth - msgwWidth) / 2;
		const float msgwPosY = 390;

		float factorSize = Screen.width / screenWidth;

		float msgwX;
		float msgwY;
		float msgwW = msgwWidth * factorSize;
		float msgwH = msgwHeight * factorSize;

		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = (int)(30 * factorSize);

		if(flgDisp == true){
			// chang
			msgwX = msgwPosX * factorSize;
			msgwY = msgwPosY * factorSize;
			GUI.Box (new Rect (msgwX, msgwY, msgwW, msgwH), "창", msgWnd);

			// message grimja
			myStyle.normal.textColor = Color.black;

			msgwX = (msgwPosX + 22) * factorSize;
			msgwY = (msgwPosY + 22) * factorSize;
			GUI.Label (new Rect (msgwX, msgwY, msgwW, msgwH),
				dispMsg.Substring (0, lengthMsg), myStyle);

			// message
			myStyle.normal.textColor = Color.white;

			msgwX = (msgwPosX + 22) * factorSize;
			msgwY = (msgwPosY + 22) * factorSize;
			GUI.Label(new Rect(msgwX, msgwY, msgwW, msgwH),
				dispMsg.Substring(0, lengthMsg),myStyle);
		}
	}
		

}
