using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 5f;
    public float rotateSpeed = 100f;
    private float currentRotation = 0;
    private GameSession gameSession;

    public List<Cubic> lives = new List<Cubic>();

    void Awake() {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.player = this;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.A)) {
            transform.rotation = Quaternion.Euler(
                transform.rotation.x,
                currentRotation,
                transform.rotation.z
            );

            currentRotation -= rotateSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.rotation = Quaternion.Euler(
                transform.rotation.x,
                currentRotation,
                transform.rotation.z
            );

            currentRotation += rotateSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other) {
        // print(other.collider.tag);
        if(other.collider.tag == "enemy") {
            if(this.lives.Count > 0) {

                Cubic temp = this.lives[this.lives.Count - 1];
                temp.isAttached = false;
                temp.gameObject.SetActive(false);
                temp.transform.position -= new Vector3(0f, -10f, 0f);
                this.lives.Remove(temp);
            } else {
                Destroy(this.gameObject);
            }

        }
    }

    private void OnDestroy() {
        gameSession.player = null;
    }
}