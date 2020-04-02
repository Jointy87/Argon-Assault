using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
	//Cache
	int totalScore;
	Text scoreText;

	void Start()
	{
		scoreText = GetComponent<Text>();
		scoreText.text = totalScore.ToString();
	}
	public void AddToScore(int pointWorth)
	{
		totalScore += pointWorth;
		scoreText.text = totalScore.ToString();
	}
}
