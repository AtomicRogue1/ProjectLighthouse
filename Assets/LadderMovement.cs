using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    float vertical;
    [SerializeField]
    float speed=0.5f;
    bool isLadder;
    bool isClimbing;
    [SerializeField]
    Rigidbody2D rb2d;

    void Update()
    {
        vertical=Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(vertical)>0f)
        isClimbing=true;
    }

    void FixedUpdate()
    {
        if(isClimbing)
        {
            rb2d.gravityScale=0f;
            rb2d.velocity=new Vector2(rb2d.velocity.x, vertical*speed);
        }
        else
        {
            rb2d.gravityScale=1f;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ladder"))
        isLadder=true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Ladder"))
        {
            isLadder=false;
            isClimbing=false;
        }
    }
}
