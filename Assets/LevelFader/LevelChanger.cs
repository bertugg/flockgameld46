using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : FadeController
{
	public bool changeByButtonPress = false;
	public bool changeByTime = false;

	public float time;
	
	private bool isChanging = false;
	private int levelToLoad;


	private void Awake()
	{
		GameManager.Instance.levelChanger = this;
	}

	void Update () {
		if (!isChanging)
		{
			if ((changeByTime && Time.time > time) || // Time Check
			    (changeByButtonPress && Input.anyKeyDown)) // Key Check
				FadeToNextLevel();
		}
	}

	public void FadeToNextLevel ()
	{
		FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void FadeToLevel (int levelIndex)
	{
		isChanging = true;
		levelToLoad = levelIndex;
		
		onFadeOutComplete.RemoveAllListeners();
		onFadeOutComplete.AddListener(ChangeLevel);
		PlayFadeOut(true);
	}

	public void ChangeLevel ()
	{
		Debug.Log("Changing Level");
		SceneManager.LoadScene(levelToLoad);
	}
}
