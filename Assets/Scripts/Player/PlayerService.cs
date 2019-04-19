using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    public static PlayerService Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public PlayerData playerData;

    public PlayerDesign getPlayer()
    {
        int typeIndex = Random.Range(0, playerData.PlayDesigns.Count);
        return playerData.PlayDesigns[typeIndex];
    }
}
