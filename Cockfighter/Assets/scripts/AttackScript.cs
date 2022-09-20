using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AttackScript : MonoBehaviour
{
    PhotonView pv;
    public GameObject attackRight;
    public GameObject attackLeft;
    public GameObject blockPlaceHolder;
    public Collider[] attackHitBoxes;
    private PlayerController playerscript;
    public float damage;
    public bool isBlocking;


    public float rightAttackCooldown;
    public float leftAttackCooldown;
    public float blockCooldown;
    //public float damage;
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
                //Right Uppercut
                if (!isBlocking && Time.time > rightAttackCooldown && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.E))
                {
                    rightAttackCooldown = Time.time + 5f;
                    attack(attackHitBoxes[0]);
                    damage = Random.Range(15,20);
                    attackRight.SetActive(true);
                    Invoke("StopAttack", 0.5f);
                    Debug.Log("RightUppercut");
                }
            else //Right Hook
                if (!isBlocking && Time.time > rightAttackCooldown && Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.E))
                {
                    rightAttackCooldown = Time.time + 2f;
                    attack(attackHitBoxes[0]);
                    damage = Random.Range(8, 13);
                    attackRight.SetActive(true);
                    Invoke("StopAttack", 0.3f);
                    Debug.Log("RightHook");
                }
             else //Right Jab
                if (!isBlocking && Time.time > rightAttackCooldown && Input.GetKeyDown(KeyCode.E))
                {
                    rightAttackCooldown = Time.time + 1f;
                    attack(attackHitBoxes[0]);
                    damage = Random.Range(3, 7);
                    attackRight.SetActive(true);
                    Invoke("StopAttack", 0.1f);
                    Debug.Log("RightJab");
                }
                //Left Uppercut
                if (!isBlocking && Time.time > leftAttackCooldown && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.Q))
                {
                    leftAttackCooldown = Time.time + 5f;
                    attack(attackHitBoxes[1]);
                    damage = Random.Range(15, 20);
                    attackLeft.SetActive(true);
                    Invoke("StopAttack", 0.5f);
                    Debug.Log("LeftUppercut");
                }

            else //Left Hook
                if (!isBlocking && Time.time > leftAttackCooldown && Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Q))
                {
                    leftAttackCooldown = Time.time + 2f;
                    attack(attackHitBoxes[1]);
                    damage = Random.Range(8, 13);
                    attackLeft.SetActive(true);
                    Invoke("StopAttack", 0.3f);
                    Debug.Log("LeftHook");
                }
             else //Left Jab
                if (!isBlocking && Time.time > leftAttackCooldown && Input.GetKeyDown(KeyCode.Q))
                {
                    leftAttackCooldown = Time.time + 1f;
                    attack(attackHitBoxes[1]);
                    damage = Random.Range(3, 7);
                    attackLeft.SetActive(true);
                    Invoke("StopAttack", 0.1f);
                    Debug.Log("LeftJab");
                }
        }
        {
           
            if (Input.GetKeyDown(KeyCode.X))
            {
                //uppercut atack 
                //attack(attackHitBoxes[2]);
            }

            if (Time.time > blockCooldown && Input.GetKeyDown(KeyCode.Space))
            {
                blockCooldown = Time.time + 5f;
                isBlocking = true;
                blockPlaceHolder.SetActive(true);
                Invoke("StopAttack", 2f);
                Debug.Log("Blocking");
            }
        }
    }

    void StopAttack()
    {
        attackRight.SetActive(false);
        attackLeft.SetActive(false);
        blockPlaceHolder.SetActive(false);
        isBlocking = false;
    }
    
    public void attack(Collider col)
    {
       Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, Quaternion.identity, LayerMask.GetMask("HitBox"));
        foreach (Collider c in cols)
        {
            if (c.transform.root == transform)
            continue;
           
            Debug.Log(c.name);

            switch (c.name)
            {
                case "Head":
                    c.transform.root.gameObject.GetComponent<PlayerController>().TakeDamage(damage * 2);
                    break;
                case "Body":
                    c.transform.root.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
                    break;
                default:
                    Debug.Log("Couldnt find any colliders");
                        break;
            }
        }
    }
}
