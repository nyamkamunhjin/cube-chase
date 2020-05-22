using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {
    public static Vector3 initialPos = new Vector3(0f, 0.5f, 0f);
    public static Player player;
    public static int kills = 0;
    public static int coins = 0;
    public static Buttons UIs;

    public static event Action enemyDeathEvent;
    public static event Action coinPickUpEvent;
    public static event Action playerDeathEvent;

    private Gameplay gameplayUI;

    private void Start() {
        UIs = FindObjectOfType<Buttons>();
        gameplayUI = FindObjectOfType<Gameplay>();
    }

    public static void startInfiniteMode() {
        FindObjectOfType<InfiniteMode>().enabled = false;
        FindObjectOfType<InfiniteMode>().enabled = true;
        UIs.SetMenuUIState(false);
        UIs.SetGameplayUIState(true);
        UIs.SetGameOverUIState(false);

    }

    public static void GotoGameOver() {

        UIs.SetMenuUIState(false);
        UIs.SetGameplayUIState(false);
        UIs.SetGameOverUIState(true);
    }

    public static void GotoMenu() {
        UIs.SetMenuUIState(true);
        UIs.SetGameplayUIState(false);
        UIs.SetGameOverUIState(false);

    }

    public static void SessionReset() {
        FindObjectOfType<InfiniteMode>().enabled = false;
        FindObjectOfType<PortalMode>().enabled = false;
        FindObjectOfType<BossFightMode>().enabled = false;
        kills = 0;
        coins = 0;
    }

    public static void setPlayerState(GameObject player, bool value) {
        if (!value) {
            GotoGameOver();
            if (playerDeathEvent != null) {
                playerDeathEvent();
            }
        }

        player.GetComponent<MeshRenderer>().enabled = value;
        player.GetComponent<Player>().enabled = value;
        player.GetComponent<BoxCollider>().enabled = value;
        player.GetComponent<TrailRenderer>().enabled = value;
    }

    public static void killScoreUpdater(int value) {
        kills += value;

        if (enemyDeathEvent != null) {
            enemyDeathEvent();
        }
    }

    public static void coinScoreUpdater(int value) {
        coins += value;

        if (coinPickUpEvent != null) {
            coinPickUpEvent();
        }
    }
}