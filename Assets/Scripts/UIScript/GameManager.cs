using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LoginManager;


public class GameManager : MonoBehaviour {

    public static GameManager instance;

    private const string user = "user";
    private const string pass = "pass";
    private const string ID = "id";
    private const string coin = "coin";
    private const string sound = "sound";
    private const string music = "music";
    private const string best = "best";
    private const string rank = "rank";

    public GameObject panelLoad;

    private void Awake()
    {
        print(GetUser());
        MakeInstance();
        FirstTime();
        //123456
//        PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        //FacebookManager.instance.CheckLogin();
        //FacebookManager.instance.Login();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
            //            Destroy(gameObject);
        }
    }

    void FirstTime()
    {
        if (!PlayerPrefs.HasKey("_FirstTime"))
        {
            panelLoad.SetActive(true);
            StartCoroutine(Example());
            SetCoin(0);
            SetMusic("on");
            SetSound("on");
            PlayerPrefs.SetInt("_FirstTime", 0);
        }
        else
        {
            User local = LoginManager.instance.FindAccount(GameManager.instance.GetUser());
            int index = 0;

            for (int i = 0; i < LoginManager.instance.listLeaderBoard.Count; i++)
            {
                if (local.account.Equals(LoginManager.instance.listLeaderBoard[i].account))
                {
                    index = i;
                    break;
                }
            }
            print(index);

            int rank = LoginManager.instance.listLeaderBoard.Count - index;
            SetRank(rank);

            LoginManager.instance.textAcc.text = GameManager.instance.GetUser();
            LoginManager.instance.textBest.text = GameManager.instance.GetBest().ToString();
            LoginManager.instance.textRank.text = GameManager.instance.GetRank().ToString();
        }
    }

    IEnumerator Example()
    {
        yield return new WaitUntil(() => LoginManager.instance.loadDone == true);
        //yield return null;
        print(LoginManager.instance.listUser.Count);

        LoginManager.instance.Login();
        panelLoad.SetActive(false);
    }

    public void AddCoin(int number) {
        PlayerPrefs.SetInt(coin, GetCoin() + number);
    }


    public void SetCoin(int number)
    {
        PlayerPrefs.SetInt(coin, number);
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt(coin);
    }

    public void SetRank(int index)
    {
        PlayerPrefs.SetInt(rank, index);
    }

    public int GetRank()
    {
        return PlayerPrefs.GetInt(rank);
    }

    public void SetUser(string userName)
    {
        PlayerPrefs.SetString(user, userName);
    }

    public string GetUser()
    {
        return PlayerPrefs.GetString(user);
    }


    public void SetPass(string password)
    {
        PlayerPrefs.SetString(pass, password);
    }

    public string GetPass()
    {
        return PlayerPrefs.GetString(pass);
    }

    public void SetBest(int point)
    {
        PlayerPrefs.SetInt(best, point);

        LoginManager.instance.AddDataToFB(GetID().ToString(), GetUser(), point.ToString(),GetPass(),GetRank().ToString());
    }

    public int GetBest()
    {
        return PlayerPrefs.GetInt(best);
    }

    public void SetID(int id)
    {
        PlayerPrefs.SetInt(ID, id);
    }

    public int GetID()
    {
        return PlayerPrefs.GetInt(ID);
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
