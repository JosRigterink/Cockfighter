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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && hpPowerup == true)
        {
            other.gameObject.GetComponent<PlayerController>().currentHealth = 100f;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && doubleDmgPowerup == true)
        {
            //do double dmg stuff;
        }
    }
}
