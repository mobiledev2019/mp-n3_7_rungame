using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private List<PlayerChild> Players;

    [SerializeField] private float speed = 6;

    public static PlayerController Instance;
    private float sizePlayer = 1f;
    private int CurPosition;

    private int levelPlayer = 0;
    public bool IsAlive;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }

        IsAlive = true;
        CurPosition = 2;
    }

    // Update is called once per frame
    private void Update() {
        Move();
    }

    private void Move() {
        transform.position += Vector3.forward * speed * Time.deltaTime;

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
                Players[Players.Count - 1].Death();
                RemovePlayerByIndex(Players.Count - 1);
                orther.gameObject.SetActive(false);
                UpPlayerChil(-1);
            }
        }
       
    }

    private void UpPlayerChil(int dis = 1) {
        for (int i = 0; i < Players.Count; i++) {
            Players[i].transform.position += Vector3.up * dis;
        }
    }
    //
    //    private void OnCollisionEnter(Collision orther)
    //    {
    // 
    //    }

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
            Time.timeScale = 0;
        }
    }

    private void UpLevelPlayer() {
        levelPlayer++;
    }

    public void MoveLeftRight(float dir = 1) {
        if (dir > 0) {
            if (CurPosition >= 5) {
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
