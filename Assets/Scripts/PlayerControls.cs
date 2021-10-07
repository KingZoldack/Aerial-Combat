using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]
    InputAction _movement;

    [SerializeField]
    float _controlsSpeed = 5f, _xRange = 5f, _yRange = 5f, _positionPitchFactor = -2f, _controlPitchFactor = -10f, _positionYawFactor = -10f, _controlRollFactor = -10f;

    float xThrow, yThrow;

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
        ProcessTranslation();
        ProcessRotation();
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
}
