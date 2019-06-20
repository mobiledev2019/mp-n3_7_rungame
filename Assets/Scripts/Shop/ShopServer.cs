using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopServer : MonoBehaviour
{
    public static ShopServer Instance;
    [SerializeField] private PackStore packs;

    private enum keyPack
    {  
        openTheme2,
        openTheme3,
        openTheme4,
        openTheme5,
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
        }
    }

    public void SetOpenTheme(int x)
    {
        switch (x)
        {
            case 2:
                PlayerPrefs.SetInt(keyPack.openTheme2.ToString(),1);
                break;
            case 3:
                PlayerPrefs.SetInt(keyPack.openTheme3.ToString(), 1);
                break;
            case 4:
                PlayerPrefs.SetInt(keyPack.openTheme4.ToString(), 1);
                break;
            case 5:
                PlayerPrefs.SetInt(keyPack.openTheme5.ToString(), 1);
                break; 
        }
        
    }

    public int GetOpenTheme(int x) {
        switch (x) {
            case 2:
                return PlayerPrefs.GetInt(keyPack.openTheme2.ToString());  
            case 3:
                return PlayerPrefs.GetInt(keyPack.openTheme3.ToString());
            case 4:
                return PlayerPrefs.GetInt(keyPack.openTheme4.ToString());
            case 5:
                return PlayerPrefs.GetInt(keyPack.openTheme5.ToString());
        } 
        return 0;
    }

    public packTheme GetPack(int index)
    {
        return packs.packs[index];
    }

}
