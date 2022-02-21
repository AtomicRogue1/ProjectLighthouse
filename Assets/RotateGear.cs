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
    // Start is called before the first frame update
    void Start()
    {
        rotateNow=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(leverAttached.isActivated==true)
        {
            rotateNow=true;
        }
        if(rotateNow==true)
        {
            transform.Rotate(0,0,gearRPM);
        }        
    }
}
