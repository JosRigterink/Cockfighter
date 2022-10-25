using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PowerUp : MonoBehaviour
{
    public bool hpPowerup;
    public bool doubleDmgPowerup;
    PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && hpPowerup == true)
        {
            powerup(other);
        }

        if (other.gameObject.tag == "Player" && doubleDmgPowerup == true)
        {
            //do double dmg stuff;
        }
    }

    public void powerup(Collider other)
    {
        other.gameObject.GetComponent<PlayerController>().currentHealth = 100f;
        other.gameObject.GetComponent<PlayerController>().HPbarUpdate();
        Destroy(gameObject);
    }
}
