using UnityEngine;

public class FlockAudioManager : AudioManager
{
    public enum AudioName
    { 
        //SFX
        SheepBah, 
        DogBark,
        Grass,
        DyingSheep,
        Wolf,
        CountdownTimer,
        Snoring, 
        ButtonClick,
        LevelFail, 
        LevelWin,
        SheepDisease,
        SheepHealed,

        // Music
        GameplayMusic,
        MainMenuMusic,
        
        //Ambient
        NatureAmbient,
        CloseEyesAmbient
    }
    
    #region AudioList

    //SFX
    public Audio SheepBah;
    public Audio DogBark;
    public Audio Grass;
    public Audio DyingSheep;
    public Audio Wolf;
    public Audio CountdownTimer;
    public Audio Snoring;
    public Audio ButtonClick;
    public Audio LevelFail;
    public Audio LevelWin;
    public Audio SheepDisease;
    public Audio SheepHealed;

    // Music
    public Audio GameplayMusic;
    public Audio MainMenuMusic;
        
    //Ambient
    public Audio NatureAmbient;
    public Audio CloseEyesAmbient;

    #endregion

    void Awake()
    {
        if (GameManager.Instance.audioManager != null) // Singleton-alike behaviour
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);

            GameManager.Instance.audioManager = this;
        
            soundMixer.audioMixer.SetFloat("SoundVolume", PlayerPrefs.GetFloat("SoundVolume",1));
            musicMixer.audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume",1));
        }
    }

    public void Play(AudioName name)
    {
        switch (name)
        {
            case AudioName.SheepBah: Play(SheepBah); break;
            case AudioName.DogBark: Play(DogBark); break;
            case AudioName.Grass: Play(Grass); break;
            case AudioName.DyingSheep: Play(DyingSheep); break;
            case AudioName.Wolf: Play(Wolf); break;
            case AudioName.CountdownTimer: Play(CountdownTimer); break;
            case AudioName.Snoring: Play(Snoring); break;
            case AudioName.ButtonClick: Play(ButtonClick); break;
            case AudioName.LevelFail: Play(LevelFail); break;
            case AudioName.LevelWin: Play(LevelWin); break;
            case AudioName.SheepDisease: Play(SheepDisease); break;
            case AudioName.SheepHealed: Play(SheepHealed); break;
            case AudioName.GameplayMusic: Play(GameplayMusic); break;
            case AudioName.MainMenuMusic: Play(MainMenuMusic); break;
            case AudioName.NatureAmbient: Play(NatureAmbient); break;
            case AudioName.CloseEyesAmbient: Play(CloseEyesAmbient); break;
        }
    }
    
    public void Stop(AudioName name)
    {
        switch (name)
        {
            case AudioName.SheepBah: Stop(SheepBah); break;
            case AudioName.DogBark: Stop(DogBark); break;
            case AudioName.Grass: Stop(Grass); break;
            case AudioName.DyingSheep: Stop(DyingSheep); break;
            case AudioName.Wolf: Stop(Wolf); break;
            case AudioName.CountdownTimer: Stop(CountdownTimer); break;
            case AudioName.Snoring: Stop(Snoring); break;
            case AudioName.ButtonClick: Stop(ButtonClick); break;
            case AudioName.LevelFail: Stop(LevelFail); break;
            case AudioName.LevelWin: Stop(LevelWin); break;
            case AudioName.SheepDisease: Stop(SheepDisease); break;
            case AudioName.SheepHealed: Stop(SheepHealed); break;
            case AudioName.GameplayMusic: Stop(GameplayMusic); break;
            case AudioName.MainMenuMusic: Stop(MainMenuMusic); break;
            case AudioName.NatureAmbient: Stop(NatureAmbient); break;
            case AudioName.CloseEyesAmbient: Stop(CloseEyesAmbient); break;
        }
    }
}
