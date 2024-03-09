using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Transform cameraTransform; 
    public float shakeDuration = 0.5f; 
    public float shakeMagnitude = 0.7f; 
    public float dampingSpeed = 1.0f; 

    private Vector3 initialPosition; 
    private float shakeTimeRemaining = 0f; 


    public static ScreenShake instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        initialPosition = cameraTransform.localPosition; 
    }

    void Update()
    {
        if (shakeTimeRemaining > 0)
        {
            cameraTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeTimeRemaining -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeTimeRemaining = 0f;
            cameraTransform.localPosition = initialPosition;
        }
    }

    public void StartShake()
    {
        shakeTimeRemaining = shakeDuration;
    }
}
