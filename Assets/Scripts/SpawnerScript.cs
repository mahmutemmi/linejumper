using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;
    public float maxY = 2f;
    public float minY = -3f;


    void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        Vector3 platformPosition = new Vector3();
        platformPosition.x = transform.position.x;
        platformPosition.y = Random.Range(minY, maxY);
        platformPosition.z = transform.position.z;

        Instantiate(obj[Random.Range(0, obj.Length)], platformPosition, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
