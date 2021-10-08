using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    
    //Configuration Parameters
    [Header("General Configurations")]
    [Tooltip("Set how fast the player's ship moves up and down.")][SerializeField] float _controlsSpeed = 20f;
    [Tooltip("Set how far the player's ship can go on the X Axis.")][SerializeField] float _xRange = 3f;
    [Tooltip("Set how far the player's ship can go on the Y Axis.")][SerializeField] float _yRange = 5f;

    [Header("Screen Position Based Tuning")]
    [SerializeField] float _positionPitchFactor = -2f;
    [SerializeField] float _positionYawFactor = -10f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float _controlPitchFactor = -20f;
    [SerializeField] float _controlRollFactor = -40f;

    float xThrow, yThrow;

    //Cached References
    [Header("Laser Gun Array")]
    [Tooltip("Add all player lasers here.")][SerializeField] ParticleSystem[] _lasers;

    //Input Management
    [Header("Input Management")]
    [SerializeField] InputAction _movement;
    [SerializeField] InputAction _firing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        _movement.Enable();
        _firing.Enable();
    }

    private void OnDisable()
    {
        _movement.Disable();
        _firing.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessTranslation()
    {
         xThrow = _movement.ReadValue<Vector2>().x;
         yThrow = _movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * _controlsSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -_xRange, _xRange);

        float yOffset = yThrow * _controlsSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -_yRange, _yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * _positionPitchFactor;
        float pitchDueToControlThrow = yThrow * _controlPitchFactor;
        float yawDeutToPosition = transform.localPosition.x * _positionYawFactor;
        float rollDueToControlThrow = xThrow * _controlRollFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow,
              yaw = yawDeutToPosition,
              roll = rollDueToControlThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring()
    {
        if (_firing.ReadValue<float>() > 0.5)
        {
            SetLasersActive(true);
        }

        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool setActive)
    {
        foreach (var laser in _lasers)
        {
            var emissionModule = laser.emission;
            emissionModule.enabled = setActive;
        }
    }

}
