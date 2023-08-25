using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{ 
    [SerializeField] private GameObject CtnButton;
    

    
    public void Press1()
    {
        Debug.Log("pause");
        BallManager.instance.StopBall();
        gameObject.SetActive(true);
        CtnButton.SetActive(true);
        UIManager.instance.inGameUI.lifePanel.gameObject.SetActive(false);
        //transform.rotation=Quaternion.Euler()
    }


    public void PressCtn()
    {
        Debug.Log("ctn");
        BallManager.instance.StartBall();
        gameObject.SetActive(false);
        CtnButton.SetActive(false);
        UIManager.instance.inGameUI.lifePanel.gameObject.SetActive(true);
    }

    public void BackMenu1()
    { 
        BrickManager.instance.bricksList.Clear();
        LevelManager.instance.DestroyLevel();
        gameObject.SetActive(false);
        UIManager.instance.mainMenuUI.gameObject.SetActive(true);
        BallManager.instance.DestroyBall();
        PowerUpManager.instance.DestroyPowerUp();
        
    }

    public void PressRetry()
    { 
        GameManager.instance.ResetLifeCount();
        UIManager.instance.inGameUI.SetActiveLifePanel(true);
        BrickManager.instance.bricksList.Clear();
        LevelManager.instance.DestroyLevel();
        BallManager.instance.DestroyBall();
        BallManager.instance.SpawnBall();
        LevelManager.instance.LoadLevel();
        Platform.instance.ResetPlatform();
        gameObject.SetActive(false);
        
    }
}
