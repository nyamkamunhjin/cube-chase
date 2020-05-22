using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSession : BaseSession {

    public LifeSession(GameObject obj) {
        objects = new GameObject[3];

        waitTime = 3f;
        min = 5f;
        max = 15f;
        height = 0.5f;
        rand1 = 10f;
        rand2 = 15f;

        this.spawn(obj);
    }

    public new void pool() {
        if (spawnTimer < waitTime) {
            spawnTimer += Time.deltaTime;
        } else {

            rePool(GameSession.player, getState());
        }
    }

    public bool getState() {
        return objects[index].GetComponent<Life>().isAttached;
    }
}