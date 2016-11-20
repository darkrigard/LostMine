using UnityEngine;
using System.Collections;
 
public class LoadLevel : MonoBehaviour
{
void OnTriggerEnter(Collider other){
	AutoFade.LoadLevel("4" ,3,1,Color.black);
	}
}