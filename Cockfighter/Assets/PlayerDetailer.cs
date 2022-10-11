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

    public Material[] mats2;

    void Start()
    {
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
                break;
            }
        }
    }
}
