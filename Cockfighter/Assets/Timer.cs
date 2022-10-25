using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 124f;

    [SerializeField] TMP_Text countdownText;
    [SerializeField] GameObject drawCanvas;
    [SerializeField] GameObject timeOutCanvas;
    [SerializeField] GameObject cameraFollow;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 11)
        {
            countdownText.color = Color.red;
        }

        if (currentTime <= 0)
        {
            cameraFollow.GetComponent<MultipleTarget>().enabled = false;
            timeOutCanvas.SetActive(true);
            Invoke("DrawCanvas", 1f);
            Cursor.lockState = CursorLockMode.None;
            currentTime = 0;
        }

        DisplayTime(currentTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DrawCanvas()
    {
        drawCanvas.SetActive(true);
        PhotonNetwork.DestroyAll();
    }
}
