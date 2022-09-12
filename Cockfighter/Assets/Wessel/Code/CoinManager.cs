using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinsAmount;
    public TextMeshProUGUI coinsText;

    void Start()
    {
        coinsText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        coinsText.text = coinsAmount.ToString();
    }
}
