using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Rigidbody>().AddForce(-transform.forward * 8, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
