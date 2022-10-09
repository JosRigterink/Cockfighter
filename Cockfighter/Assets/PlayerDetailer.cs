using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerDetailer : MonoBehaviourPunCallbacks
{
    public List<Material> materials;

    public string materialName;

    // Start is called before the first frame update
    void Start()
    {
        materials = Costumizer.materials;
        materialName = (string)photonView.Owner.CustomProperties["material"];
        foreach (Material material in materials)
        {
            if (material.name == materialName)
            {
                gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = material;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
