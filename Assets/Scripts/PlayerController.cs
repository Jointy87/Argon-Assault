using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//Parameters
	[Header("Movement")]
	[Tooltip("Horizontal movement speed")] [SerializeField] float xSpeed = 16f;
	[Tooltip("Vertical movement speed")] [SerializeField] float ySpeed = 14f;
	[Tooltip("Horizontal movement range")] [SerializeField] float xMoveRange = 9f;
	[Tooltip("Vertical movement range")] [SerializeField] float yMoveRange = 5.5f;

	[Header("Rotation")]
	[Tooltip("Pitch per position on screen")] [SerializeField] float positionPitchFactor = -5f;
	[Tooltip("Yaw per position on screen")] [SerializeField] float positionYawFactor = 5f;
	[Tooltip("Pitch while moving")] [SerializeField] float movementPitchFactor = -20f;
	[Tooltip("Yaw while moving")] [SerializeField] float movementRollFactor = -25f;

	[Header("Firing")]
	[SerializeField] ParticleSystem[] bulletEmitters;
	
	//Cache
	Rigidbody rb;

	//States
	bool isAlive;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		isAlive = true;
	}

	void Update()
	{
		if(isAlive)
		{
			ProcessMovement();
			ProcessRotation();
			ProcessFiring();
		}
	}

	private void ProcessRotation()
	{
		float positionPitch = transform.localPosition.y * positionPitchFactor;
		float positionYaw = transform.localPosition.x * positionYawFactor;
		
		float movementPitch = Input.GetAxis("Vertical") * movementPitchFactor;
		float movementRoll = Input.GetAxis("Horizontal") * movementRollFactor;

		float pitch = positionPitch + movementPitch;
		float yaw = positionYaw;
		float roll = movementRoll;

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void ProcessMovement()
	{
		float xOffset = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
		float yOffset = Input.GetAxis("Vertical") * ySpeed * Time.deltaTime;

		float newXPos = transform.localPosition.x + xOffset;
		float newYPos = transform.localPosition.y + yOffset;

		transform.localPosition = new Vector3 (Mathf.Clamp(newXPos, -xMoveRange, xMoveRange), 
			Mathf.Clamp(newYPos, -yMoveRange, yMoveRange), transform.localPosition.z);
	}
	
	private void ProcessFiring()
	{
		foreach (ParticleSystem emitter in bulletEmitters)
		{
			if(Input.GetAxis("Jump") >= 1)
			{
				var emissionModule = emitter.emission;
				emissionModule.enabled = true;
			}
			else
			{
				var emissionModule = emitter.emission;
				emissionModule.enabled = false;
			}
		}
	}

	public void SetAliveToFalse()
	{
		isAlive = false;
	}
}
