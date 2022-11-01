using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRope : MonoBehaviour
{
    public MultipleTarget cameraList;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AssignCollider", 2f);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void AssignCollider()
    {
        var tmp = new CapsuleCollider[2];


        tmp[0] = cameraList.players[1].GetComponent<CapsuleCollider>();
        tmp[1] = cameraList.players[2].GetComponent<CapsuleCollider>();

        gameObject.GetComponent<Cloth>().capsuleColliders = tmp;
        Debug.Log("hallo");
    }
}
