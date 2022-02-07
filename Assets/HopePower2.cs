using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopePower2 : MonoBehaviour
{
    public bool HopeActivated;

    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        HopeActivated=false;
    }

    void Update()
    {
        if(HopeActivated)
        {
            Debug.Log("Activated");
            Invoke("BackToInvisible",5f);
        }    
        else
        Debug.Log("Deactivated");
    }

    void BackToInvisible()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.layer=0;
        HopeActivated=false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Add hope particle effect here later on
        if(col.tag=="Player" && Input.GetKeyDown("left shift") && !HopeActivated)
        {
            HopeActivated=true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.layer=7;
        }
    }
}
