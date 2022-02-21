using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFix : MonoBehaviour
{
    [SerializeField]
    Transform FixPoint;
    void Update()
    {
        transform.position=FixPoint.position;        
    }
}
