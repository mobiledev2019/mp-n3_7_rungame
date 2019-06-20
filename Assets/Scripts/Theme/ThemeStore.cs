using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeStore : MonoBehaviour
{
    [SerializeField] private GameObject coins;
    [SerializeField] private Text description;
    [SerializeField] private Button buttonBuy;
    [SerializeField] private string des;
    
    /// <summary>
    /// 1 ==> block
    /// </summary>
    private int isLock; 
    private int indexTheme;
    private int price;

    public void Init(int isLock, packTheme pack)
    {
        price = pack.price;
        indexTheme = pack.index;
        des = pack.des;
        description.text =  des;
        this.isLock = isLock;
        if (isLock == 0)
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
        if (isLock == 0)
        {
            if (GameManager.instance.GetCoin() > price)
            {
                isLock = 1;
                coins.SetActive(false);
                description.gameObject.SetActive(true);
                ThemeServer.Instance.SetCurTheme(indexTheme);
            }
        }
        else
        {
            ThemeServer.Instance.SetCurTheme(indexTheme);
        }
    }

}
