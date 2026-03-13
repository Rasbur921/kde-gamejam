using UnityEngine;

public class GrabItemZone : MonoBehaviour
{
	public int[] Items;
	public PaC_walk Player;
	public bool isEmpty;
	
	void Start(){
		if(isEmpty){
			Items = null;
		}
	}
	
	public void Grab(){
					if(Items != null){
						Player.GetComponent<Animator>().SetTrigger("o");
						// Проходим по всем ID предметов, которые находятся в зоне
						foreach (int itemID in Items)
						{
							if (itemID == 0) continue; // пропускаем пустые слоты

							Debug.Log("Ты получил предмет с ID: " + itemID);

							// Создаём новый массив на 1 элемент больше
							int[] newInvent = new int[Player.inventObj.invent.Length + 1];

							// Копируем старые элементы
							for (int i = 0; i < Player.inventObj.invent.Length; i++)
							{
								newInvent[i] = Player.inventObj.invent[i];
							}

							// Добавляем новый элемент в конец
							newInvent[Player.inventObj.invent.Length] = itemID;

							// Заменяем старый массив
							Player.inventObj.invent = newInvent;
						}
					}else{
						Player.GetComponent<Animator>().SetTrigger("meh");
					}

					// Очищаем зону (предметы подняты)
					Items = null;		
	}
}