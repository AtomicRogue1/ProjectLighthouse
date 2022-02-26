using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespairPower : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D col)
    {
        //Add hope particle effect here later on
        if(col.tag=="Player" && Input.GetKey("z"))
        {
            Destroy(gameObject);
        }
    }
}
