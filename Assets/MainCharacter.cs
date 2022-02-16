using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [Header("For Jump Mechanics:")]
    [SerializeField]
    float jumpCooldownTime;
    [SerializeField]
    Transform groundDetector1;
    [SerializeField]
    Transform groundDetector2;
    [SerializeField]
    float JumpVelocity;

    [SerializeField]
    float smoothTime;
    
    [SerializeField]

    [Header("For Movement Mechanics:")]
    float moveSpeed;
    Vector2 moveDir=Vector2.right;
    SpriteRenderer sr;
    Rigidbody2D rb2d;
    Animator anim;

    [Header("Debug Stuff:")]
    [SerializeField] bool debugGroundDetector=false;
    [SerializeField] bool debugWallDetector=false;
    public bool hasJumped;

    bool isGrounded()
    {
        float distFromGround=Mathf.Abs(transform.position.y-groundDetector1.position.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,-Vector2.up,distFromGround, LayerMask.GetMask("Ground"));
        float distFromGround2=Mathf.Abs(transform.position.y-groundDetector2.position.y);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position,-Vector2.up,distFromGround2, LayerMask.GetMask("Ground"));
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


    void Animations()
    {
        if(isGrounded())
        {
        if(!Mathf.Approximately(rb2d.velocity.x,0f))
        anim.Play("Run");
        else
        anim.Play("Idle");
        }
        else
        {
            if(rb2d.velocity.y>0)
            anim.Play("JumpBeginning");
            else
            anim.Play("JumpEnding");
        }
    }
    void JumpCooldown()
    {
        hasJumped=false;
    }

    void Jump()
    {
        if(isGrounded() && Input.GetKey("space") && !hasJumped)
        {
            hasJumped=true;
            rb2d.velocity+=Vector2.up*JumpVelocity;
            Invoke("JumpCooldown",jumpCooldownTime);
        }
    }

    void Move()
    {
        if(Input.GetKey("right"))
        rb2d.velocity=new Vector2(moveSpeed,rb2d.velocity.y);
        else if(Input.GetKey("left"))
        rb2d.velocity=new Vector2(-moveSpeed,rb2d.velocity.y);
        else
        {
            float yVelocity=0f;
            float decreasingVelocity = Mathf.SmoothDamp(rb2d.velocity.x, 0, ref yVelocity, smoothTime);
            rb2d.velocity=new Vector2(decreasingVelocity,rb2d.velocity.y);
        };
    }

    void Start()
    {
        anim=GetComponent<Animator>();
        rb2d=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Animations();
        if(Input.GetKey("right"))
        sr.flipX=false;
        else if(Input.GetKey("left"))
        sr.flipX=true;
    }

    void FixedUpdate()
    {
        Jump();
        Move();
        DebugStuff();
    }
}
