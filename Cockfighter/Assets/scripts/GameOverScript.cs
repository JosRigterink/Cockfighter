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
    public int wins;
    void Awake()
    {
        pv = GetComponent<PhotonView>();
        playerMoney = PlayerPrefs.GetInt("PlayerMoney");
        wins = PlayerPrefs.GetInt("Wins");
        followcam = GameObject.FindGameObjectWithTag("FollowCamera").GetComponent<MultipleTarget>();
    }

    void Update()
    {
        if(gameHasEnded == true)
        {
            GameObject.Find("PlayerController(Clone)").GetComponent<PlayerController>().enabled = false;
            Invoke("EndScreen", 3f);
        }
        gameHasEnded = false;
    }
    
    void EndScreen()
    {
        followcam.enabled = false;
        gameOverCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        gameTimer.GetComponent<Timer>().enabled = false;
        pv.RPC("KOmessage", RpcTarget.All);
        pv.RPC("RPC_EnableWinscreen", RpcTarget.Others);
        Invoke("BackToMenu", 7f);
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
        GameObject.Find("PlayerController(Clone)").GetComponent<PlayerController>().ui.SetActive(false);
        //GameObject.Find("PlayerController(Clone)").GetComponentInChildren<Animator>().enabled = false;
        GameObject.Find("PlayerController(Clone)").GetComponent<PlayerController>().enabled = false;
        Invoke("BackToMenu", 7f);
        //Invoke("DestroyAll", 2f);
    }

    void MoneyEarned()
    {
        //int money = Random.Range(200, 500);
        // int money = 250;
        //Debug.Log(money)
        playerMoney += 100;
        PlayerPrefs.SetInt("PlayerMoney", playerMoney);
        wins++;
        PlayerPrefs.SetInt("Wins", wins);
    }
    void DestroyAll()
    {
        PhotonNetwork.DestroyAll();
    }

    void BackToMenu()
    {
        gameObject.GetComponent<SceneSwitch>().enabled = true;
    }
    [PunRPC]
    void KOmessage()
    {
        uiElements[1].SetActive(true);
    }


}
