using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject[] canvasses;
    public GameObject coins;
    public GameObject stageSelectButton;
    public bool isHost;
    public bool isFullscreen;

    void Start()
    {
        DeactivateAllCanvasses();
        canvasses[0].SetActive(true);
        coins.SetActive(false);
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

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("+ 100 coins");
            GetComponent<CoinManager>().AddCoins(100);
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
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
