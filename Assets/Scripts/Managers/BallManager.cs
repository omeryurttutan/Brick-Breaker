using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    
    public static BallManager instance;
    public List<Ball> ballList = new List<Ball>();
    

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
        ballList.Clear();
    }
    
    [SerializeField] private Ball ballPrefab;
    
    public void SpawnBall()
    {
        var pos = Platform.instance.transform.position + Vector3.up;
        Ball ball = Instantiate(ballPrefab,pos, Quaternion.Euler(-45f, 90f, 0f));
        ballList.Add(ball);
    }
    
    public void SpawnPowerUpBall(Vector3 hitspawnpos,Quaternion hitspawnrot)
    {
        
        
        Ball ball2 = Instantiate(ballPrefab,hitspawnpos ,hitspawnrot);
        ballList.Add(ball2);
    }

    public void StopBall()
    {
        foreach (var stp in ballList)
        {
            stp.BallSpeed = 0f;
        }
    }

    public void StartBall()
    {
        foreach (var str in ballList)
        {
            str.BallSpeed = 5f;
        }
    }

    public void DestroyBall()
    {
        foreach (var bl in ballList)
        {
            Destroy(bl.gameObject);
        }
        ballList.Clear();
    }

    
}
