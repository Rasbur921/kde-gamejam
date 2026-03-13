using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDeactiveButton : MonoBehaviour
{
	public bool toDeactive;
	public GameObject ActiveObject;
	
	public void PressButton(){ 
		if(!toDeactive){
			ActiveObject.SetActive(true);
		}else{
			ActiveObject.SetActive(false);
		}
	}
}
