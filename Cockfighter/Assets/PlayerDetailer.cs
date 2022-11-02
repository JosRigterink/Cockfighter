using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerDetailer : MonoBehaviourPunCallbacks
{
    public List<Material> materials;
    public List<Material> materials2;

    public string materialName;
    public string materialName2;

    public GameObject hoodie;
    public GameObject sunglasses;
    public GameObject bucket;

    public bool boolHoodie;
    public bool boolSunglasses;
    public bool boolBucket;

    public Material[] mats2;

    void Start()
    {
        boolHoodie = (bool)photonView.Owner.CustomProperties["hoodie"];
        boolSunglasses = (bool)photonView.Owner.CustomProperties["sunglasses"];
        boolBucket = (bool)photonView.Owner.CustomProperties["bucket"];

        if (boolHoodie == true)
        {
            hoodie.SetActive(true);
        }
        if (boolSunglasses == true)
        {
            sunglasses.SetActive(true);
        }
        if (boolBucket == true)
        {
            bucket.SetActive(true);
        }

        mats2 = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials;

        materials = Costumizer.materials;
        materialName = (string)photonView.Owner.CustomProperties["material"];
        foreach (Material material in materials)
        {
            if (material.name == materialName)
            {
                mats2[0] = material;
                gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials = mats2;
                break;
            }
        }

        materials2 = Costumizer.materials2;
        materialName2 = (string)photonView.Owner.CustomProperties["material2"];
        foreach (Material material2 in materials2)
        {
            if (material2.name == materialName2)
            {
                mats2[2] = material2;
                gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials = mats2;
                
                foreach (MeshRenderer meshRenderer in gameObject.GetComponentsInChildren<MeshRenderer>())
                {
                    foreach (Material mat in meshRenderer.materials)
                    {
                        mat.color = mats2[2].color;
                    }
                }
                //gameObject.GetComponentInChildren<MeshRenderer>().material.color = mats2[2].color;
                break;
            }
        }

        
    }
}
