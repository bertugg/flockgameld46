using System;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup soundMixer, musicMixer;
    public AudioSource musicSource, ambientSource;
    private void Start()
    {
        GameManager.Instance.audioManager = this;
    }
    public enum AUDIOTYPE
    {
        SOUND,
        MUSIC,
        AMBIENT
    }

    protected void Play(Audio audio)
    {
        if (audio.type == AUDIOTYPE.MUSIC)
        {
            if (musicSource.clip != audio.clip)
            {
                musicSource.clip = audio.clip;
                musicSource.volume = audio.volume;
                musicSource.pitch = audio.pitch;
                musicSource.Play();            
            }
        }
        else if (audio.type == AUDIOTYPE.AMBIENT)
        {
            if (ambientSource.clip != audio.clip)
            {
                ambientSource.clip = audio.clip;
                ambientSource.volume = audio.volume;
                ambientSource.pitch = audio.pitch;
                ambientSource.Play();              
            }
        }
        else if (audio.source)
        {
            audio.source.Play();
        }
        else
        {            
            createSource(audio).Play();
        }
    }

    protected void Stop(Audio audio, bool destroySound = false)
    {
        if(audio.source) audio.source.Stop();
        if(destroySound) DestroySource(audio);

    }

    protected void DestroySource(Audio audio)
    {
        Destroy(audio.source);
    }
    
    private AudioSource createSource(Audio audio)
    {
        audio.source = gameObject.AddComponent<AudioSource>();
        audio.source.clip = audio.clip;
        if (audio.type == AUDIOTYPE.SOUND)
        {
            audio.source.outputAudioMixerGroup = soundMixer;
            audio.source.loop = false;
        }
        else // if sound.type == AUDIOTYPE.MUSIC
        {
            audio.source.outputAudioMixerGroup = musicMixer;
            audio.source.loop = true;
        }
        audio.source.volume = audio.volume;
        audio.source.pitch = audio.pitch;
        return audio.source;
    }
}
