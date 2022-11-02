using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class Costumizer : MonoBehaviour
{
    public GameObject chickenDummie;
    public GameObject chickenDummieMenu;

    public bool enableHoodie;
    public bool enableSunglasses;
    public bool enableBucket;

    private PhotonHashTable hash = new PhotonHashTable();
    private PhotonHashTable hash2 = new PhotonHashTable();
    private PhotonHashTable hash3 = new PhotonHashTable();
    private PhotonHashTable hash4 = new PhotonHashTable();
    private PhotonHashTable hash5 = new PhotonHashTable();

    public List<Material> colorMaterials;
    public List<Material> colorMaterials2;
    private List<string> materialNames = new List<string>();
    private List<string> materialNames2 = new List<string>();

    public static List<Material> materials;
    public static List<Material> materials2;

    public int matIndex;
    public int matIndex2;
    public string currentMaterialName;
    public string currentMaterialName2;

    public static Material[] mats;

    public void EnableHoodie(bool booltje)
    {
        enableHoodie = booltje;
    }
    public void EnabledSunglasses(bool booltje)
    {
        enableSunglasses = booltje;
    }
    public void EnableBucket(bool booltje)
    {
        enableBucket = booltje;
    }
    void Start()
    {
        mats = chickenDummie.GetComponentInChildren<SkinnedMeshRenderer>().materials;

        materials = colorMaterials;

        foreach (Material material in colorMaterials)
        {
            materialNames.Add(material.name);
        }

        materials2 = colorMaterials2;

        foreach (Material material2 in colorMaterials2)
        {
            materialNames2.Add(material2.name);
        }
    }

    void Update()
    {
        SetColor(matIndex);
        SetColor2(matIndex2);
    }

    public void SetColor(int index)
    {
        mats[0] = materials[index];
        //chickenDummie.GetComponentInChildren<SkinnedMeshRenderer>().material = materials[index];
        chickenDummie.GetComponentInChildren<SkinnedMeshRenderer>().materials = mats;
        //chickenDummie.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].color = materials[index].color;

        matIndex = index;
        currentMaterialName = materialNames[index];
        if (PhotonNetwork.IsConnected)
        {
            SetHash();
        }
    }

    public void SetColor2(int index2)
    {
        //chickenDummie.GetComponentInChildren<SkinnedMeshRenderer>().materials[2]     = materials2[index2];
        mats[2] = materials2[index2];
        //chickenDummie.GetComponentInChildren<SkinnedMeshRenderer>().materials[2] = mats[2];
        chickenDummie.GetComponentInChildren<SkinnedMeshRenderer>().materials = mats;
        chickenDummieMenu.GetComponentInChildren<SkinnedMeshRenderer>().materials = mats;

        foreach (MeshRenderer meshRenderer in chickenDummie.GetComponentsInChildren<MeshRenderer>())
        {
            foreach (Material material in meshRenderer.materials)
            {
                material.color = mats[2].color;
            }
        }
        foreach (MeshRenderer meshRenderer in chickenDummieMenu.GetComponentsInChildren<MeshRenderer>())
        {
            foreach (Material material in meshRenderer.materials)
            {
                material.color = mats[2].color;
            }
        }

        //hoodie.GetComponent<MeshRenderer>().materials[1].color = mats[2].color;
        //chickenDummie.GetComponentInChildren<MeshRenderer>().material.color = mats[2].color;
        //chickenDummieMenu.GetComponentInChildren<MeshRenderer>().material.color = mats[2].color;

        matIndex2 = index2;
        currentMaterialName2 = materialNames2[index2];
        if (PhotonNetwork.IsConnected)
        {
            SetHash2();
        }
    }
    public void SetHash()
    {
        hash["material"] = currentMaterialName;
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public void SetHash2()
    {
        hash2["material2"] = currentMaterialName2;
        hash3["hoodie"] = enableHoodie;
        hash4["sunglasses"] = enableSunglasses;
        hash5["bucket"] = enableBucket;
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash2);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash3);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash4);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash5);
    }

    void Rotation()
    {
        chickenDummieMenu.GetComponent<MouseRotate>().enabled = true;
    }
}
