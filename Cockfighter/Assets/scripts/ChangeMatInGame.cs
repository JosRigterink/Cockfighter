using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangeMatInGame : MonoBehaviour
{
    public Material chickenMat;
    public Material glovesMat;
    PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        //chickenMat.color = GetComponentInChildren<SkinnedMeshRenderer>().material.color;
        
    }
}