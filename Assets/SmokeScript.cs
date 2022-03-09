using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    [SerializeField]
    LeverScript leverAttached;
    Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    void Update()
    {
        if(leverAttached.isActivated)
        {
            anim.SetBool("smoke",true);
        }        
    }
}
