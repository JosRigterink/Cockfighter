using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviourPunCallbacks, IDamageable
{
    [SerializeField] public Image healthbarImage;
    [SerializeField] GameObject ui;

    [SerializeField] public float sprintSpeed, walkSpeed, smoothTime;

    [SerializeField] public GameObject chicken;
    public GameOverScript gameover;

    float verticalLookRotation;
    public Vector3 smoothMoveVelocity;
    public  Vector3 moveAmount;

    public Rigidbody rb;

    public AttackScript attackScript;

    public Animator animator;

    PhotonView PV;
    public MultipleTarget cameraFollowScript;

    public const float maxHealth = 100f;
    public float currentHealth = maxHealth;

    PlayerManager playerManager;
    public GameObject player;
    public GameObject ragdoll;

   
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        cameraFollowScript = GameObject.FindGameObjectWithTag("FollowCamera").GetComponent<MultipleTarget>();
        //lookAtPoint = GameObject.FindGameObjectWithTag("LookTag");

        playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
    }

    void Start()
    {
        cameraFollowScript.players.Add(this.transform);
        Cursor.lockState = CursorLockMode.Locked;

        player = GameObject.Find("PlayerController(Clone)");

        animator.applyRootMotion = true;

        if (PV.IsMine)
        {
            Debug.Log("mine");
        }
        else
        {
            Destroy(rb);
            Destroy(ui);
        }
    }

    void Update()
    {
        if (!PV.IsMine)
        {
            if (currentHealth <= 0)
            {
                cameraFollowScript.enabled = false;
                this.enabled = false;
            }

            if (cameraFollowScript.players.Contains(transform) && cameraFollowScript.players.Contains(player.transform))
            {
                if (chicken.activeSelf)
                {
                    transform.LookAt(player.transform);
                    player.transform.LookAt(transform);
                }
                else
                {
                    transform.LookAt(transform);
                    player.transform.LookAt(cameraFollowScript.gameObject.transform);
                }
            }        
            return;
        }
        Move();

        if (transform.position.y < -10f)// kills player when it falls off the map
        {
            Die();
        }
    }

   public void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        animator.SetFloat("X", Input.GetAxis("Horizontal"));
        animator.SetFloat("Y", Input.GetAxis("Vertical"));
        if(Input.GetAxisRaw("Vertical") != 0f)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
        if (Input.GetAxisRaw("Horizontal") != 0f)
        {
            animator.SetLayerWeight(1, 1);
        }


        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }

    public void FixedUpdate()
    {
        if (!PV.IsMine)
        {
            return;
        }
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    public void TakeDamage(float damage)
    {
        PV.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        //if (!PV.IsMine)
        //{
            //return;
        //}
        currentHealth -= damage;

        if (PV.IsMine)
        {
            healthbarImage.fillAmount = currentHealth / maxHealth;
        }

        //healthbarImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
            this.enabled = false;
            cameraFollowScript.enabled = false;
        }
    }

    void Die()
    {
        if (PV.IsMine)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            GameObject copy = PhotonNetwork.Instantiate(ragdoll.name, transform.localPosition + new Vector3(0, -1, 0), transform.localRotation);
            //copy.GetComponentInChildren<Rigidbody>().AddForce(new Vector3(ragdoll.transform.localPosition.x, ragdoll.transform.localPosition.y + 5, ragdoll.transform.localPosition.z - 5));
            
            GetComponent<PhotonTransformView>().enabled = false;
            walkSpeed = 0;
            attackScript.enabled = false;
         
            playerManager.Die();
        }
        else
        {
            walkSpeed = 0;
            rb.freezeRotation = true;
            attackScript.enabled = false;
        }
    }

     public void HPbarUpdate()
    {
        if (PV.IsMine)
        {
            healthbarImage.fillAmount = currentHealth / maxHealth;
        }
    }
}
