using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing2 : MonoBehaviour
{
    PlayerController moveScript;

    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;

    void Start()
    {
        moveScript = GetComponent<PlayerController>();
        dashCooldown = 0;
    }

    void Update()
    {
       dashCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(dashCooldown <= 0)
            {
               StartCoroutine(Dashh());
            }
        }
    }

    IEnumerator Dashh()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            transform.Translate(moveScript.moveAmount * dashSpeed * Time.deltaTime);
            //moveScript.rb.AddForce(moveScript.moveAmount * dashSpeed, ForceMode.Impulse);
            dashCooldown = 3;

            yield return null;
        }
    }
}
