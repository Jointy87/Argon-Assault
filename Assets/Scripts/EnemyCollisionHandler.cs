using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
	//Parameters
	[SerializeField] GameObject deathFX;
	[SerializeField] GameObject hitFX;
	[Tooltip("The parent under which the deathFX will spawn during Runtime")]
	[SerializeField] Transform parentFX;
	[Tooltip("The amount of points scored upon destruction")] [SerializeField] int pointWorth;

	//Cache
	bool isAlive;
	HealthCounter healthCounter;
	int currentHealth;
	private void Start()
	{
		isAlive = true;
		healthCounter = GetComponent<HealthCounter>();
		AddBoxCollider();
	}

	private void AddBoxCollider()
	{
		BoxCollider newBoxCollider = gameObject.AddComponent<BoxCollider>();
	}

	private void OnParticleCollision(GameObject other)
	{
		if (healthCounter.FetchHealth() <= 0)
		{
			while (isAlive) //To avoid counting double score if being hit by both lasers
			{
				StartDeathSequence();
				isAlive = false;
			}
		}
		else
		{
			healthCounter.SubstractHealth();
			TriggerHitFX();
		}
	}

	private void StartDeathSequence()
	{
		TriggerDeathFX();
		SendScoreToCounter();
		DestroyShip();
	}

	private void TriggerDeathFX() //todo fix bug where explosion sound doesn't seem to be playing on enemies
	{
		GameObject explosionFX = Instantiate(deathFX, transform.position, Quaternion.identity);
		explosionFX.transform.parent = parentFX;
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

	private void TriggerHitFX()
	{
		GameObject smallExplosionFX = Instantiate(hitFX, transform.position, Quaternion.identity);
		smallExplosionFX.transform.parent = parentFX;
		Destroy(smallExplosionFX, 1f);
	}
}
