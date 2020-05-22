using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
    // Update is called once per frame
    public bool isAttached = false;

    private int myIndex;

    private void Awake() {
    }

    void Update() {
        if (isAttached) {
            followHandler();
        }
        transform.Rotate(0f, 100f * Time.deltaTime, 0f);
    }

    void followHandler() {
        if (myIndex == 0) {
            follow(GameSession.player.transform);
        } else {
            follow(GameSession.player.lives[myIndex - 1].transform);
        }
    }

    private void OnCollisionEnter(Collision other) {
        // print(other.collider.tag);
        if (other.collider.tag == "player") {
            if (!isAttached) {
                isAttached = true;
                GameSession.player.lives.Add(this);
                myIndex = GameSession.player.lives.Count - 1;
            }
        }
    }

    void follow(Transform target) {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position - target.forward,
            GameSession.player.speed * Time.deltaTime
        );
    }
}