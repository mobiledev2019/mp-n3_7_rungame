using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SimpleAndroidNotifications;
using Firebase.Messaging;
using UnityEngine;


public class Notify : MonoBehaviour {

    public static Notify instance;

    private void Awake()
    {
        instance = this;
    }

    void Start () {

        SendNotify();

        Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
        Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;

	}

    private void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
        Debug.Log("token: " + e.Message.From);
    }

    private void OnTokenReceived(object sender, TokenReceivedEventArgs e)
    {
        Debug.Log("token: " + e.Token);
    }

    public void SendNotify()
    {
        NotificationManager.Send(TimeSpan.FromSeconds(5), "Comeback and play game now!!!", 
            "A player has passed you on the rankings. Comeback and beat this player.", new Color(1, 0.3f, 0.15f));
    }

}
