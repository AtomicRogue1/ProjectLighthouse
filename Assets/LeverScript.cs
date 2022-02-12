using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    bool isActivated=false;
    [SerializeField]
    GameObject toChange;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();        
    }

    void Update()
    {
        if(isActivated)
        {
            isActivated=false;
            toChange.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag=="Player" && Input.GetKey("x"))
        {
            anim.SetBool("isActivated", true);
            isActivated=true;
        }
    }
}
