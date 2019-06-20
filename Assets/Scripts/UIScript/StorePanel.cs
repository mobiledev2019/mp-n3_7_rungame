using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePanel : PageBase
{
    [SerializeField] private List<ThemeStore> stores;
    [SerializeField] private Button buttonBack;

    private void Start()
    {
        buttonBack.onClick.AddListener(OnButtonPack);
    }

    public void Init()
    {
        var s = ShopServer.Instance.GetPack(0);
        stores[0].Init(1, s);
        for (int i = 1; i < stores.Count; i++)
        {
            s = ShopServer.Instance.GetPack(i); 
            stores[i].Init(ShopServer.Instance.GetOpenTheme(i+1),s);
        }
    }

    public override void Show()
    {
        Init();
        base.Show();
    }

    private void OnButtonPack()
    {
        UIController.Instance.menuPopup.Show();
        Hide();
        
    }
}
