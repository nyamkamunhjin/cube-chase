using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticFunctions {
    public static void setEnemyState(GameObject enemy, bool value) {
        Enemy temp = enemy.GetComponent<Enemy>();
        temp.enabled = value;
        temp.isAlive = value;

        enemy.GetComponent<MeshRenderer>().enabled = value;
        enemy.GetComponent<BoxCollider>().enabled = value;
        enemy.GetComponent<TrailRenderer>().enabled = value;
    }

    public static void setPlayerState(GameObject player, bool value) {
        player.GetComponent<MeshRenderer>().enabled = value;
        player.GetComponent<Player>().enabled = value;
        player.GetComponent<BoxCollider>().enabled = value;
        player.GetComponent<TrailRenderer>().enabled = value;
    }
}