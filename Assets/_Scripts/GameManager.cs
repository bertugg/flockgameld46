using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public LevelChanger levelChanger;
    public AudioManager audioManager;
    public UIManager uiManager;
    public CameraManager cameraManager;
    public LevelManager levelManager;

    private int playerLevel;
    private bool _isControllerOpen = false;
    public float sleepAmount;

    public bool IsControllerOpen
    {
        set
        {
            _isControllerOpen = value;
        }
        get { return _isControllerOpen; }
    }

    private int _score = 0;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            uiManager.scoreText.text = value + "";
        }
    }


    private float _energy = 100;
    public float Energy
    {
        get { return _energy; }
        set
        {
            _energy = value;
            uiManager.energyBar.fillAmount = value;
        }
    }

    private bool _isPaused = false;
    public bool IsPaused
    {
        set
        {
            _isPaused = value;
            uiManager.pauseMenu.SetActive(value);
            _isControllerOpen = !value;
        }
        get { return _isPaused; }
    }

    private void Start()
    {
        DefaultSettings();
    }

    private void DefaultSettings()
    {
        //Default settings
        playerLevel = 1;
        IsControllerOpen = false;
        sleepAmount = 0;
    }
    
}