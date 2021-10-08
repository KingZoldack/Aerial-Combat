using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _increaseScoreAmount = 10;

    [SerializeField] ParticleSystem _explosionParticles;

    MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        DestroyEnemy();
    }

    private void ProcessHit()
    {
        Score.instance.IncreaseScore(_increaseScoreAmount);
    }

    private void DestroyEnemy()
    {
        _explosionParticles.Play();
        _meshRenderer.enabled = false;
        Destroy(gameObject, 1f);
    }

    
}
