using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanager : MonoBehaviour
{
    public static Datamanager Instance;
    public SpriteManager spriteManager;
    public int Score
    {
        get
        {
            return GetScore();
        }
        set
        {
            SetScore(value);
        }
    }
    public int idPlayer
    {
        get
        {
            return GetIdPlayer();
        }
        set
        {
            SetIdPlayer(value);
        }
    }
    public int stateMusic;
    public int stateSound;
    private string scoreData = "Score.Data";
    private string aniPlayerData = "aniPlayerData.Data";
    private string audioMusicData = "audioMusic.Data";
    private string audioSoundData = "audioSound.Data";

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại object này qua các scene
        }
        else
        {
            Destroy(gameObject); // Hủy object nếu đã có instance tồn tại
        }
    }

    public void SetScore( int newScore)
    {
        PlayerPrefs.SetInt(scoreData, newScore);
        PlayerPrefs.Save();
    }
    public int GetScore()
    {
        return PlayerPrefs.GetInt(scoreData, 0);
    } 

    public void SetIdPlayer(int newId)
    {
        PlayerPrefs.SetInt(aniPlayerData, newId);
        PlayerPrefs.Save();
    }

    public int GetIdPlayer()
    {
        return PlayerPrefs.GetInt(aniPlayerData, 0);
    }
    public void DelleteData()
    {
        PlayerPrefs.DeleteAll();
    }

    public bool GetMusic()
    {
        return PlayerPrefs.GetInt(audioMusicData, 1) == 1;  
    }

    public void SetMusicState(bool isOn)
    {
        PlayerPrefs.SetInt(audioMusicData, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
    public bool GetSound()
    {
        return PlayerPrefs.GetInt(audioSoundData, 1) == 1;  
    }

    public void SetSoundState(bool isOn)
    {
        PlayerPrefs.SetInt(audioSoundData, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
