using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeStore : MonoBehaviour
{
    [SerializeField] private GameObject coins;
    [SerializeField] private Text description;
    [SerializeField] private Button buttonBuy;
    
    /// <summary>
    /// true ==> block
    /// </summary>
    private bool isLock; 
    private int indexTheme;
    private int price;

    public void Init(bool isLock, int indexTheme , int price)
    {
        this.price = price;
        this.indexTheme = indexTheme;
        this.isLock = isLock;
        if (isLock)
        {
            coins.SetActive(true);
            description.gameObject.SetActive(false);
        }
        else
        {
            coins.SetActive(false);
            description.gameObject.SetActive(true);
        }
    }

    public void OnButtonBuy()
    {
        if (isLock == true)
        {
//            if(GameManager.instance.GetCoin())
        }
        else
        {
            ThemeServer.Instance.SetCurTheme(indexTheme);
        }
    }

}
