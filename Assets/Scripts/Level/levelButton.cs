using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelButton : MonoBehaviour {

    public Text idLevel;
    public bool isPass;
    public bool isUnlock;
    public Button button;
    private int level;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonPlay);
    }

    public void SetStage(int id,bool isPass,bool isUnlock)
    {
        level = id;
        this.idLevel.text = id.ToString();
        this.isPass = isPass;
        this.isUnlock = isUnlock;
    }

    private void OnButtonPlay()
    {
        GameController.Instance.PlayGameByLevel(level);
        UIController.Instance.levelPopup.Hide();
    }

}
