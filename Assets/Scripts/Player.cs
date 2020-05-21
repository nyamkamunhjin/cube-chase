using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 5f;
    public float rotateSpeed = 100f;
    public float originalSpeed;
    public Shader flickerShader;

    public float currentRotation = 90;

    private Material originalMat;
    private BoxCollider box;
    private MeshRenderer rend;

    private float timer = 0;

    private ParticleSystem explosion;
    private GameSession gameSession;

    private bool invincibleMode = false;

    public List<Life> lives = new List<Life>();

    void Awake() {
        gameSession = FindObjectOfType<GameSession>();
        gameSession.player = this;
    }

    private void Start() {
        originalSpeed = speed;
        box = GetComponent<BoxCollider>();
        rend = GetComponent<MeshRenderer>();
        originalMat = rend.material;
        explosion = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update() {

        #region movement
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A)) {
            currentRotation -= rotateSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) {
            currentRotation += rotateSpeed * Time.deltaTime;
        }
#endif

#if UNITY_ANDROID
        // Handle screen touches.
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector2 pos = touch.position;

            if (pos.x < Screen.width / 2.0f) {
                currentRotation -= rotateSpeed * Time.deltaTime;
            } else {
                currentRotation += rotateSpeed * Time.deltaTime;
            }
        }

#endif
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        transform.rotation = Quaternion.Euler(
            transform.rotation.x,
            currentRotation,
            transform.rotation.z
        );
        
        #endregion

        #region invinciblity
        if (invincibleMode) {
            invincible(2f);
        }
        #endregion

        #region push power up

        #endregion
    }

    private void OnCollisionEnter(Collision other) {
        // print(other.collider.tag);
        if (other.collider.tag == "enemy") {
            deathHandler();
        }
    }

    private void deathHandler() {
        if (this.lives.Count > 0) {

            Life temp = this.lives[this.lives.Count - 1];
            temp.isAttached = false;
            temp.gameObject.SetActive(false);
            temp.transform.position -= new Vector3(0f, -10f, 0f);
            this.lives.Remove(temp);
            // make invincible for few seconds
            invincibleMode = true;

        } else {
            explosion.Play();
            StaticFunctions.setPlayerState(transform.gameObject, false);
        }
    }

    private void invincible(float duration) {
        rend.material = new Material(flickerShader);
        rend.material.SetColor("_Color", originalMat.GetColor("_BaseColor"));
        print(originalMat.GetColor("_BaseColor"));
        box.enabled = false;

        timer += Time.deltaTime;
        if (timer >= duration) {
            invincibleMode = false;
            box.enabled = true;
            timer = 0f;
            rend.material = originalMat;
        }
    }

}