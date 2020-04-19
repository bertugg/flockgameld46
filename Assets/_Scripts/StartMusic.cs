﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.audioManager.Play(FlockAudioManager.AudioName.MainMenuMusic);
    }
}