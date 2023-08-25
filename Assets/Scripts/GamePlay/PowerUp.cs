using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public float powerUpSpeed;
    private float initSpeed;
    public new Renderer renderer;
   

    private void Start()
    {
        initSpeed = powerUpSpeed;
    }

    private void Update()
    {
        
        var nextDir = -transform.up * (powerUpSpeed * Time.deltaTime);
        
        var ray = new Ray(transform.position, nextDir.normalized);
        if (Physics.SphereCast(ray, 0.1f, out RaycastHit hit, nextDir.magnitude))
        {
            transform.position = hit.point + (hit.normal * (transform.localScale.x * 0.5f));

            if (hit.collider.TryGetComponent(out Platform platform))
            {
            
                if ( powerUpType == PowerUpType.BallSplit)
                {
                    BallManager.instance.SpawnPowerUpBall(transform.position,Quaternion.Euler(-50,90,0)); 
                    BallManager.instance.SpawnPowerUpBall(transform.position,Quaternion.Euler(-80,90,0));
                    BallManager.instance.SpawnPowerUpBall(transform.position,Quaternion.Euler(-110,90,0));
                    PowerUpManager.instance.PowerUpList.Remove(this);
                    Destroy(gameObject);
                }
                
                if ( powerUpType == PowerUpType.LifeUp)
                {
                    GameManager.instance.lifeCount++;
                    UIManager.instance.inGameUI.SetLifeText(GameManager.instance.lifeCount);
                    PowerUpManager.instance.PowerUpList.Remove(this);
                    Destroy(gameObject);
                }

                

            }

            if (hit.collider.TryGetComponent(out Ground ground))
            {
                PowerUpManager.instance.PowerUpList.Remove(this);
                Destroy(gameObject);
            }
            
            if (hit.collider.TryGetComponent(out Brick brick))
            {
                BrickManager.instance.bricksList.Remove(brick);
                Destroy(brick.gameObject);
                
            }

            


        }
        else
        {
            transform.position += nextDir;
       
        }
    }

    public void Resume()
    {
        powerUpSpeed = initSpeed;
    }
    public void Stop()
    {
        powerUpSpeed = 0;
    }

    public void SetColor(Color color)
    {
        renderer.material.color = color;
    }
}




