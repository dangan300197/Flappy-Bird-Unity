using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	public Sprite[] sprites; // tao mot list cac hinh anh dung de lam animation

	private int spriteIndex;

	private Vector3 direction;

	public float gravity = -9.8f;

	public float strength = 5f;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // các hình ảnh tạo hiệu ứng chuyển động

	}

	private void OnEnable()
	{
		Vector3 position = transform.position;
		position.y = 0f;
		transform.position = position;
		direction = Vector3.zero;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			direction = Vector3.up * strength; // điều khiển nhân vật bằng space hoặc chuột trái
		}

		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Began)
			{
				direction = Vector3.up * strength; // dung cac ngon tay cam ung tren dien thoai
			}
		}

		direction.y += gravity * Time.deltaTime; // áp dụng trọng lực lên nhân vật mọi lúc

		transform.position += direction * Time.deltaTime; // cập nhật vị trí hiện tại của nhân vật
	}

	void AnimateSprite()
	{
		spriteIndex++;
		if(spriteIndex >= sprites.Length) // các hình ảnh chạy theo thứ tự tạo hình ảnh chuyển động
		{
			spriteIndex = 0;
		}
		spriteRenderer.sprite = sprites[spriteIndex];
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Obstacle")
		{
			FindAnyObjectByType<GameManager>().GameOver(); // nếu xảy ra va chạm dừng trò chơi
		}
		else if(collision.gameObject.tag == "Scoring")
		{
			FindAnyObjectByType<GameManager>().IncreaseScore(); // tăng điểm
		}

	}
}
