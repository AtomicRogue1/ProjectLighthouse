using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour
{
    [SerializeField]
    LeverScript leverAttached;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;
    bool activate;
    void Start()
    {
        activate=false;
        rb2d=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(leverAttached.isActivated&&!activate)
        {
            rb2d.velocity=new Vector2(moveSpeed,0f);
            activate=true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "changeDir")
        rb2d.velocity=new Vector2(-rb2d.velocity.x,0f);
    }
}
