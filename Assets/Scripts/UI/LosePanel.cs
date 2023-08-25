using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public MainMenuUI mainMenuUI;
    public void OnClickRetry()
    {
        UIManager.instance.inGameUI.SetActiveLifePanel(true);
        BallManager.instance.SpawnBall();
        LevelManager.instance.LoadLevel();
        Platform.instance.ResetPlatform();
        gameObject.SetActive(false);
    }

    public void LoseMainMenu()
    {
        UIManager.instance.inGameUI.lifePanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
        mainMenuUI.gameObject.SetActive(true);
        Platform.instance.ResetPlatform();
    }
    
    public void SetActiveLosePanel(bool x)
    {
        gameObject.SetActive(x);
    }
}
