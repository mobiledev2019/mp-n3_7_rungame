using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelButton : MonoBehaviour {

    public Text idLevel;
    public bool isPass;
    public bool isUnlock;

    public void SetStage(int id,bool isPass,bool isUnlock)
    {
        this.idLevel.text = id.ToString();
        this.isPass = isPass;
        this.isUnlock = isUnlock;
    }

}
