using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;
using UnityEngine.UI;

[System.Serializable]

public class MapData
{
    public string name;
    public int scene;
}

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    public MapData[] maps;
    public int currentmap = 0;

    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameObject selectMapButton;
    [SerializeField] GameObject toggleButton;

    public Button skinHoodieButton;
    public Button skinSunglassesButton;
    public Button skinBucketButton;
    public Button shopHoodieButton;
    public Button shopSunglassesButton;
    public Button shopBucketButton;


    public int playerMoney;
    public TMP_Text moneyText;
    public bool powerUps;
    public int winsint;
    public TMP_Text winsText;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = PlayerPrefs.GetInt("PlayerMoney");
        moneyText.text = playerMoney.ToString();
        Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();
        PlayerPrefs.GetInt("HoodieItem", 1);
        PlayerPrefs.GetInt("Sunglasses", 1);
        PlayerPrefs.GetInt("Bucket", 1);
        winsint = PlayerPrefs.GetInt("Wins");
        winsText.text = winsint.ToString();


        if (PlayerPrefs.GetInt("HoodieItem") == 1)
        {
            skinHoodieButton.interactable = true;
            shopHoodieButton.interactable = false;
        }
        if (PlayerPrefs.GetInt("Sunglasses") == 1)
        {
            skinSunglassesButton.interactable = true;
            shopSunglassesButton.interactable = false;
        }
        if (PlayerPrefs.GetInt("Bucket") == 1)
        {
            skinBucketButton.interactable = true;
            shopBucketButton.interactable = false;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        Debug.Log("Joined Lobby");
    }
    
    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;

        foreach(Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListIten>().SetUp(players[i]);
        }

        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        selectMapButton.SetActive(PhotonNetwork.IsMasterClient);
        toggleButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        selectMapButton.SetActive(PhotonNetwork.IsMasterClient);
        toggleButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed:" + message;
        MenuManager.Instance.OpenMenu("error");
    }

    public void StartGame()
    {
        //PhotonNetwork.LoadLevel(1);
        PhotonNetwork.LoadLevel(maps[currentmap].scene);
    }
    public void leaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");
    }
    public override void OnLeftRoom()
    {
        //Destroy(RoomManager.Instance.gameObject);
        //PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListIten>().SetUp(newPlayer);
    }

    public void ChangeMap(int currentmapp)
    {
        currentmap = currentmapp;
        if (currentmap >= maps.Length) currentmap = 0;
    }

    public void EnablePowerup()
    {
        powerUps = true;
    }

    public void EquipItem(GameObject item)
    {
        item.SetActive(true);
    }
    public void EquipItemMenu(GameObject item)
    {
        item.SetActive(true);
    }
    public void UnEquipItem(GameObject item)
    {
        item.SetActive(false);
    }
    public void UnEquipItemMenu(GameObject item)
    {
        item.SetActive(false);
    }
}
