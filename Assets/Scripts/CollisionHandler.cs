using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    //Config Params
    [SerializeField] float _loadDelay = 1.5f;
    [SerializeField] MeshRenderer[] _playerMeshRenderers;

    //Cached Refs.
    [SerializeField] ParticleSystem _explosionParticles;

    private void Awake()
    {
        _playerMeshRenderers = GetComponentsInChildren<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        CrashHandler();
    }

    private void OnCollisionEnter(Collision other)
    {
        CrashHandler();
    }

    void CrashHandler()
    {
        PlayerControls.instance.TriggerMovement();
        _explosionParticles.Play();
        DisableMeshes();
        Invoke("ReloadLevel", _loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void DisableMeshes()
    {
        foreach (var mesh in _playerMeshRenderers)
        {
            mesh.enabled = false;
        }
    }
}
