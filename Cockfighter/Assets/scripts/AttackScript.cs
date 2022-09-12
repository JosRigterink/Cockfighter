using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AttackScript : MonoBehaviour
{
    PhotonView pv;
    public GameObject attackRight;
    public GameObject attackLeft;
    public Collider[] attackHitBoxes;
    private PlayerController playerscript;
    // Start is called before the first frame update

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }
    void Start()
    {
        playerscript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pv.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                attack(attackHitBoxes[0]);
                //attackRight.SetActive(true);
                //Invoke("StopAttack", 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                attack(attackHitBoxes[1]);
               //attackLeft.SetActive(true);
                //Invoke("StopAttack", 0.5f);
            }

        }
        
    }

   //* private void OnTriggerEnter(Collider other)
    //{
        //if (other.gameObject.tag == "AttackRight")
        //{
          // Debug.Log("HitwithRight");
          //playerscript.TakeDamage(10);   
        //}
       // if (other.gameObject.tag == "AttackLeft")
        //{
           // Debug.Log("hitwithleft");
           // playerscript.TakeDamage(10);
        //}
   
       //}

    void StopAttack()
    {
        attackRight.SetActive(false);
        attackLeft.SetActive(false);
    }
    
    public void attack(Collider col)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("HitBox"));
        foreach (Collider c in cols)
        {
            if (c.transform.root == transform)
            continue;

            Debug.Log(c.name);

            switch (c.name)
            {
                case "Head":
                    if (pv.IsMine)
                    {
                        playerscript.TakeDamage(30);
                    }
                    break;
                case "Body":
                    playerscript.TakeDamage(10);
                    break;
                default:
                    Debug.Log("Couldnt found any colliders");
                        break;
                

            }
        }
    }
}
