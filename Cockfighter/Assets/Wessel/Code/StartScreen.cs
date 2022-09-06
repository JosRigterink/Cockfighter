using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject[] canvasses;

    void Start()
    {
        canvasses[0].SetActive(true);
        canvasses[1].SetActive(false);
    }

    public void PressAnywhere()
    {
        canvasses[0].SetActive(false);
        canvasses[1].SetActive(true);
    }
}
