using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{

    PhotonView pv;

    GameObject controller;
    public MultipleTarget cameraFollow;

    void Awake()
    {
        pv = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (pv.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Transform spawnpoint = SpawnManager.Instance.GetSpawnPoint();
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, spawnpoint.rotation, 0, new object[] { pv.ViewID });
        cameraFollow = GameObject.FindGameObjectWithTag("FollowCamera").GetComponent<MultipleTarget>();
        cameraFollow.players.Add(controller.transform);
    }

    public void Die()
    {
        PhotonNetwork.Destroy(controller);
        cameraFollow.players.Remove(controller.transform);
        //CreateController();
    }

}
