using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    Vector2 moveDir=Vector2.right;
    public bool test;
    [SerializeField]
    Transform groundDetector1;
    [SerializeField]
    Transform groundDetector2;
    
    [SerializeField]
    float smoothTime;
    [SerializeField]
    float JumpVelocity;
    [SerializeField]
    float moveSpeed;
    SpriteRenderer sr;
    Rigidbody2D rb2d;
    Animator anim;

    [Header("Debug Stuff:")]
    [SerializeField] bool debugGroundDetector=false;
    [SerializeField] bool debugWallDetector=false;

    bool isGrounded()
    {
        float distFromGround=Mathf.Abs(transform.position.y-groundDetector1.position.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,-Vector2.up,distFromGround, LayerMask.GetMask("Ground"));
        float distFromGround2=Mathf.Abs(transform.position.y-groundDetector2.position.y);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position,-Vector2.up,distFromGround2, LayerMask.GetMask("Ground"));
        test=hit.collider || hit2.collider;
        return hit.collider || hit2.collider;
    }

    void DebugStuff()
    {
        if(debugGroundDetector)
        {
            Debug.DrawLine(transform.position,groundDetector1.position, Color.blue);
            Debug.DrawLine(transform.position,groundDetector2.position, Color.blue);
        }
        if(debugWallDetector)
        Debug.DrawRay(transform.position, moveDir, Color.blue);
    }

    void Start()
    {
        anim=GetComponent<Animator>();
        rb2d=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
    }

    void Animations()
    {
        if(isGrounded())
        {
        if(Input.GetKey("right")||Input.GetKey("left"))
        anim.Play("Run");
        else
        anim.Play("Idle");
        }

        if(Input.GetKey("right"))
        sr.flipX=false;
        else if(Input.GetKey("left"))
        sr.flipX=true;
    }

    void Jump()
    {
        if(isGrounded() && Input.GetKey("space"))
        {
        rb2d.velocity+=Vector2.up*JumpVelocity;
        }
    }

    void Move()
    {
        if(Input.GetKey("right"))
        rb2d.velocity=new Vector2(moveSpeed,rb2d.velocity.y);
        else if(Input.GetKey("left"))
        rb2d.velocity=new Vector2(-moveSpeed,rb2d.velocity.y);
        else
        rb2d.AddForce(Vector2.zero);
    }

    void Update()
    {
        Animations();
    }

    void FixedUpdate()
    {
        Jump();
        Move();
        DebugStuff();
    }

}




    //Notes for Future Games        
    //Move Code (If you want to change direction on hitting wall)
    // if(isWall())
    // {
    //     moveDir*=-1;
    //     right=-right;
    // }
    // if(right==1)
    // rb2d.velocity=new Vector2(moveSpeed,rb2d.velocity.y);
    // else
    // rb2d.velocity=new Vector2(-moveSpeed,rb2d.velocity.y);