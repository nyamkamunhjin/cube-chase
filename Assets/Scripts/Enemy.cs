using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 5f;
    public float rotationSpeed = 0.8f;
    private GameSession gameSession;
    void Start() {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update() {
        // target position
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        controlledLookAt(transform, gameSession.player.transform, 1f);
    }

    void controlledLookAt(Transform transform, Transform target, float speed) {

        Vector3 targetPos = new Vector3(
            gameSession.player.transform.position.x,
            0.5f,
            gameSession.player.transform.position.z
        );

        Vector3 direction = target.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, 0.8f * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void OnCollisionEnter(Collision other) {
        // print(other.collider.tag);
        if(other.collider.tag == "enemy") {
            this.transform.gameObject.SetActive(false);
        }
    }

}