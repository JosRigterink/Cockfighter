using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] powerUps;
    public float powerUpSpawnTime;
    public float timeBetweenPowerups;
    bool canSpawn;
    // Start is called before the first frame update
    void Start()
    {
        powerUpSpawnTime = timeBetweenPowerups;
    }

    // Update is called once per frame
    void Update()
    {
        if (Launcher.Instance.powerUps == true)
        {
            powerUpSpawnTime -= Time.deltaTime;

            if (PhotonNetwork.IsMasterClient && powerUpSpawnTime <= 0f)
            {
                canSpawn = true;
                powerUpSpawnTime = timeBetweenPowerups;
            }
            if (canSpawn == true)
            {
                int randomIndex = Random.Range(0, powerUps.Length);
                Vector3 randomSpawnpoint = new Vector3(Random.Range(-7.8f, 7.8f), 1, Random.Range(-7.8f, 7.8f));

                PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "HpPowerUp 1"), randomSpawnpoint, Quaternion.identity);

                Debug.Log(powerUps[randomIndex]);
                canSpawn = false;
            }
        }
    }
}