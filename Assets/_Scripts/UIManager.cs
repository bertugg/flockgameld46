using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void OnStartGameButton()
    {
        ((LevelChanger)GameManager.Instance.fadeController).FadeToNextLevel();
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
