using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public MainMenuUI mainMenuUI;

    public void SetActiveWin()
    {
        
    }
    public void ClickNextLevel()
    {
        UIManager.instance.inGameUI.lifePanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
        LevelManager.instance.DestroyLevel();
        BallManager.instance.DestroyBall();
        PowerUpManager.instance.DestroyPowerUp();
        LevelManager.instance.NextLevel();
        Platform.instance.ResetPlatform();
        GameManager.instance.ResetLifeCount();
        
    }

    public void ClickMainMenu()
    {
        UIManager.instance.inGameUI.lifePanel.gameObject.SetActive(true);
        GameManager.instance.ResetLifeCount();
        gameObject.SetActive(false);
        mainMenuUI.gameObject.SetActive(true);
        LevelManager.instance.DestroyLevel();
        PowerUpManager.instance.DestroyPowerUp();
        BallManager.instance.DestroyBall();
        Platform.instance.ResetPlatform();
        
    }
}
