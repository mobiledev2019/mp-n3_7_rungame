using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;


public class FacebookManager : MonoBehaviour {

    public static FacebookManager instance;



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

    private void Awake()
    {
        MakeInstance();
        if (!FB.IsInitialized)
        {
            FB.Init(()=>
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                }
                else Debug.LogError("Counldn't connect");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else Time.timeScale = 1;
            });
        }
        else
        {
            FB.ActivateApp();
        }
    }

    #region LOGIN

    public void Login()
    {
        var permissions = new List<string>() { "public_profile", "email", "user_friend" };
        FB.LogInWithReadPermissions(callback : OnLogin);
    }

    void OnLogin(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            Share();
        }
        else Debug.LogError("Can't connect");
    }

    public void Logout()
    {
        FB.LogOut();
    }

    #endregion

    #region Share

    public void Share()
    {
        FB.ShareLink(new System.Uri("http://fb.com"), "Check it out!", "Have a good day!", new System.Uri("http://fb.com"));
    }

    #endregion

}
