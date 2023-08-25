using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public InGameUI inGameUI;
    public MainMenuUI mainMenuUI;
    
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
