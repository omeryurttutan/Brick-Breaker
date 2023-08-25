using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public PowerUp powerUp;
    public TextMeshProUGUI lifeCountText;
    public static InGameUI instance;
    public LosePanel losePanel;
    public LifePanel lifePanel;
    public WinPanel winPanel;
    public TextMeshProUGUI LevelCountText;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetLifeText(int lifeCount)
    {
        lifeCountText.text = lifeCount.ToString();
    }

    public void SetActiveLifePanel(bool isActive)
    {
        lifePanel.gameObject.SetActive(isActive);
    }

    public void SetLevelCountText()
    {
        LevelCountText.text = "LEVEL "+LevelManager.instance.currentLevelIndexPlus; 
    }
    public void WhenFail()
    {
        UIManager.instance.inGameUI.SetActiveLifePanel(false);
        losePanel.SetActiveLosePanel(true);
        GameManager.instance.ResetLifeCount();
        BrickManager.instance.bricksList.Clear();
        BallManager.instance.DestroyBall();
        PowerUpManager.instance.DestroyPowerUp();
        LevelManager.instance.DestroyLevel();
    }
}