using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject[] canvasses;
    public GameObject coins;

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
}
