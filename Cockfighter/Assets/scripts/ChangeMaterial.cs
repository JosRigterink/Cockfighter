using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangeMaterial : MonoBehaviour
{
    public Material chickenMat;
    public Material glovesShirtMat;
    PhotonView pv;

    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeMat();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.cyan;
            chickenMat.color = GetComponentInChildren<SkinnedMeshRenderer>().material.color;
        }
    }

    public void ChangeMat()
    {
       //chickenMat.color = Color.red;
       GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
       chickenMat.color =  GetComponentInChildren<SkinnedMeshRenderer>().material.color;
       
    }
}
