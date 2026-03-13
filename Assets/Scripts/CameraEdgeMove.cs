using UnityEngine;

public class CameraEdgeMove : MonoBehaviour
{
    public float speed = 5f;          // скорость камеры
    public float edgeSize = 20f;      // зона у края экрана (в пикселях)
	public bool isLevelEnd;
	public Transform player;

    // Границы камеры
    public float minX, maxX, minY, maxY;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
		if(!isLevelEnd){
			Vector3 pos = transform.position;

			Vector3 mousePos = Input.mousePosition;

			// Левая граница
			if (mousePos.x <= edgeSize)
				pos.x -= speed * Time.deltaTime;

			// Правая граница
			if (mousePos.x >= Screen.width - edgeSize)
				pos.x += speed * Time.deltaTime;

			// Нижняя граница
			if (mousePos.y <= edgeSize)
				pos.y -= speed * Time.deltaTime;

			// Верхняя граница
			if (mousePos.y >= Screen.height - edgeSize)
				pos.y += speed * Time.deltaTime;

			// Ограничиваем движение
			pos.x = Mathf.Clamp(pos.x, minX, maxX);
			pos.y = Mathf.Clamp(pos.y, minY, maxY);

			transform.position = pos;
		}else if (isLevelEnd)
		{
			Vector3 target = player.position;
			target.z = transform.position.z; // ⛔ игнорируем Z

			transform.position = Vector3.MoveTowards(
				transform.position,
				target,
				speed * Time.deltaTime
			);
		}
    }
}
