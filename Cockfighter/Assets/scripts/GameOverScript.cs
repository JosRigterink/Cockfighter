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
            Cursor.lockState = CursorLockMode.None;
            Invoke("EndScreen", 3f);
        }
    }
    
    void EndScreen()
    {
        pv.RPC("RPC_EnableWinscreen", RpcTarget.All);
    }


    [PunRPC]
    void RPC_EnableWinscreen()
    {
        Cursor.lockState = CursorLockMode.None;
        if (!pv.IsMine)
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            gameOverCanvas.SetActive(true);
        }
    }
}