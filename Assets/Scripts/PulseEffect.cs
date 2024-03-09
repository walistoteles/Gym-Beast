using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseEffect : MonoBehaviour
{
    public float pulseSpeed = 1.0f; 
    public float minScale = 0.5f; 
    public float maxScale = 1.5f; 

    private Vector3 baseScale; 

    void Start()
    {
        baseScale = transform.localScale; 
    }

    void Update()
    {
        float scale = Mathf.PingPong(Time.time * pulseSpeed, maxScale - minScale) + minScale;

        transform.localScale = baseScale * scale;
    }
}
