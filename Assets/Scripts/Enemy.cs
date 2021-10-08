using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _increaseScoreAmount = 10;
    [SerializeField] int _hitPoints = 3;

    [SerializeField] ParticleSystem _explosionParticles;
    [SerializeField] ParticleSystem _hitParticles;

    Rigidbody _rb;

    MeshRenderer _meshRenderer;

    private void Awake()
    {
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        _rb = gameObject.AddComponent<Rigidbody>();
        _rb.useGravity = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (_hitPoints < 1)
        {
            DestroyEnemy();
        }
    }

    private void ProcessHit()
    {
        _hitPoints--;
        Debug.Log($"Hitpoints Left: {_hitPoints}");
        Score.instance.IncreaseScore(_increaseScoreAmount);
        _hitParticles.Play();
    }

    private void DestroyEnemy()
    {
        _explosionParticles.Play();
        Destroy(gameObject, 0.5f);
    }

    
}
