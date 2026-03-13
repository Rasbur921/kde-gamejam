using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectedIcon : MonoBehaviour
{
	public Inventory invObj;
	public Text itemText;
	public Image itemIcon;

    void Update()
    {
        if(invObj.selectedItem == 0){
			itemText.text = "Ничего";
			itemIcon.sprite = invObj.inventSprt[0];
		}else if(invObj.selectedItem == 1){
			itemText.text = "Маркер";
			itemIcon.sprite = invObj.inventSprt[1];
		}else if(invObj.selectedItem == 2){
			itemText.text = "Пустышка";
			itemIcon.sprite = invObj.inventSprt[2];
		}else if(invObj.selectedItem == 3){
			itemText.text = "Скелет";
			itemIcon.sprite = invObj.inventSprt[3];
		}else if(invObj.selectedItem == 4){
			itemText.text = "Банан. кожура";
			itemIcon.sprite = invObj.inventSprt[4];
		}
    }
}
