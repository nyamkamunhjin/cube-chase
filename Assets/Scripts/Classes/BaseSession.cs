using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSession {
    public GameObject[] objects;

    public int index;
    public float spawnTimer = 0;

    public float waitTime;
    public float height;
    public float min;
    public float max;
    public float rand1;
    public float rand2;

    public static float spawnRandomizer(float value) {
        // random between 0, 1 weird
        return Random.Range(0, 2) == 1 ? (-1 * value) : value;
    }

    public void spawn(GameObject obj) {
        for (int i = 0; i < objects.Length; i++) {
            objects[i] = GameObject.Instantiate(obj, new Vector3(0f, -10f, 0f), Quaternion.identity);
            objects[i].SetActive(false);
        }

        index = 0;
    }

    public void rePool(Player player, bool state) {
        if (!state) {
            float x = spawnRandomizer(player.transform.position.x + Random.Range(min, max));
            float z = spawnRandomizer(player.transform.position.z + Random.Range(min, max));

            objects[index].transform.position = new Vector3(x, height, z);
            objects[index].gameObject.SetActive(true);

            index++;

            if (index >= this.objects.Length) {
                index = 0;
            }

            spawnTimer = 0f;
            waitTime = Random.Range(rand1, rand2);
        }
    }

    public void rePool(Player player) {
        float x = spawnRandomizer(player.transform.position.x + Random.Range(min, max));
        float z = spawnRandomizer(player.transform.position.z + Random.Range(min, max));

        objects[index].transform.position = new Vector3(x, height, z);
        objects[index].transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        objects[index].gameObject.SetActive(true);

        index++;

        if (index >= this.objects.Length) {
            index = 0;
        }

        spawnTimer = 0f;
        waitTime = Random.Range(rand1, rand2);
    }

    public void pool() {
        if (spawnTimer < waitTime) {
            spawnTimer += Time.deltaTime;
        } else {
            rePool(GameSession.player);
        }
    }

    public void reset() {
        for (int i = 0; i < objects.Length; i++) {
            if (this.objects[i] != null) {
                GameObject.Destroy(this.objects[i]);
            }
        }

        index = 0;
    }
}