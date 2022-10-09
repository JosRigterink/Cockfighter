using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

using PhotonHashTable = ExitGames.Client.Photon.Hashtable;

public class Costumizer : MonoBehaviour
{
    public Material chickenMat;
    public Material glovesShirtMat;

    private PhotonHashTable hash = new PhotonHashTable();

    public List<Material> colorMaterials;
    private List<string> materialNames = new List<string>();

    public static List<Material> materials;

    public int matIndex;
    public string currentMaterialName;
    


    // Start is called before the first frame update
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeMat();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
           // GameObject.Find("Chicken Normal").GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.cyan;
            //chickenMat.color = GameObject.Find("Chicken Normal").GetComponentInChildren<SkinnedMeshRenderer>().material.color;
        }
    }

    public void ChangeMat()
    {
        //chickenMat.color = Color.red;
        //GameObject.Find("Chicken Normal").GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
        //chickenMat.color = GameObject.Find("Chicken Normal").GetComponentInChildren<SkinnedMeshRenderer>().material.color;
    }

    public void SetColor(int index)
    {
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
