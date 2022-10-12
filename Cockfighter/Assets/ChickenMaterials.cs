using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMaterials : MonoBehaviour
{
    public Material[] newMaterials;
    // Start is called before the first frame update
    void Start()
    {
        newMaterials = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials;
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().materials[2] = newMaterials[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
