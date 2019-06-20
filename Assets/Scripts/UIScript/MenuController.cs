using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : PageBase {

    public static MenuController instance;
    [Header("UI")]
    public Button btnAddCoin;
    public Button btnPlay, btnShop, btnSetting, btnRate, 
        btnRank, btnShare, btnExitPopup, btnSound, btnMusic, btnNoAD, btnLevel, 
        btnExitNoInternet, btnShowRegister ,btnRegister, btnBackLogin;
    public GameObject popUpSetting;
    public Text textCoin;
    public GameObject panelLevel, panelMenu, panelLeader, panelNoInternet, panelRegister;


    [Header("Sprite")]
    public Sprite music;
    public Sprite musicP, noMusic, noMusicP, sound, soundP, noSound, noSoundP;


    private void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        Init();
        InitStateButton();
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

    public void Init()
    {
        //Init button listener
//        btnAddCoin.onClick.AddListener(OnClickAddCoin);
        btnPlay.onClick.AddListener(OnClickPlayClassic);
        btnShop.onClick.AddListener(OnClickShop);
        btnRate.onClick.AddListener(OnClickRate);
        btnRank.onClick.AddListener(OnClickRank);
        btnShare.onClick.AddListener(OnClickShare);
        btnExitPopup.onClick.AddListener(OnClickExitPopupSetting);
        btnSound.onClick.AddListener(OnClickSound);
        btnMusic.onClick.AddListener(OnClickMusic);
        btnNoAD.onClick.AddListener(OnClickNoAD);
        btnSetting.onClick.AddListener(OnClickSetting);
        btnLevel.onClick.AddListener(OnClickLevel);
        btnBackLogin.onClick.AddListener(OnClickBackLogin);
    }

    void OnClickPlayClassic() {
        GameController.Instance.PlayGameByClassicMode();
        Hide();
    }

    #region OnClickButton

    void OnClickAddCoin()
    {

    }

    void OnClickPlay()
    {

    }

    void OnClickShop()
    {

    }

    void OnClickSetting()
    {
        popUpSetting.SetActive(true);
    }

    void OnClickRate()
    {

    }

    void OnClickRank()
    {

        
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
            panelNoInternet.SetActive(true);
            btnExitNoInternet.onClick.AddListener(() =>
            {
                panelNoInternet.SetActive(false);
            });
        }
        else
        {
            panelLeader.SetActive(true);
            panelMenu.SetActive(false);
            LoginManager.instance.LoadDataToLeaderBoard();
        }
    }

    void OnClickShare()
    {
        //FacebookManager.instance.Share();
    }

    void OnClickExitPopupSetting()
    {
        popUpSetting.SetActive(false);
    }

    void OnClickSound()
    {
        if (GameManager.instance.GetSound() == "on")
        {
            ChangeSpriteBtn(btnSound, noSound, noSoundP);
            GameManager.instance.SetSound("off");
        }
        else
        {
            ChangeSpriteBtn(btnSound, sound, soundP);
            GameManager.instance.SetSound("on");
        }
    }

    void OnClickMusic()
    {
        if(GameManager.instance.GetMusic() == "on")
        {
            ChangeSpriteBtn(btnMusic, noMusic, noMusicP);
            GameManager.instance.SetMusic("off");
        }
        else
        {
            ChangeSpriteBtn(btnMusic, music, musicP);
            GameManager.instance.SetMusic("on");
        }
    }

    void OnClickNoAD()
    {

    }

    void OnClickLevel()
    {
        panelLevel.SetActive(true);
        panelMenu.SetActive(false);
    }

    void OnClickBackLogin()
    {
        if (LoginManager.instance.errorObj.active)
        {
            LoginManager.instance.errorObj.SetActive(false);
            LoginManager.instance.loginObj.SetActive(true);
        }
        else if(LoginManager.instance.panelRegister.active)
        {
            LoginManager.instance.panelRegister.SetActive(false);
            LoginManager.instance.loginObj.SetActive(true);
        }
        else
        {
            LoginManager.instance.panelLogin.SetActive(false);
            panelMenu.SetActive(true);
        }
    }

    public void OnClickBackLeaderBoard()
    {
        panelMenu.SetActive(true);
        panelLeader.SetActive(false);
    }

    #endregion

    #region Help

    void InitStateButton()
    {
        if (GameManager.instance.GetSound() == "on") ChangeSpriteBtn(btnSound, sound, soundP);
        else ChangeSpriteBtn(btnSound, noSound, noSoundP);

        if (GameManager.instance.GetMusic() == "on") ChangeSpriteBtn(btnMusic, music, musicP);
        else ChangeSpriteBtn(btnMusic, noMusic, noMusicP);

    }

    void ChangeSpriteBtn(Button btn, Sprite img, Sprite imgP)
    {
        btn.GetComponent<Image>().sprite = img;

        SpriteState state = btn.spriteState;
        state.pressedSprite = imgP;

        btn.spriteState = state;

    }

    #endregion


}
