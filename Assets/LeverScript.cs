using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField]
    ConsequenceCam ConCam;
    public bool isActivated=false;
    Animator anim;
    BoxCollider2D triggerArea;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();    
        triggerArea=GetComponent<BoxCollider2D>();    
    }

    void Update()
    {
        if(isActivated)
        {
            isActivated=false;
            ConCam.ActivateCinematic=true;
            triggerArea.enabled=false;
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
