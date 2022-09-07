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

    void Start()
    {
        DeactivateAllCanvasses();
        canvasses[0].SetActive(true);
        coins.SetActive(false);
    }
    public void Update()
    {
        if (canvasses[0].activeSelf == true)
        {
            coins.SetActive(false);
            if (Input.anyKey)
            {
                DeactivateAllCanvasses();
                canvasses[1].SetActive(true);
            }
        }
        else
        {
            coins.SetActive(true);
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
    public void AudioSettingsButton()
    {
        DeactivateAllCanvasses();
        canvasses[5].SetActive(true);
    }
    public void GraphicsSettingsButton()
    {
        DeactivateAllCanvasses();
        canvasses[6].SetActive(true);
    }
    public void ControlsSettingsButton()
    {
        DeactivateAllCanvasses();
        canvasses[7].SetActive(true);
    }
    public void CreditsButton()
    {
        DeactivateAllCanvasses();
        canvasses[8].SetActive(true);
    }
    public void ExitButton()
    {
        DeactivateAllCanvasses();
        canvasses[0].SetActive(true);
    }
}
