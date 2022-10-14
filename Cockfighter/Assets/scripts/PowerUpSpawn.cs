using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] powerUps;
    public float spawnDuration;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        //int randomIndex = Random.Range(0, powerUps.Length);
        //Vector3 randomSpawnpoint = new Vector3(Random.Range(-10, 11), 1, Random.Range(-10, 10));

       // Instantiate(powerUps[randomIndex], randomSpawnpoint, Quaternion.identity);

       // Debug.Log(powerUps[randomIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int randomIndex = Random.Range(0, powerUps.Length);
            Vector3 randomSpawnpoint = new Vector3(Random.Range(-8.8f, 8.8f), 1, Random.Range(-8.8f, 8.8f));

            Instantiate(powerUps[randomIndex], randomSpawnpoint, Quaternion.identity);

            Debug.Log(powerUps[randomIndex]);
        }
    }
}
