using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class Costumizer : MonoBehaviour
{
    public GameObject chickenDummie;

    private PhotonHashTable hash = new PhotonHashTable();

    public List<Material> colorMaterials;
    private List<string> materialNames = new List<string>();

    public static List<Material> materials;

    public int matIndex;
    public string currentMaterialName;
    

    void Start()
    {
        materials = colorMaterials;

        foreach (Material material in colorMaterials)
        {
            materialNames.Add(material.name);
        }
    }

    void Update()
    {
        SetColor(matIndex);
    }

    public void SetColor(int index)
    {
        chickenDummie.GetComponentInChildren<SkinnedMeshRenderer>().material = materials[index];
        matIndex = index;
        currentMaterialName = materialNames[index];
        if (PhotonNetwork.IsConnected)
        {
            SetHash();
        }
    }

    public void SetHash()
    {
        hash["material"] = currentMaterialName;
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}
