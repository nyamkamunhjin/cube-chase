using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSession : BaseSession {
    public PushSession(GameObject obj) {
        objects = new GameObject[2];

        waitTime = 3f;
        min = 10f;
        max = 20f;
        height = 0.1f;
        rand1 = 10f;
        rand2 = 15f;

        this.spawn(obj);
    }
}
