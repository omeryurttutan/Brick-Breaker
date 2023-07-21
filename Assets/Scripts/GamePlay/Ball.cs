using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;


public class Ball : MonoBehaviour
{
    public float speed = 1f;
    private void Update()
    {
        var nextPos = transform.forward * (speed * Time.deltaTime);
        
        var ray = new Ray(transform.position, nextPos.normalized);

        if (Physics.SphereCast(ray,0.1f,out RaycastHit hit,nextPos.magnitude))
        {
            var NewPos = Vector3.Reflect(transform.forward, hit.normal);
            transform.forward = NewPos;
        }
        else
        {
            transform.position += nextPos;
       
        }
       


    }

    
}
