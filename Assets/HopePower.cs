using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopePower : MonoBehaviour
{
    public bool HopeActivated;
    public GameObject TileInQuestion=null;

    void Start()
    {
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
        TileInQuestion.transform.GetChild(0).gameObject.SetActive(false);
        TileInQuestion.layer=0;
        HopeActivated=false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //Add hope particle effect here later on
        if(col.tag=="HopeTile" && Input.GetKeyDown("left shift") && !HopeActivated)
        {
            HopeActivated=true;
            TileInQuestion=col.gameObject;
            TileInQuestion.transform.GetChild(0).gameObject.SetActive(true);
            TileInQuestion.layer=7;
        }
    }
}
