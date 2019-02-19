using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 4f;
    [SerializeField] float xRange = 4f;
    [SerializeField] float yRange = 2.4f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -10f;
    [SerializeField] float controlPitchFactor = -20f;

    [Header("Control-Throw Based")]
    [SerializeField] float positionYawFactor = 8f;

    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isPlayerAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAlive)
        {
            moveShipInX();
            moveShipInY();
            processRotation();
        }
        
    }

    void OnPlayerDeath() //called by CollisionHandler
    {
        print("controls frozen");
        isPlayerAlive = false;
    }

    private void processRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        //float yawDueToPosition = xThrow * positionYawFactor;
        float yaw = yawDueToPosition;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void moveShipInX()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // This is between 0 and 1, static and fully sideway
        float xOffset = xThrow * Speed * Time.deltaTime; // 0-1 * 4 * time since current and last frame
        float rawNewXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);


        transform.localPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void moveShipInY()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical"); // This is between 0 and 1, static and fully up/down
        float yOffset = yThrow * Speed * Time.deltaTime; // 0-1 * 4 * time since current and last frame
        float rawNewYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);


        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
    }

    
}
