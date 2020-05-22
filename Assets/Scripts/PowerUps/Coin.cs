using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private void Update() {
        transform.Rotate(0f, 100f * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter(Collision other) {
        // print(other.collider.tag);
        if (other.collider.tag == "player") {
            GameSession.coinScoreUpdater(1);
            transform.gameObject.SetActive(false);
        }
    }
}