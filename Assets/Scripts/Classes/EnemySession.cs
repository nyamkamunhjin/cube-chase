using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySession : BaseSession {

    public EnemySession(GameObject obj, float speed) {
        objects = new GameObject[10];

        waitTime = 3f;
        height = 0.5f;
        min = 25f;
        max = 35f;
        rand1 = 3f;
        rand2 = 4f;

        spawn(obj, speed);
    }
    
    public static void setEnemyState(GameObject enemy, bool value) {
        Enemy temp = enemy.GetComponent<Enemy>();
        temp.enabled = value;
        temp.isAlive = value;

        enemy.GetComponent<MeshRenderer>().enabled = value;
        enemy.GetComponent<BoxCollider>().enabled = value;
        enemy.GetComponent<TrailRenderer>().enabled = value;
        enemy.GetComponent<Rigidbody>().detectCollisions = value;
    }

    public void spawn(GameObject obj, float speed) {
        for (int i = 0; i < objects.Length; i++) {
            objects[i] = GameObject.Instantiate(obj, new Vector3(0f, -10f, 0f), Quaternion.identity);
            objects[i].GetComponent<Enemy>().speed = speed;
            // objects[i].SetActive(false);
            setEnemyState(objects[i], false);
        }
        index = 0;
    }

    public new void rePool(Player player) {
        if (!objects[index].GetComponent<Enemy>().isAlive) {
            float x = spawnRandomizer(player.transform.position.x + Random.Range(min, max));
            float z = spawnRandomizer(player.transform.position.z + Random.Range(min, max));

            objects[index].transform.position = new Vector3(x, height, z);
            setEnemyState(objects[index], true);

            index++;

            if (index >= this.objects.Length) {
                index = 0;
            }

            spawnTimer = 0f;
            waitTime = Random.Range(rand1, rand2);
        }
    }

    public new void pool() {
        if (spawnTimer < waitTime) {
            spawnTimer += Time.deltaTime;
        } else {
            rePool(GameSession.player);
        }
    }

}