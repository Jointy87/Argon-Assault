using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
	//Parameters
	[Tooltip("The amount of health the object has")][SerializeField] int healthPoints;

	//Cache
	int currentHealth;

	private void Start()
	{
		currentHealth = healthPoints;
	}

	public void SubstractHealth()
	{
		currentHealth--;
	}
	public int FetchHealth()
	{
		return currentHealth;
	}
}
