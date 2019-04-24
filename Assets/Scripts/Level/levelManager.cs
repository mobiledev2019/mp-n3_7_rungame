using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelManager : MonoBehaviour {

    [System.Serializable]
	public class Level
    {
        public int idLevel;
        public bool isUnLock;
        public bool isPass;
    }

    public GameObject btnLevel;
    public Transform levelTransform;
    public Sprite levelUnlock;

    public List<Level> listLevel = new List<Level>();

    private void Start()
    {
        FillListLevel();
    }

    void FillListLevel()
    {
        for(int i = 0; i < listLevel.Count; i++)
        {
            GameObject btnLV = Instantiate(btnLevel.gameObject, levelTransform);
            btnLV.GetComponent<levelButton>().SetStage(listLevel[i].idLevel, listLevel[i].isPass, listLevel[i].isUnLock);
            if (!listLevel[i].isUnLock)
            {
                btnLV.GetComponent<Button>().interactable = false;
                btnLV.GetComponent<levelButton>().idLevel.gameObject.SetActive(false);
                btnLV.GetComponent<Image>().sprite = levelUnlock;
            }
        }
    }

    public void OnClickBack()
    {
        MenuController.instance.panelLevel.SetActive(false);
        MenuController.instance.panelMenu.SetActive(true);
    }


}
