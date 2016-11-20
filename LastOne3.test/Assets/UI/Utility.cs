using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

	// 카메라가 비추는 화면 영역을 3D 영역의 좌표로 변환하여 Vector3 타입으로 반환.
	private static Vector3 screenTo3D(float x2, float y2, float z)
	{
		return Camera.main.ScreenToWorldPoint (new Vector3(x2, y2, z));
	}

	// 화면 영역을 사각형 Rect 자료형으로 상/하/좌/우의 좌표 값 설정.
	public static Rect bound3D(float z){
		Vector3 leftBottom = screenTo3D (0, 0, z);
		Vector3 rightTop = screenTo3D (Camera.main.pixelWidth, Camera.main.pixelHeight, z);
		return new Rect (
			leftBottom.x, rightTop.y,
			rightTop.x - leftBottom.x, rightTop.y - leftBottom.y
			);
	}

	public static Vector3 FullSizeSprite(Vector3 scale, SpriteRenderer render, Rect bound)
	{
		Vector3 fullScale = Vector3.zero;
		float scaleX, scaleY, scaleZ;
		scaleX = scale.x * (bound.size.x / render.bounds.size.x);
		scaleY = scale.y * (bound.size.y / render.bounds.size.y);
		scaleZ = 1.0f;
		fullScale = new Vector3 (scaleX, scaleY, scaleZ);
		return fullScale;
	}

	public static string SetTextComma(int value)
	{
		string text = value.ToString ();
		if (text.Length < 4)
			return text;
		string temp = "";
		int commaIndex = 0;
		for(int i = text.Length - 1; i >= 0 ; i--)
		{
			temp += text[i];
			commaIndex++;
			if(commaIndex >= 3){
				temp += ",";
				commaIndex = 0;
				continue;
			}
		}
		string reverseText = "";
		for (int i = temp.Length - 1; i >= 0; i--){
			reverseText += temp [i];
		}
		return reverseText;
	}

	public static float GetAngle(Transform origin, Vector3 Target)
	{
		Vector3 relative = origin.InverseTransformPoint(Target);
		float angle	= Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
		Debug.Log (angle);
		return angle;
	}
}
