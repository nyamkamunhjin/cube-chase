using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {
    public GameObject enemy;
    public GameObject cubic;
    public GameObject push;

    public Player player;

    public GameObject[] enemies = new GameObject[20];
    public GameObject[] lives = new GameObject[4];
    public GameObject currentPush;

    public int currentLifeIndex;
    public int currentEnemyIndex;

    private float enemySpawnTimer = 0f;
    private float enemyWaitTime = 5f;
    private float lifeSpawnTimer = 0f;
    private float lifeWaitTime = 2f;
    private float pushSpawnTimer = 0f;
    private float pushWaitTime = 6f;

    private void Start() {
        spawnEnemies();
        spawnLives();
        spawnPush();
    }

    private void Update() {

        #region spawn enemies
        if (enemySpawnTimer < enemyWaitTime) {
            enemySpawnTimer += Time.deltaTime;
        } else {
            // rePoolEnemy();
            bool state = enemies[currentEnemyIndex].GetComponent<Enemy>().isAlive;
            rePool(ref enemies, ref currentEnemyIndex, state, ref enemySpawnTimer, ref enemyWaitTime, 25f, 35f, 3f, 7f);
        }
        #endregion 

        #region spawn lives
        if (lifeSpawnTimer < lifeWaitTime) {
            lifeSpawnTimer += Time.deltaTime;
        } else {
            rePoolLives();
            // bool state = lives[currentLifeIndex].GetComponent<Enemy>().isAlive;
            // rePool(ref lives, ref currentLifeIndex, state, ref lifeSpawnTimer, ref lifeWaitTime, 5f, 15f, 10f, 15f);
        }
        #endregion

        #region spawn push power up
        if(pushSpawnTimer < pushWaitTime) {
            pushSpawnTimer += Time.deltaTime;
        } else {
            rePoolPush();
        }

        #endregion
    }

    float spawnRandomizer(float value) {
        // random between 0, 1 weird
        return Random.Range(0, 2) == 1 ? (-1 * value) : value;
    }

    // pooling enemies max 20
    void spawnEnemies() {
        for (int i = 0; i < enemies.Length; i++) {
            enemies[i] = Instantiate(enemy, new Vector3(0f, -10f, 0f), Quaternion.identity);
            // enemies[i].SetActive(false);
            StaticFunctions.setEnemyState(enemies[i], false);
        }
        currentEnemyIndex = 0;
    }

    void spawnLives() {
        for (int i = 0; i < lives.Length; i++) {
            lives[i] = Instantiate(cubic, new Vector3(0f, -10f, 0f), Quaternion.identity);
            lives[i].SetActive(false);
        }
        currentLifeIndex = 0;
    }

    void spawnPush() {
        currentPush = Instantiate(push, new Vector3(0f, -10f, 0f), Quaternion.identity);
    }

    void rePoolLives() {
        if (!lives[currentLifeIndex].GetComponent<Life>().isAttached) {

            float x = spawnRandomizer(player.transform.position.x + Random.Range(5f, 15f));
            float z = spawnRandomizer(player.transform.position.z + Random.Range(5f, 15f));

            lives[currentLifeIndex].transform.position = new Vector3(x, 0.5f, z);
            lives[currentLifeIndex].transform.gameObject.SetActive(true);
            currentLifeIndex++;

            if (currentLifeIndex >= lives.Length) {
                currentLifeIndex = 0;
            }
        }

        lifeSpawnTimer = 0f;
        lifeWaitTime = Random.Range(10f, 15f);
    }

    // not finished
    void rePool(ref GameObject[] array, ref int index, bool state, ref float spawnTimer, ref float waitTime, float min, float max, float rand1, float rand2) {
        if (!state) {
            float x = spawnRandomizer(player.transform.position.x + Random.Range(min, max));
            float z = spawnRandomizer(player.transform.position.z + Random.Range(min, max));

            array[index].transform.position = new Vector3(x, 0.5f, z);
            StaticFunctions.setEnemyState(array[index], true);

            index++;

            if (index >= array.Length) {
                index = 0;
            }

            spawnTimer = 0f;
            waitTime = Random.Range(rand1, rand2);
        }
    }

    void rePoolPush() {
        float x = spawnRandomizer(player.transform.position.x + Random.Range(10f, 20f));
        float z = spawnRandomizer(player.transform.position.z + Random.Range(10f, 20f));

        currentPush.transform.position = new Vector3(x, 0.1f, z);
        currentPush.gameObject.SetActive(true);

        pushSpawnTimer = 0f;
        pushWaitTime = Random.Range(10f, 15f);
    }
}