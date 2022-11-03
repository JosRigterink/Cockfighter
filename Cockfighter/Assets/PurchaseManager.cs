using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    public int intje;
    public ShopManager hoodie;
    public ShopManager sunglasses;
    public ShopManager bucket;

    public GameObject hoodieImages;
    public GameObject sunglassesImages;
    public GameObject bucketImages;

    public int buyhoodie;
    public int buysunglasses;
    public int buybucket;
    public void Purchased()
    {
        if (intje == 1)
        {
            if (Launcher.Instance.playerMoney >= hoodie.itemPriceInt)
            {
                hoodie.skinMenuButton.interactable = true;
                hoodieImages.SetActive(true);
                hoodie.shopMenuButton.interactable = false;
                Launcher.Instance.playerMoney -= hoodie.itemPriceInt;
                PlayerPrefs.SetInt("PlayerMoney", Launcher.Instance.playerMoney);
                Launcher.Instance.moneyText.text = Launcher.Instance.playerMoney.ToString();
                buyhoodie = 1;
                PlayerPrefs.SetInt("HoodieItem", buyhoodie);
            }
        }
        else if (intje == 2)
        {
            if (Launcher.Instance.playerMoney >= sunglasses.itemPriceInt)
            {
                sunglasses.skinMenuButton.interactable = true;
                sunglassesImages.SetActive(true);
                sunglasses.shopMenuButton.interactable = false;
                Launcher.Instance.playerMoney -= sunglasses.itemPriceInt;
                PlayerPrefs.SetInt("PlayerMoney", Launcher.Instance.playerMoney);
                Launcher.Instance.moneyText.text = Launcher.Instance.playerMoney.ToString();
                buysunglasses = 1;
                PlayerPrefs.SetInt("Sunglasses", buysunglasses);
            }
        }
        else if (intje == 3)
        {
            if (Launcher.Instance.playerMoney >= bucket.itemPriceInt)
            {
                bucket.skinMenuButton.interactable = true;
                bucketImages.SetActive(true);
                bucket.shopMenuButton.interactable = false;
                Launcher.Instance.playerMoney -= bucket.itemPriceInt;
                PlayerPrefs.SetInt("PlayerMoney", Launcher.Instance.playerMoney);
                Launcher.Instance.moneyText.text = Launcher.Instance.playerMoney.ToString();
                buybucket = 1;
                PlayerPrefs.SetInt("Bucket", buybucket);
            }
        }
    }
}
