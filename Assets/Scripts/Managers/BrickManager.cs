using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    
    public static BrickManager instance;
    public List<Brick> bricksList = new List<Brick>();

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
        bricksList.Clear();
    }

    public void CheckLevelEnd()
    {
        if (bricksList.Count==0)
        {
            BallManager.instance.StopBall();
            UIManager.instance.inGameUI.winPanel.gameObject.SetActive(true);
            UIManager.instance.inGameUI.lifePanel.gameObject.SetActive(false);
        }
    }
}

    

