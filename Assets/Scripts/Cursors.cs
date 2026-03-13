using UnityEngine;

public class Cursors : MonoBehaviour
{
	public Inventory inventObj;
	public PaC_walk Player;
	
    public Sprite defaultCursor;
    public Sprite interactCursor;
    public Sprite walkCursor;
    public Sprite pakostCursor;
    public Sprite doorCursor;

	public LayerMask floorLayer;
	public LayerMask grabLayer;
	public LayerMask pakostLayer;
	public LayerMask doorLayer;
	
	private SpriteRenderer spriteRenderer;

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);		
		
         Vector2 mouseWorldPos =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Collider2D hitFloor = Physics2D.OverlapPoint(mouseWorldPos, floorLayer);
		
        Collider2D hitGrab = Physics2D.OverlapPoint(mouseWorldPos, grabLayer);
		
        Collider2D hitPakost = Physics2D.OverlapPoint(mouseWorldPos, pakostLayer);
		
        Collider2D hitDoor = Physics2D.OverlapPoint(mouseWorldPos, doorLayer);
		
		if(hitGrab != null && hitGrab.GetComponent<RoomCheck>().room == Player.inRoom)
		{
			SetInteract();  // курсор рука / взять
		}
		else if(hitFloor != null && hitFloor.GetComponent<RoomCheck>().room == Player.inRoom)
		{
			SetWalk();      // курсор идти
		}
		else if(hitPakost != null && hitPakost.GetComponent<RoomCheck>().room == Player.inRoom)
		{
			SetPakost();
		}
		else if(hitDoor != null && hitDoor.GetComponent<RoomCheck>().room == Player.inRoom)
		{
			SetDoor();
		}
		else
		{
			SetDefault();   // обычный курсор
		}
		
	}

    void Start()
    {
		Cursor.visible = false;
        SetDefault();
    }

    public void SetDefault()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = defaultCursor;
    }

    public void SetInteract()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = interactCursor;
    }
	
    public void SetWalk()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = walkCursor;
    }
	
    public void SetPakost()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = pakostCursor;
    }
	
    public void SetDoor()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = doorCursor;
    }
}