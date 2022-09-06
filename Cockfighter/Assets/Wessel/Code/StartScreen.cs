using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public GameObject[] canvasses;

    void Start()
    {
        canvasses[0].SetActive(true);
        canvasses[1].SetActive(false);
    }

    public void Update()
    {
        if (canvasses[0].activeInHierarchy == true)
        {
            if (Input.anyKey)
            {
                canvasses[0].SetActive(false);
                canvasses[1].SetActive(true);
            }
        }
    }
}
