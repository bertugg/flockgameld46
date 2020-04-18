using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelContainer;
    [SerializeField] private GameObject[] levelsPrefab;
    private GameObject currentLevel;
    private GameObject dog;

    private void Start()
    {
        GameManager.Instance.levelManager = this;
        StartGame();
    }
    private void StartGame()
    {
        LoadLevel(0);
        GameManager.Instance.IsControllerOpen = true;
    }

    public void LoadLevel(int _levelIndex)
    {
        ClearContainer();//Clear previous level
        currentLevel = null;
        if (_levelIndex < levelsPrefab.Length)
            currentLevel = Instantiate(levelsPrefab[_levelIndex], levelContainer.transform);
        else
        {
            _levelIndex %= levelsPrefab.Length;
            currentLevel = Instantiate(levelsPrefab[_levelIndex], levelContainer.transform);
        }

        for (int i = 0; i < currentLevel.transform.GetChild(1).childCount; i++)
        {
            if (currentLevel.transform.GetChild(1).GetChild(i).gameObject.tag == "Player")
            {
                dog = currentLevel.transform.GetChild(1).GetChild(i).gameObject;
            }
        }

        GameManager.Instance.cameraManager.SetTarget(dog);
    }

    private void ClearContainer()
    {
        for (int i = 0; i < levelContainer.transform.childCount; i++)
        {
            Destroy(levelContainer.transform.GetChild(i).gameObject);
        }
    }

}
