using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {
    public GameObject enemy;
    public GameObject cubic;
    public Player player;
    public GameObject[] enemies = new GameObject[20];
    public GameObject[] cubics = new GameObject[4];

    public int currentCubicIndex;
    public int currentEnemyIndex;

    private float enemySpawnTimer = 0f;
    private float enemyWaitTime = 5f;
    private float liveSpawnTimer = 0f;
    private float liveWaitTime = 2f;

    private void Start() {
        spawnEnemies();
        spawnLives();
    }

    private void Update() {

        #region spawn enemies
        if (enemySpawnTimer < enemyWaitTime) {
            enemySpawnTimer += Time.deltaTime;
        } else {
            rePoolEnemy();
        }
        #endregion 

        #region spawn lives
        if(liveSpawnTimer < liveWaitTime) {
            liveSpawnTimer += Time.deltaTime;
        } else {
            rePoolLives();
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
            enemies[i].SetActive(false);
        }
        currentEnemyIndex = 0;
    }

    void spawnLives() {
        for(int i = 0; i < cubics.Length; i++) {
            cubics[i] = Instantiate(cubic, new Vector3(0f, -10f, 0f), Quaternion.identity);
            cubics[i].SetActive(false);
        }
        currentCubicIndex = 0;
    }

    void rePoolLives() {
        float x = spawnRandomizer(player.transform.position.x + Random.Range(25f, 35f));
        float z = spawnRandomizer(player.transform.position.z + Random.Range(25f, 35f));
        cubics[currentCubicIndex].transform.position = new Vector3(x, 0.5f, z);
        cubics[currentCubicIndex].transform.gameObject.SetActive(true);

        currentCubicIndex++;

        if (currentCubicIndex >= cubics.Length) {
            currentCubicIndex = 0;
        }

        liveSpawnTimer = 0f;
        liveWaitTime = Random.Range(10f, 15f);
    }

    void rePool(GameObject[] array, int index, float spawnTimer, float waitTime) {
        float x = spawnRandomizer(player.transform.position.x + Random.Range(25f, 35f));
        float z = spawnRandomizer(player.transform.position.z + Random.Range(25f, 35f));

        array[index].transform.position = new Vector3(x, 0.5f, z);
        array[index].SetActive(true);

        index++;

        if (index >= array.Length) {
            index = 0;
        }

        spawnTimer = 0f;
        waitTime = Random.Range(1f, 3f);

    }

    void rePoolEnemy() {
        float x = spawnRandomizer(player.transform.position.x + Random.Range(25f, 35f));
        float z = spawnRandomizer(player.transform.position.z + Random.Range(25f, 35f));

        enemies[currentEnemyIndex].transform.position = new Vector3(x, 0.5f, z);
        enemies[currentEnemyIndex].transform.gameObject.SetActive(true);

        currentEnemyIndex++;

        if (currentEnemyIndex >= enemies.Length) {
            currentEnemyIndex = 0;
        }

        enemySpawnTimer = 0f;
        enemyWaitTime = Random.Range(3f, 7f);
    }

}