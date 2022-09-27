using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameOverScript : MonoBehaviour
{
    public bool gameHasEnded;
    [SerializeField] GameObject gameOverCanvas;
    PhotonView pv;
    void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    void Update()
    {
        if(gameHasEnded ==true)
        {
            Invoke("EndScreen", 3f);
        }
    }
    
    void EndScreen()
    {
        gameOverCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        pv.RPC("RPC_EnableWinscreen", RpcTarget.Others);
    }


    [PunRPC]
    void RPC_EnableWinscreen()
    {
        Cursor.lockState = CursorLockMode.None;
        gameObject.GetComponent<Canvas>().enabled = true;
    }
}
