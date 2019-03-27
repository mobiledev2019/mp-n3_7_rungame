using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private List<PlayerChild> Players;

    [SerializeField] private float speed = 6;

    public static PlayerController Instance;
    private float sizePlayer = 1;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
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

    private void OnTriggerEnter(Collider player) {
        if (player.gameObject.CompareTag("playerChild")) {
            PlayerChild _player = player.GetComponent<PlayerChild>();
            if (_player.NotUse()) {
                updatePlayer(_player);
            }
        }
    }

    public void RemovePlayer(PlayerChild playerDie) {
        if (Players.Count >= 1) {
            Players.RemoveAt(Players.IndexOf(playerDie));
        } else {
            Stop();

            Debug.Log("==============> die");
            Time.timeScale = 0;
        }

    }

    public void MoveLeftRight(float dir = 1) {

        float x = transform.position.x;
        transform.DOMoveX(x + dir, 0.2f);
    }

}
