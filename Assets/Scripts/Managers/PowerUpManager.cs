using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpManager : MonoBehaviour
{

   
    public static PowerUpManager instance;
    public List<PowerUp> PowerUpList = new List<PowerUp>();

    
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
    [SerializeField] private PowerUp powerUp;
    //[SerializeField] private PowerUp lifeUp;
    public void SpawnPowerUp(PowerUpType type, Vector3 pos)
    {
        PowerUp pUp = Instantiate(powerUp, pos, Quaternion.identity);
        PowerUpList.Add(pUp);
        pUp.powerUpType = type;
        
        if (type == PowerUpType.BallSplit)
        {
            pUp.SetColor(Color.red);
        }
        else if (type == PowerUpType.LifeUp)
        {
            pUp.SetColor(Color.cyan);
        }
        
    }

    public void ResumePowerUp()
    {
        foreach (var powerUp in PowerUpList)
        {
            powerUp.Resume();
        }
        
    }


    public void StopPowerUp()
    {
        foreach (var powerUp in PowerUpList)
        {
            powerUp.Stop();
        }
    }

    public void DestroyPowerUp()
    {
        foreach (var i in PowerUpManager.instance.PowerUpList)
        {
            
            Destroy(i.gameObject);
        }
        PowerUpList.Clear();
    }
    
   
    
    
    
    
}

public enum PowerUpType
{
    None=0,
    BallSplit=1,
    LifeUp=2
}