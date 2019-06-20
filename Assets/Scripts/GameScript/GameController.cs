using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private RoadPool roadPool;
    [SerializeField] private CameraController cameraController;

    public enum ModePlay
    {
        LevelMode,
        ClassicMode
    };
    public enum StateGame
    {
        Pause,
        Playing,
        None,
        Setup
    };

    public ModePlay modePlay;
    public StateGame stateGame;
    public static GameController Instance;

    public bool winGameLevel;

    public int curLevel;
     
    private void Awake()
    {
        if (Instance == null) Instance = this;
        Init();
    }

    private void Init()
    {
        stateGame = StateGame.None;
    }

    public void PlayGameByClassicMode()
    {
        modePlay = ModePlay.ClassicMode;
        curLevel = 1;
        winGameLevel = false;
        MapService.Instance.SetCurMap(1);
        MapService.Instance.initMap();
        PlayerGame();
    }

    public void PlayGameByLevel(int level)
    {
        curLevel = level;
        winGameLevel = false;
        modePlay = ModePlay.LevelMode;
        MapService.Instance.SetCurMap(level);
        MapService.Instance.initMap();
        PlayerGame();
    }

    public void PlayGameByNextLevel()
    {
        curLevel++;
        PlayGameByLevel(curLevel);
    }

    private void PlayerGame()
    {
        UIController.Instance.ingamePopup.Show();
        cameraController.setUp();
        player.gameObject.SetActive(true);
        player.Init();
        
        roadPool.Init();
        stateGame = StateGame.Setup;
        UIController.Instance.countdownPopup.ShowCount(3);
        DOVirtual.DelayedCall(3, () =>
        {
            
            stateGame = StateGame.Playing;
            player.IsAlive = true;
        });
    }

    public void WinGameLevel()
    {
        stateGame = StateGame.None;
        winGameLevel = true;
        UIController.Instance.winPopup.Show();

    }

    public void GameOver()
    {
        UIController.Instance.gameoverPopup.Show();
    }

}
