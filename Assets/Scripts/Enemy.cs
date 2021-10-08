using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionParticles;

    MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnParticleCollision(GameObject other)
    {
        _explosionParticles.Play();
        _meshRenderer.enabled = false;
        Destroy(gameObject, 1f);
    }
}
