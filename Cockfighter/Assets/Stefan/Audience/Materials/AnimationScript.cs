using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {   
        Animator controller = GetComponent<Animator>();

        float randomOffset = Random.Range(0f, 1f);
        controller.Play("Audience", 0, randomOffset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
