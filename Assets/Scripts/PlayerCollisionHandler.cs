using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
	[SerializeField] GameObject deathFX;
	private void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
	}

	private void StartDeathSequence()
	{
		GetComponent<PlayerController>().SetAliveToFalse();
		TriggerDeathFX();
		DestroyShip();
		Invoke("FetchRestartGame", 2f);

	}

	private void TriggerDeathFX()
	{
		GameObject explosionFX = Instantiate(deathFX, transform.position, Quaternion.identity);
		Destroy(explosionFX, 1f);
	}

	private void DestroyShip()
	{
		foreach (Transform child in transform)
		{
			GameObject.Destroy(child.gameObject);
		}

		GetComponent<CapsuleCollider>().enabled = false;
	}

	private void FetchRestartGame()
	{
		FindObjectOfType<LevelLoader>().RestartGame();
	}
}