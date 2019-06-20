using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public MenuController menuPopup;
    public levelManager levelPopup;
    public WinPanel winPopup;
    public GameOverPanel gameoverPopup;
    public PanelCountdown countdownPopup;
    public PanelInGame ingamePopup;

    public static UIController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

}
