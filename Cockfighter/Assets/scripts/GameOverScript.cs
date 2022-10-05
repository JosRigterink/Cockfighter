using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameOverScript : MonoBehaviour
{
    public bool hasWon;
    public bool gameHasEnded;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject gameTimer;
    PhotonView pv;
    public int playerMoney;
    void Awake()
    {
        pv = GetComponent<PhotonView>();
        playerMoney = PlayerPrefs.GetInt("PlayerMoney");
    }

    void Update()
    {
        if(gameHasEnded == true)
        {
            Invoke("EndScreen", 3f);
        }
        gameHasEnded = false;
    }
    
    void EndScreen()
    {
        gameOverCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        gameTimer.GetComponent<Timer>().enabled = false;
        pv.RPC("RPC_EnableWinscreen", RpcTarget.Others);
    }


    [PunRPC]
    void RPC_EnableWinscreen()
    {
        gameTimer.GetComponent<Timer>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        gameObject.GetComponent<Canvas>().enabled = true;
        MoneyEarned();
        PhotonNetwork.DestroyAll();
    }

    void MoneyEarned()
    {
        //int money = Random.Range(200, 500);
        // int money = 250;
        //Debug.Log(money)
        playerMoney += 250;
        PlayerPrefs.SetInt("PlayerMoney", playerMoney);
    }
}
