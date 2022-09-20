using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPunCallbacks, IDamageable
{
    [SerializeField] Image healthbarImage;
    [SerializeField] GameObject ui;

    [SerializeField] public float sprintSpeed, walkSpeed, smoothTime;

    float verticalLookRotation;
    public Vector3 smoothMoveVelocity;
    public  Vector3 moveAmount;

    public Rigidbody rb;

    PhotonView PV;
    public MultipleTarget cameraFollowScript;
    public GameObject lookAtPoint;

    const float maxHealth = 100f;
    public float currentHealth = maxHealth;

    PlayerManager playerManager;
    public GameObject player;


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
        //transform.LookAt(cam.transform);

        player = GameObject.Find("PlayerController(Clone)");




        if (PV.IsMine)
        {
            Debug.Log("mine");
        }
        else
        {
            //Destroy(GetComponentInChildren<LookAtScript>().gameObject);
            Destroy(rb);
        }
    }

    void Update()
    {
        if (!PV.IsMine)
        {
            if (cameraFollowScript.players.Contains(transform) && cameraFollowScript.players.Contains(player.transform))
            {
                transform.LookAt(player.transform);
                player.transform.LookAt(transform);
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
        if (!PV.IsMine)
        {
            return;
        }
        currentHealth -= damage;

        healthbarImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerManager.Die();
    }
}
