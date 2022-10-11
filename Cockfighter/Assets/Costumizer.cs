using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class Costumizer : MonoBehaviour
{
    public GameObject chickenDummie;

    private PhotonHashTable hash = new PhotonHashTable();
    private PhotonHashTable hash2 = new PhotonHashTable();

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
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash2);
    }
}
