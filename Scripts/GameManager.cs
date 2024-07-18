using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	private int score;

	public TMP_Text scoreText;

	public Player player;

	public GameObject playButton;

	public GameObject gameOver;

	private void Awake()
	{
		if (Instance != null)
		{
			DestroyImmediate(gameObject);
		}
		else
		{
			Instance = this;
			Application.targetFrameRate = 60;
			DontDestroyOnLoad(gameObject);
			Pause();
		}
	}
	public void Play()
	{
		score = 0;
		scoreText.text = score.ToString();

		gameOver.SetActive(false);
		playButton.SetActive(false);

		Time.timeScale = 1f;
		player.enabled = true;

		Pipes[] pipes = FindObjectsOfType<Pipes>();
		for(int i = 0; i < pipes.Length; i++)
		{
			Destroy(pipes[i].gameObject);
		}
	}
	public void Pause()
	{
		Time.timeScale = 0f;
		player.enabled = false;
	}
	public void GameOver()
	{
		Debug.Log("Game Over");

		gameOver.SetActive(true);
		playButton.SetActive(true);

		Pause();
	}

	public void IncreaseScore()
	{
		score++;
		scoreText.text = score.ToString();
		Debug.Log("Scoring");
	}
}
