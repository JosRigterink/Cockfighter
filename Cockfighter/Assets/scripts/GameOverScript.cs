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
    [SerializeField] GameObject[] uiElements;
    public MultipleTarget followcam;
    PhotonView pv;
    public int playerMoney;
    void Awake()
    {
        pv = GetComponent<PhotonView>();
        playerMoney = PlayerPrefs.GetInt("PlayerMoney");
        followcam = GameObject.FindGameObjectWithTag("FollowCamera").GetComponent<MultipleTarget>();
    }

    void Update()
    {
        if(gameHasEnded == true)
        {
            uiElements[1].SetActive(true);
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
        uiElements[0].SetActive(true);
        followcam.enabled = false;
        MoneyEarned();
        GameObject.Find("PlayerController(Clone)").GetComponent<PlayerController>().walkSpeed = 0;
        GameObject.Find("PlayerController(Clone)").GetComponent<PlayerController>().sprintSpeed = 0;
        GameObject.Find("PlayerController(Clone)").GetComponent<PlayerController>().rb.freezeRotation = true;
        GameObject.Find("PlayerController(Clone)").GetComponent<PlayerController>().attackScript.enabled = false;
        GameObject.Find("PlayerController(Clone)").GetComponentInChildren<Animator>().enabled = false;
        //followcam.enabled = false;
        //Invoke("DestroyAll", 2f);
    }

    void MoneyEarned()
    {
        //int money = Random.Range(200, 500);
        // int money = 250;
        //Debug.Log(money)
        playerMoney += 250;
        PlayerPrefs.SetInt("PlayerMoney", playerMoney);
    }
    void DestroyAll()
    {
        PhotonNetwork.DestroyAll();
    }
}
