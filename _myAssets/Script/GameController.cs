using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public static float volume = 1f;

    [Header("Game Elements")]
    public GameObject playerPrefab;
    public Transform startingPoint;
    public Transform enemiesContainer;

    [Header("UI Elements")]
    public GameObject endgamePanel;
    public GameObject gameoverPanel;
    public GameObject fadePanel;


    private List<PlayerController> playerList = new List<PlayerController>();


    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }


    private void Start() {
        endgamePanel.gameObject.SetActive(false);
        gameoverPanel.gameObject.SetActive(false);
        fadePanel.gameObject.SetActive(false);

        GameObject player_obj = Instantiate(playerPrefab);
        player_obj.transform.position = startingPoint.position;
        player_obj.transform.rotation = startingPoint.rotation;

        playerList.Add(player_obj.GetComponentInChildren<PlayerController>());
    }



    private void OnDestroy() {
        instance = null;
    }




    public void GameOver() {
        LockEnemies();
        gameoverPanel.gameObject.SetActive(true);
    }


    public void GameEnd() {
        LockEnemies();
        LockPlayers();
        endgamePanel.gameObject.SetActive(true);
    }



    void LockEnemies () {
        foreach(Transform child in enemiesContainer) {
            child.GetComponent<EnemyController>().LockEnemy();
        }
    }


    void LockPlayers() {
        foreach(PlayerController player in playerList) {
            player.LockPlayer();
        }
    }


}
