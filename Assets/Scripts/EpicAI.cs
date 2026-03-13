using System.Collections.Generic;
using UnityEngine;

public class EpicAI : MonoBehaviour
{
    public List<WayPoint> route = new List<WayPoint>();
    public float speed = 2f;
	public int inRoom;
	public AudioSource[] sounds;
	public bool pakosted;
	public PakostSystem nowPakost;
	public bool canMove = true;
	public GameObject[] UI;
	public GameObject player;

    public int currentIndex;
    float waitTimer;
    bool waiting;

    void Update()
    {
        if (route.Count == 0) return;

        if (waiting && !pakosted)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= route[currentIndex].waitTime)
            {
                waiting = false;
                NextPoint();
            }
            return;
        }

        MoveTo(route[currentIndex].transform.position);
    }

	void MoveTo(Vector3 target)
	{	
		if (!canMove) return;
		
		GetComponent<Animator>().SetBool("walk", true);
	
		// фиксируем Y и Z (движение только по X)
		target.y = transform.position.y;
		target.z = transform.position.z;

		// поворот спрайта
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		if (target.x < transform.position.x)
			sr.flipX = true;   // влево
		else
			sr.flipX = false;  // вправо
		
		// движение
		transform.position = Vector3.MoveTowards(
			transform.position,
			target,
			speed * Time.deltaTime
		);
		// достижение точки
		if (Mathf.Abs(transform.position.x - target.x) < 0.05f)
		{
			GetComponent<Animator>().SetBool("walk", false);
			OnReachPoint();
		}
	}


	void OnReachPoint()
	{
		WayPoint wp = route[currentIndex];
		wp.OnReached(this);
	}
	
	public void StartWaiting(float time)
	{
		waiting = true;
		waitTimer = 0f;
	}

	public void GoToNextPoint()
	{
		waiting = false;
		currentIndex++;

		if (currentIndex >= route.Count)
			currentIndex = 0;
	}

    void NextPoint()
    {
        currentIndex++;
        if (currentIndex >= route.Count)
            currentIndex = 0;
    }
	
	
	public void HuhSound(){
		sounds[0].Play();
	}
	
	public void AngrySound(){
		sounds[1].Play();
	}
	
	public void DieSound(){
		sounds[2].Play();
	}
	
	public void Pakosted(){
		pakosted = true;
	}
	
	public void Unpakosted(){
		pakosted = false;
		canMove = true;
		nowPakost.GetComponent<SpriteRenderer>().sprite = nowPakost.changePic[1];
		nowPakost.UnPakosted();
	}
	
	public void CanMove(){
		canMove = true;
	}

	public void CantMove(){
		canMove = false;
	}
	
	public void Laugh(){
		nowPakost.PakostLaugh();
	}
	
	public void FalseActivePlayer(){
		player.SetActive(false);
	}
	
	public void Lose(){
		UI[0].SetActive(false);
		UI[1].SetActive(false);
		UI[2].SetActive(false);
		UI[3].SetActive(false);
		UI[4].SetActive(true);
		UI[5].SetActive(true);
	}
}
