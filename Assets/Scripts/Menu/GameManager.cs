using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private const string coin = "coin";
    private const string sound = "sound";
    private const string music = "music";

    private void Awake()
    {
        MakeInstance();
        FirstTime();

    }

    private void Start()
    {
    }

    void MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void FirstTime()
    {
        if (!PlayerPrefs.HasKey("_FirstTime"))
        {
            SetCoin(0);
            SetMusic("on");
            SetSound("on");
            PlayerPrefs.SetInt("_FirstTime", 0);
        }
    }

    public void SetCoin(int number)
    {
        PlayerPrefs.SetInt(coin, number);
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt(coin);
    }

    public void SetSound(string state)
    {
        PlayerPrefs.SetString(sound, state);
    }

    public string GetSound()
    {
        return PlayerPrefs.GetString(sound);
    }


    public void SetMusic(string state)
    {
        PlayerPrefs.SetString(music, state);
    }

    public string GetMusic()
    {
        return PlayerPrefs.GetString(music);
    }


}
