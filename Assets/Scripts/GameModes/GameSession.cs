using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {
    public static Vector3 initialPos = new Vector3(0f, 0.5f, 0f);
    public static Player player;
    public static int kills = 0;
    public static int coins = 0;

    public static event Action enemyDeathEvent;
    public static event Action coinPickUpEvent;
    public static event Action playerDeathEvent;

    public static void startInfiniteMode() {
        FindObjectOfType<InfiniteMode>().enabled = false;
        FindObjectOfType<InfiniteMode>().enabled = true;
        Buttons.UIs.SetMenuUIState(false);
        Buttons.UIs.SetGameplayUIState(true);
        Buttons.UIs.SetGameOverUIState(false);

    }

    public static void SessionReset() {
        FindObjectOfType<InfiniteMode>().enabled = false;
        FindObjectOfType<PortalMode>().enabled = false;
        FindObjectOfType<BossFightMode>().enabled = false;
        kills = 0;
        coins = 0;

        GameSession.player.speed = GameSession.player.originalSpeed;
        GameSession.player.currentRotation = 0;
        GameSession.player.transform.position = GameSession.initialPos;
        GameSession.player.transform.rotation = Quaternion.identity;
    }

    public static void setPlayerState(GameObject player, bool value) {
        if (!value) {
            Buttons.GotoGameOver();
            SessionReset();

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