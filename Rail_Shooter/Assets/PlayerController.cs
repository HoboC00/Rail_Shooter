using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{   [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 5f;
    [Tooltip("In m")] [SerializeField] float yRange = 3f;
    [SerializeField]  GameObject[] guns ;

    [Header("Screen-position Based")]
    [SerializeField]  float positionPitchFactor = -5f;
    [SerializeField]  float positionYawFactor = 5f;


    [Header("Control-Throw Based")]
    [SerializeField]  float controlPitchFactor = -20f;
    [SerializeField]  float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlEnabled = true;


    // Start is called before the first frame update 




    // Update is called once per frame


    void Update()
    {

        if (isControlEnabled )
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
            
        
    }
    void OnPlayerDeath()
    {
        isControlEnabled = false;
    }



    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Speed * Time.deltaTime;
        float yOffset = yThrow * Speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }
    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }

    }


}
