using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSession : BaseSession {
    public CoinSession(GameObject obj) {
        objects = new GameObject[5];

        waitTime = 3f;
        min = 8f;
        max = 15f;
        height = 0.5f;
        rand1 = 7f;
        rand2 = 10f;

        this.spawn(obj);
    }
}