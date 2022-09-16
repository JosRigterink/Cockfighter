using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreen : MonoBehaviour
{
    public GameObject[] canvasses;
    public GameObject coins;
    public GameObject stageSelectButton;
    public Slider fullscreenSlider;
    public bool isHost;
    public bool isFullscreen;
    public TextMeshProUGUI roomButtonText;

    void Start()
    {
        DeactivateAllCanvasses();
        canvasses[0].SetActive(true);
        coins.SetActive(false);
        fullscreenSlider.onValueChanged.AddListener(delegate { FullScreen(); });
    }
    void Awake()
    {
        roomButtonText = GetComponent<TextMeshProUGUI>();
    }
    public void Update()
    {
        if (canvasses[0].activeSelf == true || canvasses[5].activeSelf == true)
        {
            coins.SetActive(false);
        }
        else
        {
            coins.SetActive(true);
        }

        if (Input.anyKey)
        {
            if (canvasses[0].activeSelf == true)
            {
                DeactivateAllCanvasses();
                canvasses[1].SetActive(true);
            }
            if (canvasses[5].activeSelf == true || canvasses[6].activeSelf == true)
            {
                DeactivateAllCanvasses();
                canvasses[4].SetActive(true);
            }
        }
    }
    void DeactivateAllCanvasses()
    {
        for (int i = 0; i < canvasses.Length; i++)
        {
            canvasses[i].SetActive(false);
        }
    }
    public void PlayButton()
    {
        DeactivateAllCanvasses();
        canvasses[1].SetActive(true);
    }
    public void SkinButton()
    {
        DeactivateAllCanvasses();
        canvasses[2].SetActive(true);
    }
    public void ShopButton()
    {
        DeactivateAllCanvasses();
        canvasses[3].SetActive(true);
    }
    public void SettingsButton()
    {
        DeactivateAllCanvasses();
        canvasses[4].SetActive(true);
    }
    public void RoomButton()
    {
        DeactivateAllCanvasses();
        canvasses[7].SetActive(true);
    }
    public void CreateRoomButton()
    {
        Debug.Log("Create Room Button Pressed");
    }
    public void FindRoomButton()
    {
        Debug.Log("Find Room Button Pressed");
        roomButtonText.text = "quit room";
    }
    public void ControlsSettingsButton()
    {
        DeactivateAllCanvasses();
        canvasses[6].SetActive(true);
    }
    public void CreditsButton()
    {
        DeactivateAllCanvasses();
        canvasses[5].SetActive(true);
    }
    public void ExitButton()
    {
        DeactivateAllCanvasses();
        canvasses[0].SetActive(true);
    }
    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
