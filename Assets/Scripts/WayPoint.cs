using UnityEngine;
using UnityEngine.UI;

public enum WayPointType
{
    Item,
    Door
}

public class WayPoint : MonoBehaviour
{
    public WayPointType type;
    public float waitTime = 2f;
	public float pakostTime;
	public PakostSystem itemAction;
	public NowWay wayIcon;
	public int wayIconID;
	public bool isActive;
	public EpicAI epicsus;
	public bool isAnimateEpicsus;

    public virtual void OnReached(EpicAI ai)
    {
		if(isActive && itemAction.pakosted == false && isAnimateEpicsus == false){
			itemAction.GetComponent<Animator>().SetTrigger("action");
		}else if(isActive && itemAction.pakosted == true && isAnimateEpicsus == false){
			waitTime = pakostTime;
			itemAction.GetComponent<Animator>().SetTrigger("actionPakost");
		}
		
		if(isActive && itemAction.pakosted == false && isAnimateEpicsus == true){
			epicsus.GetComponent<Animator>().SetTrigger("idleSeek");
		}else if(isActive && itemAction.pakosted == true && isAnimateEpicsus == true){
			epicsus.canMove = false;
			epicsus.GetComponent<Animator>().SetBool("walk", false);
			epicsus.nowPakost = itemAction;
			epicsus.GetComponent<Animator>().SetTrigger("pakost");
		}
		
		if(wayIconID == 3){
			epicsus.GetComponent<Animator>().SetTrigger("kill");
		}
		
        ai.StartWaiting(waitTime);
		Invoke(nameof(ChangeNextWay), waitTime);
    }
	
	void ChangeNextWay()
	{
		wayIcon.GetComponent<Image>().sprite = wayIcon.icon[wayIconID];
	}
}

