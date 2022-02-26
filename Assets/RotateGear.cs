using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGear : MonoBehaviour
{
    [SerializeField]
    float gearRPM;
    bool rotateNow;
    [SerializeField]
    LeverScript leverAttached;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        rotateNow=false;
    }

    void Update()
    {
        if(leverAttached)
        {
        if(leverAttached.isActivated==true)
        {
            rotateNow=true;
        }
        if(rotateNow==true)
        {
            rb2d.angularVelocity=gearRPM;
        }        
        }
        else
        rb2d.angularVelocity=gearRPM;

    }
}
