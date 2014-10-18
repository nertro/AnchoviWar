using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour {

    GameObject[] spawnPoints;
    public GameObject Item;
    float timer;
    float delay;

	void Start () {
        timer = 0f;
        delay = 10f;
        spawnPoints = GameObject.FindGameObjectsWithTag("ItemSpawn");
	}
	

	void Update () {
        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer = 0;
            SpawnNewItem();
        }
	}

    void SpawnNewItem()
    {
        float rand = Random.Range(0, spawnPoints.Length-1);
        SpawnPoint spawnPoint = spawnPoints[(int)rand].GetComponent<SpawnPoint>();

        if (spawnPoint.HasItem)
        {
            SpawnNewItem();
        }
        else
        {
            Instantiate(Item, spawnPoint.transform.position, Quaternion.identity);
            spawnPoint.HasItem = true;
        }
    }
}
