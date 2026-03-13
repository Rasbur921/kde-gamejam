using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public GameObject Player;
	public GameObject epicsus;
	public Transform Point;
	public int toRoom;
	public Animator nextDoor;
	public AudioSource[] sounds;
	
	public void Teleport(){
		Player.transform.position = Point.position;
		Player.GetComponent<PaC_walk>().inRoom = toRoom;
		Player.SetActive(false);
		GetComponent<Animator>().SetTrigger("chel_enter");
	}
	
	public void OpenSound(){
		sounds[0].Play();
	}
	
	public void CloseSound(){
		sounds[1].Play();
	}

	public void ActivetedPlayer(){
		Player.SetActive(true);
	}
	
	public void PlayExitAnim(){
		nextDoor.SetTrigger("chel_exit");
	}
	
	public void ActivetedEpicsus(){
		epicsus.SetActive(true);
	}
	
	public void PlayEpicExitAnim(){
		nextDoor.SetTrigger("epic_exit");
	}
}
