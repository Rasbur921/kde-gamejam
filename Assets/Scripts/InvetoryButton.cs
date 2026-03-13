using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InvetoryButton : MonoBehaviour
{
    public Inventory inventObj;
	public Image inventIcon;
	public int ID;

    void Update()
    {
		if (inventObj.invent != null &&
			ID >= 0 &&
			ID < inventObj.invent.Length &&
			inventObj.invent[ID] != 0 &&
			inventObj.inventSprt != null &&
			ID < inventObj.inventSprt.Length &&
			inventObj.inventSprt[ID] != null)
		{
			Debug.Log("У тебя есть: " + inventObj.invent[ID]);
			int itemID = inventObj.invent[ID];
			
			if (itemID > 0 && itemID < inventObj.inventSprt.Length)
			{
				inventIcon.sprite = inventObj.inventSprt[itemID];
			}
		}else{
			inventIcon.sprite = inventObj.inventSprt[0];
		}
    }
	
	public void SelectItem(){
		int itemID = inventObj.invent[ID];
		inventObj.selectedItem = itemID;
	}
}
