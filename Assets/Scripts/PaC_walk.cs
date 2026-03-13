using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class PaC_walk : MonoBehaviour
{
    public float speed = 5f;
	public int inRoom;
	public EpicAI epicsus;
	public AudioSource[] sounds;
    private Vector3 target;
    private bool isMoving = false;
    private bool isGoingToGrab = false;
    private bool isGoingToPakost = false;
    private bool isGoingToDoor = false;
	private bool playMeh = false;
	public bool canWalk = true;
	
	public LayerMask floorLayer;
	public LayerMask grabLayer;
	public LayerMask pakostLayer;
	public LayerMask doorLayer;
	
	public Inventory inventObj;
	
	public List<WayPoint> playerPoint;
	public NowWay epicWay;
	
	public AudioSource[] music;
	public GameObject[] UI;
	public CameraEdgeMove camera;
	
	private Door targetDoor;
	private PakostSystem targetPakost;
	private GrabItemZone grabZone;
	private bool fail;

    void Update()
    {
		if(fail){
			targetDoor = null;
		}
		
		if(epicsus.inRoom == inRoom && !fail){
			Debug.Log("Ну всо, ты сдох.");
			camera.isLevelEnd = true;
			music[0].Stop();
			music[1].Play();
			canWalk = false;
			epicsus.route = playerPoint;
			epicsus.currentIndex = 0;
			epicWay.GetComponent<Image>().sprite = epicWay.icon[3];
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			GetComponent<Animator>().SetTrigger("fear");
			fail = true;
		}
		
         Vector2 mouseWorldPos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hit = Physics2D.OverlapPoint(mouseWorldPos, floorLayer);
		
        Collider2D hitGrab = Physics2D.OverlapPoint(mouseWorldPos, grabLayer);
		
        Collider2D hitPakost = Physics2D.OverlapPoint(mouseWorldPos, pakostLayer);
		
        Collider2D hitDoor = Physics2D.OverlapPoint(mouseWorldPos, doorLayer);
 
       // Клик мышью
		if (Input.GetMouseButtonDown(0) && hit != null && hit.GetComponent<RoomCheck>().room == inRoom && canWalk == true)
		{
			Walk();
			isGoingToGrab = false;
			isGoingToPakost = false;
			isGoingToDoor = false;
		}
		
		if (Input.GetMouseButtonDown(0) && hitGrab != null && hitGrab.GetComponent<RoomCheck>().room == inRoom && canWalk == true)
		{
			grabZone = hitGrab.GetComponent<GrabItemZone>();
			Walk();
			isGoingToGrab = true;
			isGoingToPakost = false;
			isGoingToDoor = false;
		}
		
		if (Input.GetMouseButtonDown(0) && hitPakost != null && hitPakost.GetComponent<RoomCheck>().room == inRoom && canWalk == true)
		{
			targetPakost = hitPakost.GetComponent<PakostSystem>();
			Walk();
			isGoingToGrab = false;
			isGoingToPakost = true;
			isGoingToDoor = false;
		}
	
		if (Input.GetMouseButtonDown(0) && hitDoor != null && hitDoor.GetComponent<RoomCheck>().room == inRoom && canWalk == true)
		{
			targetDoor = hitDoor.GetComponent<Door>();
			Walk();
			isGoingToGrab = false;
			isGoingToPakost = false;
			isGoingToDoor = true;
		}

        // Движение
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, target) < 0.05f){
                isMoving = false;
				GetComponent<Animator>().SetBool("walk", false);
				
				if (isGoingToGrab)
				{
					grabZone.Grab();
					grabZone = null;
					isGoingToGrab = false;
				}
				
				if(isGoingToPakost){
					targetPakost.Pakost();
					targetPakost = null;
					isGoingToPakost = false;
				}
				
				if(isGoingToDoor){		
					targetDoor.Teleport();
					targetDoor = null;
					isGoingToDoor = false;
				}
			
			}
        }
    }
	
	public void Walk(){
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.y = transform.position.y;   // ← фиксируем Y
			target.z = transform.position.z;
			if (target.x < transform.position.x)
				GetComponent<SpriteRenderer>().flipX = true;   // смотрит влево
			else
				GetComponent<SpriteRenderer>().flipX = false;  // смотрит вправо
			
			GetComponent<Animator>().SetBool("walk", true);
			isMoving = true;
	}
	
	public void Laugh(){
		sounds[2].Play();
	}
	
	public void NuhUh(){
		sounds[1].Play();
	}

	public void PakostSound(){
		sounds[3].Play();
	}
	
	public void OSound(){
		sounds[4].Play();
	}

	public void Meh(){
		sounds[0].Play();
	}
	
	public void Uhu(){
		sounds[5].Play();
	}
	
	public void CantWalk(){
		canWalk = false;
	}
	
	public void CanWalk(){
		if(!fail){
			canWalk = true;
		}
	}
	
	public void Win(){
		UI[0].SetActive(false);
		UI[1].SetActive(false);
		UI[2].SetActive(false);
		UI[3].SetActive(false);
		UI[4].SetActive(true);
		UI[5].SetActive(true);
	}
}
