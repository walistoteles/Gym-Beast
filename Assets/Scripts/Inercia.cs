using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inercia : MonoBehaviour
{
    public float offset = 0.1f; 
    public float delay = 0.1f; 
    private float timer; 
    private Vector3 targetPosition; 
    public Transform targetPos;

    void Start()
    {
        targetPosition = targetPos.position; 
        timer = 0f; 
    }

    void Update()
    {
        timer += Time.deltaTime; 

        if (timer >= delay)
        {
            targetPosition = targetPos.transform.position + Vector3.down * offset;

            timer = 0f;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
        transform.LookAt(targetPos);
    }
}
