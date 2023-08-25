using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public  int lifeCount = 3;
   public int initLifeCount;
   
   private void Start()
   {
      initLifeCount = lifeCount;
      UIManager.instance.inGameUI.SetLifeText(lifeCount);
   }

   public void CheckBallList()
   {
      if (BallManager.instance.ballList.Count==0)
      {
         lifeCount--;
         UIManager.instance.inGameUI.SetLifeText(lifeCount);
         if (lifeCount==0)
         {
           UIManager.instance.inGameUI.WhenFail();
         }
         else
         {
            BallManager.instance.SpawnBall();
         }
      }
   }
   

   public void ResetLifeCount()
   {
      lifeCount = initLifeCount;
      UIManager.instance.inGameUI.SetLifeText(lifeCount);
   }
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
}
