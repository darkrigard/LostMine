using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class Stage3PersonScript : MonoBehaviour
	{
		private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
		private Transform m_Cam;                  // A reference to the main camera in the scenes transform
		private Vector3 m_CamForward;             // The current forward direction of the camera
		private Vector3 m_Move;
		private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

		public GUIText _guiLife;
		public int personLife;
		public int teleportBox = 2;
		Vector3 Stage3PersonPos;

		private void Start()
		{
			personLife = 3;
			// get the transform of the main camera
			if (Camera.main != null)
			{
				m_Cam = Camera.main.transform;
			}
			else
			{
				Debug.LogWarning(
					"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.");
				// we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
			}

			// get the third person character ( this should never be null due to require component )
			m_Character = GetComponent<ThirdPersonCharacter>();
		}


		private void Update()
		{
			Stage3PersonPos = transform.position;

			if (!m_Jump)
			{
				m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
			}
			if (GameObject.FindGameObjectsWithTag ("ClearDot").Length == 0) {
				Application.LoadLevel (8);
			}

	
			if (personLife == 3) {
				// 첫 번째 퀘스트 드랍박스
				if (GameObject.FindGameObjectsWithTag ("Drop").Length == 2) {
					Stage3PersonPos = new Vector3 (51, -4, 24);
					transform.position = Stage3PersonPos;
					personLife--;
				}
				//if (GameObject.FindGameObjectsWithTag ("Drop2").Length == 2) {
				//	Stage3PersonPos = new Vector3 (-46, 2, 12);
				//	transform.position = Stage3PersonPos;
				//	personLife--;
				//}
			} 

			if (personLife == 2) {
				// 첫번 째 블락을 먹은 경우
				if (GameObject.FindGameObjectsWithTag ("Drop").Length == 1) {
					//if (GameObject.FindGameObjectsWithTag ("Drop").Length == 1) {
						Stage3PersonPos = new Vector3 (51, -4, 24);
						transform.position = Stage3PersonPos;
						personLife--;
					//}
					//if (GameObject.FindGameObjectsWithTag ("Drop2").Length == 2) {
					//	Stage3PersonPos = new Vector3 (-46, 2, 12);
					//	transform.position = Stage3PersonPos;
					//	personLife--;
					//} 
				}

				// 두 번째 블락을 먹은 경우

			//	if (GameObject.FindGameObjectsWithTag ("Drop2").Length == 2) {
				//	if (GameObject.FindGameObjectsWithTag ("Drop").Length == 2) {
				//		Stage3PersonPos = new Vector3 (51, -4, 24);
				//		transform.position = Stage3PersonPos;
				//		personLife--;
				//	}
				//	if (GameObject.FindGameObjectsWithTag ("Drop2").Length == 1) {
				//		Stage3PersonPos = new Vector3 (-46, 2, 12);
				//		transform.position = Stage3PersonPos;
				//		personLife--;
				//	}
				//}
			} 


			if (personLife == 1) {
				if (GameObject.FindGameObjectsWithTag ("Drop").Length == 0) {
					Application.LoadLevel (5);
				}
			}

				/*
				// 두 번째 퀘스트 드립박스
//				if (GameObject.FindGameObjectsWithTag ("Drop2").Length == 2) {
//
//					Stage3PersonPos = new Vector3 (-46,2,12);
//					transform.position = Stage3PersonPos;					
//					personLife--;
//				}
//
//				if (GameObject.FindGameObjectsWithTag ("Drop2").Length == 1) {
//					Stage3PersonPos = new Vector3 (-46,2,12);
//					transform.position = Stage3PersonPos;					
//					personLife--;
//				}
//
//				if (GameObject.FindGameObjectsWithTag ("Drop2").Length == 0) {
//					Application.LoadLevel (5);
//				}
				*/


			if (teleportBox == 2) {
				if (GameObject.FindGameObjectsWithTag ("Stage3TeleportBox1").Length == 0) {
					Stage3PersonPos.x = -4;
					Stage3PersonPos.y = 12;
					Stage3PersonPos.z = 11;
					transform.position = Stage3PersonPos;
					teleportBox--;
				}
			}

			if (teleportBox == 1) {
				if (GameObject.FindGameObjectsWithTag ("Stage3TeleportBox2").Length == 0) {
					Stage3PersonPos.x = -160;
					Stage3PersonPos.y = 2;
					Stage3PersonPos.z = 9;
					transform.position = Stage3PersonPos;
					teleportBox--;
				}
			}

			//if (GameObject.FindGameObjectsWithTag ("TeleportBox1").Length == 0) {
			//	transform.Translate( 0,15, 25);
			//}
			if (Input.GetKeyDown ("r")) {
				Application.LoadLevel (2);
			}
		}

		void OnTriggerExit(Collider other){
			Destroy (other.gameObject);

		}


		// Fixed update is called in sync with physics
		private void FixedUpdate()
		{
			// read inputs
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			float v = CrossPlatformInputManager.GetAxis("Vertical");
			bool crouch = Input.GetKey(KeyCode.C);

			// calculate move direction to pass to character
			if (m_Cam != null)
			{
				// calculate camera relative direction to move:
				m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
				m_Move = v*m_CamForward + h*m_Cam.right;
			}
			else
			{
				// we use world-relative directions in the case of no main camera
				m_Move = v*Vector3.forward + h*Vector3.right;
			}
			#if !MOBILE_INPUT
			// walk speed multiplier
			if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
			#endif

			// pass all parameters to the character control script
			m_Character.Move(m_Move, crouch, m_Jump);
			m_Jump = false;
		}
	}
}
