using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public Image energyBar;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        GameManager.Instance.uiManager = this;
    }

    public void OnStartGameButton()
    {
        GameManager.Instance.levelChanger.FadeToNextLevel();
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnResumeButton()
    {
        GameManager.Instance.IsPaused = false;
    }

    public void OnMainMenuButton()
    {
        GameManager.Instance.levelChanger.FadeToLevel(0);
    }
}
