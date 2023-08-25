using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(this);
        }
       
    }

    public void SetPos(float deltaX)
    {
        var newPos = transform.position + Vector3.right * deltaX;
        if (newPos.x> 2.13f )
        {
            newPos = new Vector3(2.13f, newPos.y, newPos.z);
        }
        
        if (newPos.x< -2.11 )
        {
            newPos = new Vector3(-2.11f, newPos.y, newPos.z);
        }
        transform.position = newPos;
    }

    public void ResetPlatform()
    {
        transform.position = new Vector3(0,-1.7f,0);
    }
}
