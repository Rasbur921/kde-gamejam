using UnityEngine;

public class DoorPoint : WayPoint
{
    public Transform exitPoint;
	public Animator EnterDoor;
	public int toRoom;
	public EpicAI epicsus;

    public override void OnReached(EpicAI ai)
    {
        if (exitPoint != null)
        {
            ai.transform.position = exitPoint.position;
			epicsus.inRoom = toRoom;
			epicsus.gameObject.SetActive(false);
			EnterDoor.SetTrigger("epic_enter");
        }

        // дверь не ждёт — сразу идём дальше
        ai.GoToNextPoint();
    }
}
