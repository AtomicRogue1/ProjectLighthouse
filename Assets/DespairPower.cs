using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespairPower : MonoBehaviour
{
    public bool DespairActivated;

    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        DespairActivated=false;
    }

    void Update()
    {
        if(DespairActivated)
        {
            Debug.Log("Activated");
            Invoke("BackToVisible",5f);
        }    
        else
        Debug.Log("Deactivated");
    }

    void BackToVisible()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.layer=7;
        DespairActivated=true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Add hope particle effect here later on
        if(col.tag=="Player" && Input.GetKeyDown("z") && !DespairActivated)
        {
            DespairActivated=true;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.layer=0;
        }
    }
}
