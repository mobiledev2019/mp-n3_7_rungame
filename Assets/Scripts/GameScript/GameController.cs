using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{ 
    private enum ModePlay
    {
        LevelMode,
        ClassicMode
    };

    [SerializeField] private ModePlay modePlay;

    private void PlayGameByClassicMode()
    {
        modePlay = ModePlay.ClassicMode;
    }
	
}
