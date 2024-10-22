using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioMusic;
    public AudioSource soundMusic;
    public bool isAudioEnabled;
    public bool isSound;
    public static AudioManager instance;
    public void Awake()
    {
        instance = this;
    }

    public void ToggleAudio(bool enableAudio)
    {
        isAudioEnabled = enableAudio;

        // Bật/tắt nhạc nền
        if (audioMusic != null)
        {
            audioMusic.mute = !isAudioEnabled;
        }

        // Bật/tắt âm thanh hiệu ứng
   
    }
    public void ToggleSound(bool enableSound) {
        isSound = enableSound;
        if (soundMusic != null)
        {
            soundMusic.mute = !isSound;
        }

    }
    /*public List<ListMusic> lstAudioMusic;

    public List<ListSoudFx> lstSoudFX;

   
    [Serializable]
    public class ListMusic
    {
        public string tagName;
        public AudioSource audio;
    }

    [Serializable]
    public class ListSoudFx
    {
        public string tagName;
        public AudioSource audio;
    }*/
}