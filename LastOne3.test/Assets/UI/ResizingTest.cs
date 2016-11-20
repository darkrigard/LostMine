using UnityEngine;
using System.Collections;

public class ResizingTest : MonoBehaviour {

	private SpriteRenderer _mySpirteRender;

	void Start()
	{
		Rect bound = Utility.bound3D (-Camera.main.transform.position.z);

		_mySpirteRender = GetComponent<SpriteRenderer>();
		transform.localScale = Utility.FullSizeSprite (transform.localScale, _mySpirteRender, bound);
	}
}
