using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform deathFXParent;

    private void Start()
    {
        AddBoxCollider();
    }

    private void AddBoxCollider()
    {
        BoxCollider newBoxCollider = gameObject.AddComponent<BoxCollider>();
    }

    private void OnParticleCollision(GameObject other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        TriggerDeathFX();
        DestroyShip();
    }

    private void TriggerDeathFX()
    {
        GameObject explosionFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        explosionFX.transform.parent = deathFXParent;
        Destroy(explosionFX, 1f);
    }
    private void DestroyShip()
    {
        Destroy(gameObject);
    }

    
}
