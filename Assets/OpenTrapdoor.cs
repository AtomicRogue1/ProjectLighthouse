using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrapdoor : MonoBehaviour
{
    [SerializeField]
    LeverScript leverAttached;
    void Update()
    {
        if(leverAttached.isActivated==true)
        Destroy(gameObject);
    }
}
