using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform alvo; 
    public Vector3 offset; 

    void LateUpdate()
    {
        if (alvo != null)
        {
            transform.position = alvo.position + offset;
        }
    }
}
