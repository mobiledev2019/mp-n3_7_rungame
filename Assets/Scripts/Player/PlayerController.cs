using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private List<PlayerChild> Players;

    [SerializeField] private float speed = 6;

    [SerializeField] private PlayerChild childFrefabs;

    public static PlayerController Instance;
    private float sizePlayer = 1f;
    private int CurPosition;

    private int levelPlayer = 0;
    public bool IsAlive;
    private int timeItemSpeed = 0;
    private Vector3 startPositon = Vector3.up*2;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }

//        Init();
    }

    private PlayerChild tempChils;
    public void Init()
    {
        IsAlive = false;
        CurPosition = 2;
        transform.position = startPositon;
        if (Players != null && Players.Count > 0)
        {
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Recycle();
            }
        }

        if (tempChils != null)
        {
            tempChils.Recycle();
        } 
        Players.Clear();
        tempChils = childFrefabs.Spawn(this.transform, Vector3.zero);
        Players.Add(tempChils);
        tempChils.setUsed(); 
        speed = 6;
    }
     
    // Update is called once per frame
    private void Update() {
        if (IsAlive == true)
        {
            Move();
            TimeSpeedItem();
        }
    }

    private void Move() {
        transform.position += Vector3.forward * speed * Time.deltaTime;
       
    }

    private void TimeSpeedItem()
    {
        if (timeItemSpeed > 0)
        {
            timeItemSpeed--;
            if (timeItemSpeed == 0)
            {
                speed = 3;
            }
        } 
    }

    private void Stop() {
        speed = 0;
    }

    private void updatePlayer(PlayerChild player) {
        player.transform.SetParent(transform);
        Debug.Log("set paarent ");
        player.transform.position = Players[Players.Count - 1].transform.position;
        for (int playerIndex = 0; playerIndex < Players.Count; playerIndex++) {
            Players[playerIndex].transform.position += Vector3.up * sizePlayer;
        }
        player.setUsed();
        Players.Add(player);
    }

    private void OnTriggerEnter(Collider orther) {
        if (IsAlive)
        {
            if (GameController.Instance.winGameLevel)
            {
                return;
            }
            if (orther.gameObject.CompareTag("playerChild")) {
                PlayerChild _player = orther.GetComponent<PlayerChild>();
                if (_player.NotUse()) {
                    updatePlayer(_player);
                }
            }

            if (orther.gameObject.CompareTag("roadCheckLevel")) { 
                if (GameService.Instance.getLevelRoad() > levelPlayer) { 
                    SetPositionLevelUp(); 
                }
            }

            if (orther.gameObject.CompareTag("Boom")) {
                Debug.Log(" collider  =   " + orther.name);
                Players[Players.Count - 1].Death();
                RemovePlayerByIndex(Players.Count - 1);
                orther.gameObject.SetActive(false);
                UpPlayerChil(-1);
            }

            if (orther.gameObject.CompareTag("ItemSpeed"))
            {
                speed = 5;
                timeItemSpeed = 20;
            }

            if (orther.gameObject.CompareTag("target"))
            {
                speed = 0; 
                GameController.Instance.WinGameLevel();
            }
            
        }
       
    }

    private void UpPlayerChil(int dis = 1) {
        for (int i = 0; i < Players.Count; i++) {
            Players[i].transform.position += Vector3.up * dis;
        }
    } 

    private void SetPositionLevelUp() {
        UpLevelPlayer();
        Players[Players.Count - 1].transform.SetParent(null);
        Players.RemoveAt(Players.Count - 1);
        UpPlayerChil(-1);
        transform.position += Vector3.up;
    }

    public void RemovePlayer(PlayerChild playerDie) {
        if (Players.Count >= 1) {
            Players.RemoveAt(Players.IndexOf(playerDie));
            CheckDeath();
        }
    }

    private void RemovePlayerByIndex(int index) {
        if (Players.Count >= 1) {
            Players[Players.Count-1].setDie();
            Players[Players.Count - 1].gameObject.SetActive(false);
            Players.RemoveAt(index);
            CheckDeath();
        }
    }

    private void CheckDeath()
    {
        if (Players.Count <= 0)
        {
            Debug.Log("Dieeeeeeeeeeee");
            IsAlive = false;
            speed = 0;
            GameController.Instance.GameOver();
//            Time.timeScale = 0;
        }
    }

    private void UpLevelPlayer() {
        levelPlayer++;
    }

    public void MoveLeftRight(float dir = 1)
    {

        if (!IsAlive || GameController.Instance.stateGame != GameController.StateGame.Playing) return;
        if (dir > 0) {
            if (CurPosition >= GameService.Instance.getLandRoadNumber() -1) {
                return;
            } 
            CurPosition++;
        }

        if (dir < 0) {
            if (CurPosition <= 0) {
                return;
            } 
            CurPosition--;
        }

        float x = transform.position.x;
        transform.DOMoveX(x + dir, 0.2f);
    }

}
