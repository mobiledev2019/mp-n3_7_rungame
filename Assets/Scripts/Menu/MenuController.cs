using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public static MenuController instance;
    [Header("UI")]
    public Button btnAddCoin;
    public Button btnPlay, btnShop, btnSetting, btnRate, 
        btnRank, btnShare, btnExitPopup, btnSound, btnMusic, btnNoAD;
    public GameObject popUpSetting;
    public Text textCoin;

    [Header("Sprite")]
    public Sprite music;
    public Sprite musicP, noMusic, noMusicP, sound, soundP, noSound, noSoundP;


    private void Start()
    {
        Init();
        InitStateButton();
    }

    public void Init()
    {
        //Init button listener
        btnAddCoin.onClick.AddListener(OnClickAddCoin);
        btnPlay.onClick.AddListener(OnClickPlay);
        btnShop.onClick.AddListener(OnClickShop);
        btnRate.onClick.AddListener(OnClickRate);
        btnRank.onClick.AddListener(OnClickRank);
        btnShare.onClick.AddListener(OnClickShare);
        btnExitPopup.onClick.AddListener(OnClickExitPopupSetting);
        btnSound.onClick.AddListener(OnClickSound);
        btnMusic.onClick.AddListener(OnClickMusic);
        btnNoAD.onClick.AddListener(OnClickNoAD);
        btnSetting.onClick.AddListener(OnClickSetting);

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

    }

    void OnClickShare()
    {

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
