using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void ClickPlay()
    {
        LevelManager.instance.currentLevelIndex = 0;
        LevelManager.instance.currentLevelIndexPlus = 1;
        InGameUI.instance.SetLevelCountText();
        UIManager.instance.inGameUI.lifePanel.gameObject.SetActive(true);
        BallManager.instance.SpawnBall();
        LevelManager.instance.LoadLevel();
        GameManager.instance.ResetLifeCount();
        gameObject.SetActive(false);
    }
}