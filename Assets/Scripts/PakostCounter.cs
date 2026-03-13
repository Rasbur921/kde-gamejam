using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PakostCounter : MonoBehaviour
{
	public Text totalText;
	public Text makedText;
	public int total;
	public int maked;
	public EpicAI epicsus;
	public PaC_walk player;
	public CameraEdgeMove camera;
	public AudioSource[] music;
	
	bool isDone;
	
    void Update()
    {
		totalText.text = total.ToString();
		makedText.text = maked.ToString();
		
        if(maked == total && !isDone){
			Debug.Log("Pobedaa");
			music[0].Stop();
			music[1].Play();
			camera.isLevelEnd = true;
			epicsus.canMove = false;
			player.canWalk = false;
			player.GetComponent<Animator>().SetBool("walk", false);
			player.GetComponent<Animator>().SetTrigger("win");
			isDone = true;
		}
    }
}
