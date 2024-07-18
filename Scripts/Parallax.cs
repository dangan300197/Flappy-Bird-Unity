using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	private MeshRenderer m_Renderer;
	public float animationSpeed = 1f;
 	private void Awake()
	{
		m_Renderer = GetComponent<MeshRenderer>();

	}

	private void Update() // cập nhật chuyển động của nền và mặt đất
	{
		m_Renderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0); 

	}
}
