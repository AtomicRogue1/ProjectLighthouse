using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeDown : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    LeverScript leverAttached;
    [SerializeField]
    GameObject Jar;

    // Update is called once per frame
    void Update()
    {
        if(leverAttached.isActivated)
        {
            Jar.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Jar.GetComponent<DespairPower>().enabled=true;
        }
        else
        {
            Jar.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            Jar.GetComponent<DespairPower>().enabled=false;
        }
    }

}
