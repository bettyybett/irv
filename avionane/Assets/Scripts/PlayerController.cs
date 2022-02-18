using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    //[SerializeField] InputAction movement;

    [SerializeField] float xRange = 2f;
    [SerializeField] float yRange = 2f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -40f;
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float controlRollFactor = 5f;
    [SerializeField] GameObject laser;

    float xThrow;
    float yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*void OnEnable()
    {
        movement.Enable();

    }
    void OnDisable()
    {
        movement.Disable();

    }*/
    void Update()
    {
        MovingPlayerTranslation();
        MovingPlayerRotation();
        ProcessFiring();
    }
    // Update is called once per frame
    void MovingPlayerRotation()
    {
        
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor; //tipuri de rotatie
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    void MovingPlayerTranslation()
    {
        // float xThrow = movement.ReadValue<Vector2>().x;
        //float yThrow = movement.ReadValue<Vector2>().y;
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;

        float newXpos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXpos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float newYpos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYpos, -yRange, yRange);

        transform.localPosition = new Vector3(
            clampedXPos,
            clampedYPos,
            transform.localPosition.z);
    }

    void ProcessFiring()
    {
        //cand apasam pe left shift va trage
        if(Input.GetButton("Fire3"))
        {
            ActivateLaser();
        }
        else
        {
            DeactivateLaser();
        }
    }

    void ActivateLaser()
    {

        laser.SetActive(true);

    }

    void DeactivateLaser()
    {

        laser.SetActive(false);

    }

}
