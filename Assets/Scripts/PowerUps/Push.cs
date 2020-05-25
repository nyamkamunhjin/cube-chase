using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour {
    public float bonusSpeed = 10f;
    public int decreaseSpeedFactor = 3;

    private float initialSpeed;

    private Player player;
    private void OnCollisionEnter(Collision other) {
        print(other.collider.tag);
        if (other.collider.tag == "player") {
            player = GameSession.player;
            player.speed += bonusSpeed;
            // initialSpeed = bonusSpeed;
            player.currentRotation = transform.eulerAngles.y;

            setState(false);
        }
    }

    private void Update() {
        if (player != null) {
            PushPlayer();
        }

    }

    private void OnEnable() {
        setState(true);
    }

    private void setState(bool value) {
        transform.GetComponent<MeshRenderer>().enabled = value;
        transform.GetComponent<BoxCollider>().enabled = value;
    }

    private void PushPlayer() {
        // if(initialSpeed > 0f) {
        //     player.transform.Translate(transform.forward * initialSpeed * Time.deltaTime, Space.World);
        //     initialSpeed -= decreaseSpeedFactor * Time.deltaTime;

        // } else {
        //     player = null;
        // }

        if (player.speed >= player.originalSpeed) {
            player.speed -= decreaseSpeedFactor * Time.deltaTime;
        } else {
            player.speed = player.originalSpeed;
            player = null;
            transform.gameObject.SetActive(false);
        }
    }
}