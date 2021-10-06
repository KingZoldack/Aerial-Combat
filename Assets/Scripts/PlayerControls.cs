using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    InputAction _movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _movement.Enable(); 
    }

    private void OnDisable()
    {
        _movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = _movement.ReadValue<Vector2>().x;
        float verticalThrow = _movement.ReadValue<Vector2>().y;

        Debug.Log("H: " + horizontalThrow);
        Debug.Log("V: " + verticalThrow);
    }
}
