using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject levelContainer;
    [SerializeField] private GameObject[] levelsPrefab;
    private GameObject currentLevel;

    private void Start()
    {
        GameManager.Instance.levelManager = this;
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

        for (int i = 0; i < currentLevel.transform.GetChild(0).childCount; i++)
        {
            /*
            if (currentLevel.transform.GetChild(0).GetChild(i).gameObject.tag == "Ragdoll")
            {
                curentLevelRagdollCount++;
            }
            */
        }
    }

    private void ClearContainer()
    {
        for (int i = 0; i < levelContainer.transform.childCount; i++)
        {
            Destroy(levelContainer.transform.GetChild(i).gameObject);
        }
    }
}
