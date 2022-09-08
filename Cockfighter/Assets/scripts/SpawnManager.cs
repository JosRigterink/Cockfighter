using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    SpawnPoint[] spawnPoints;

    void Awake()
    {
        Instance = this;
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    public Transform GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
        //if (PhotonNetwork.IsMasterClient)
        //{
         //    return spawnPoints[0].transform;
        //}
        //else
        //{
         //    return spawnPoints[1].transform;
       // }
    }
}
