using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public string itemNameString;
    public int itemPriceInt;

    public Button skinMenuButton;
    public Button shopMenuButton;

    public int shopNumber;
    public PurchaseManager manager;

    public TMP_Text itemName;
    public TMP_Text itemPrice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy()
    {
        manager.intje = shopNumber;
        itemName.text = itemNameString;
        itemPrice.text = itemPriceInt.ToString();
    }
}
