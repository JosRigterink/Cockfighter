using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    public GameObject[] canvasses;
    public GameObject[] skinMenuPages;
    public GameObject coins;
    public GameObject stageSelectButton;
    public Slider fullscreenSlider;
    public bool isHost;
    public bool isFullscreen;

    void Start()
    {
        DeactivateAllCanvasses();
        DeactivateAllSkinMenuPages();
        canvasses[0].SetActive(true);
        skinMenuPages[0].SetActive(true);
        coins.SetActive(false);
    }
    public void Update()
    {
        if (canvasses[0].activeSelf == true || canvasses[5].activeSelf == true || canvasses[6].activeSelf == true || canvasses[8].activeSelf == true || canvasses[9].activeSelf == true || canvasses[10].activeSelf == true || canvasses[11].activeSelf == true || canvasses[12].activeSelf == true)
        {
            coins.SetActive(false);
        }
        else
        {
            coins.SetActive(true);
        }

        if (Input.anyKey)
        {
            Invoke("Rotation", 1.5f);
            if (canvasses[0].activeSelf == true)
            {
                DeactivateAllCanvasses();
                canvasses[1].SetActive(true);
            }
            if (canvasses[6].activeSelf == true)
            {
                DeactivateAllCanvasses();
                canvasses[4].SetActive(true);
            }
        }
        if (fullscreenSlider.value == 0)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (canvasses[1].activeSelf == true)
            {
                canvasses[1].SetActive(false);
                canvasses[2].SetActive(true);
                return;
            }
            if (canvasses[2].activeSelf == true)
            {
                canvasses[2].SetActive(false);
                canvasses[3].SetActive(true);
                return;
            }
            if (canvasses[3].activeSelf == true)
            {
                canvasses[3].SetActive(false);
                canvasses[4].SetActive(true);
                return;
            }
            if (canvasses[4].activeSelf == true)
            {
                canvasses[4].SetActive(false);
                canvasses[13].SetActive(true);
                return;
            }
            if (canvasses[13].activeSelf == true)
            {
                canvasses[13].SetActive(false);
                canvasses[1].SetActive(true);
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (canvasses[1].activeSelf == true)
            {
                canvasses[1].SetActive(false);
                canvasses[13].SetActive(true);
                return;
            }
            if (canvasses[2].activeSelf == true)
            {
                canvasses[2].SetActive(false);
                canvasses[1].SetActive(true);
                return;
            }
            if (canvasses[3].activeSelf == true)
            {
                canvasses[3].SetActive(false);
                canvasses[2].SetActive(true);
                return;
            }
            if (canvasses[4].activeSelf == true)
            {
                canvasses[4].SetActive(false);
                canvasses[3].SetActive(true);
                return;
            }
            if (canvasses[13].activeSelf == true)
            {
                canvasses[13].SetActive(false);
                canvasses[4].SetActive(true);
                return;
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
    void DeactivateAllSkinMenuPages()
    {
        for (int i = 0; i < skinMenuPages.Length; i++)
        {
            skinMenuPages[i].SetActive(false);
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
        DeactivateAllSkinMenuPages();
        skinMenuPages[0].SetActive(true);
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
    }
    public void ControlsSettingsButton()
    {
        DeactivateAllCanvasses();
        canvasses[6].SetActive(true);
    }
    public void CreditsButton()
    {
        DeactivateAllCanvasses();
        canvasses[6].SetActive(true);
    }
    public void ExitButton()
    {
        DeactivateAllCanvasses();
        Application.Quit();
    }
    public void FullScreen()
    {
        if (fullscreenSlider.value == 0)
        {
            fullscreenSlider.value = 1;
        }
        else if (fullscreenSlider.value == 1)
        {
            fullscreenSlider.value = 0;
        }
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SkinMenuChickenButton()
    {
        DeactivateAllSkinMenuPages();
        skinMenuPages[0].SetActive(true);
    }
    public void SkinMenuColorButton()
    {
        DeactivateAllSkinMenuPages();
        skinMenuPages[1].SetActive(true);
    }
    public void SkinMenuHatButton()
    {
        DeactivateAllSkinMenuPages();
        skinMenuPages[2].SetActive(true);
    }
    public void SkinMenuTopButton()
    {
        DeactivateAllSkinMenuPages();
        skinMenuPages[3].SetActive(true);
    }
    public void SkinMenuBottomButton()
    {
        DeactivateAllSkinMenuPages();
        skinMenuPages[4].SetActive(true);
    }

    public void Rotation()
    {
        canvasses[1].GetComponentInChildren<MouseRotate>().enabled = true;
    }
}
