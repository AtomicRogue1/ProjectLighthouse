using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidContainer : MonoBehaviour
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
        if(leverAttached.isActivated==true)
        anim.SetBool("isToEmpty",true);
    }
}
