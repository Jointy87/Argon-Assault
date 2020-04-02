using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
	//Parameters
	[SerializeField] GameObject deathFX;
	[Tooltip("The parent under which the deathFX will spawn during Runtime")]
	[SerializeField] Transform deathFXParent;
	[Tooltip("The amount of points scored upon destruction")] [SerializeField] int pointWorth;

	//Cache
	bool isAlive;
	private void Start()
	{
		isAlive = true;
		AddBoxCollider();
	}

	private void AddBoxCollider()
	{
		BoxCollider newBoxCollider = gameObject.AddComponent<BoxCollider>();
	}

	private void OnParticleCollision(GameObject other)
	{
		while (isAlive) //To avoid counting double score if being hit by both lasers
		{
			StartDeathSequence();
			isAlive = false;
		}
	}

	private void StartDeathSequence()
	{
		TriggerDeathFX();
		SendScoreToCounter();
		DestroyShip();
	}

	private void TriggerDeathFX()
	{
		GameObject explosionFX = Instantiate(deathFX, transform.position, Quaternion.identity);
		explosionFX.transform.parent = deathFXParent;
		Destroy(explosionFX, 1f);
	}
	private void SendScoreToCounter()
	{
		FindObjectOfType<ScoreCounter>().AddToScore(pointWorth);
	}
	private void DestroyShip()
	{
		Destroy(gameObject);
	}

	
}
