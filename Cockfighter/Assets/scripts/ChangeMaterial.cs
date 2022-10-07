using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangeMaterial : MonoBehaviour
{
    public Material chickenMat;
    public Material glovesShirtMat;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeMat();
        }
    }

    public void ChangeMat()
    {
        chickenMat.color = Color.black;
        GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.black;
    }
}
