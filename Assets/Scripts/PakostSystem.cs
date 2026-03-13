using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PakostSystem : MonoBehaviour
{
    public Inventory inventObj;
	public PaC_walk Player;
	public SpriteRenderer epicsus;
	public PakostCounter pkstObj;
	public int itemID;
	public int pakostID;
	public bool pakosted = false;
	
	public WayPoint rodnoyPoint;
	public float pointTime;

	public Sprite[] changePic;
	public AudioSource[] sounds;
	public AudioSource[] laughs;

    public void Pakost()
    {
        if(pakostID == 1 && inventObj.selectedItem == 1 && itemID == 1 && pakosted == false){
			Player.GetComponent<Animator>().SetTrigger("pakost");
			
			int count = 0;
			for (int i = 0; i < inventObj.invent.Length; i++)
			{
				if (inventObj.invent[i] != itemID)
					count++;
			}

			// Создаём новый массив
			int[] newInvent = new int[count];
			int index = 0;
			for (int i = 0; i < inventObj.invent.Length; i++)
			{
				if (inventObj.invent[i] != itemID)
				{
					newInvent[index] = inventObj.invent[i];
					index++;
				}
			}
			inventObj.invent = newInvent;
			
			inventObj.selectedItem = 0;
			gameObject.GetComponent<SpriteRenderer>().sprite = changePic[0];
			pakosted = true;
		}
		else if(pakostID == -1 && pakosted == false){
			gameObject.GetComponent<SpriteRenderer>().sprite = changePic[0];
			pakosted = true;
		}		
		else if(pakostID == 2 && inventObj.selectedItem == 3 && itemID == 3 && pakosted == false){
			Player.GetComponent<Animator>().SetTrigger("pakost");
			
			int count = 0;
			for (int i = 0; i < inventObj.invent.Length; i++)
			{
				if (inventObj.invent[i] != itemID)
					count++;
			}

			// Создаём новый массив
			int[] newInvent = new int[count];
			int index = 0;
			for (int i = 0; i < inventObj.invent.Length; i++)
			{
				if (inventObj.invent[i] != itemID)
				{
					newInvent[index] = inventObj.invent[i];
					index++;
				}
			}
			inventObj.invent = newInvent;
			inventObj.selectedItem = 0;
			pakosted = true;
		}
		else if(pakostID == 3 && inventObj.selectedItem == 4 && itemID == 4 && pakosted == false){
			Player.GetComponent<Animator>().SetTrigger("pakost");
			
			int count = 0;
			for (int i = 0; i < inventObj.invent.Length; i++)
			{
				if (inventObj.invent[i] != itemID)
					count++;
			}

			// Создаём новый массив
			int[] newInvent = new int[count];
			int index = 0;
			for (int i = 0; i < inventObj.invent.Length; i++)
			{
				if (inventObj.invent[i] != itemID)
				{
					newInvent[index] = inventObj.invent[i];
					index++;
				}
			}
			inventObj.invent = newInvent;
			inventObj.selectedItem = 0;
			
			GetComponent<SpriteRenderer>().enabled = true;
			pakosted = true;
		}else{
			Player.GetComponent<Animator>().SetTrigger("nuhuh");
		}
    }
	
	public void EpicScream(){
		sounds[0].Play();
	}
	
	public void PlaySound(int soundID){
		sounds[soundID].Play();
	}
	
	public void UnPakosted(){
		rodnoyPoint.waitTime = pointTime;
		pakosted = false;
		pkstObj.maked++;
		if(pakostID == 3){
			GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	
	public void InvisEpic(){
		epicsus.enabled = false;
	}
	
	public void VisEpic(){
		epicsus.enabled = true;
	}
	
	public void PakostLaugh(){
		int r = Random.Range(0, 3);
		laughs[r].Play();
	}
}
