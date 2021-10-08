using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.name);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit " + other.gameObject.name);
    }
}
