using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float x;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    private int jumpnum=0;
    [SerializeField]
    private int jumpCount = 2;
    [SerializeField]
    Transform pos;
    [SerializeField]
    float radius;
    [SerializeField]
    LayerMask layer;
    bool isGround;
    [SerializeField]
    private PlayerMove movement2D;
    private Rigidbody2D rigid2D;
    [SerializeField]
    private float speed=5.0f;
    private float JumpForce = 5.0f;

    private void Awake()
    {
        movement2D = GetComponent<PlayerMove>();
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetBool("tAttack", false);
        animator.SetBool("dAttack", false);
        animator.SetBool("Attack", false);
        x = Input.GetAxisRaw("Horizontal");
        movement2D.move(x);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        isGround = Physics2D.OverlapCircle(pos.position, radius, layer);
        if (isGround)
        {
            animator.SetTrigger("Ground");
            jumpnum = jumpCount;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            doubleAttack();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            treeAttack();
        }
    }
    public void move(float x)
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        }
        if (x > 0 || x<0)
        {
            if (x < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if(x>0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
            animator.SetBool("Run", true);
        }
        else if (x == 0)
        {
            rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
            animator.SetBool("Run", false);
        }
    }
    public void Jump()
    {

        if (jumpnum > 0)
        {
            animator.SetTrigger("Jump");
            rigid2D.velocity = Vector2.up * JumpForce;
            --jumpnum;
        }
    }
      public void Attack()
        {
        animator.SetBool("Attack", true);
      
    }
    public void doubleAttack()
    {
        animator.SetBool("dAttack", true);
    }
    public void treeAttack()
    {
        animator.SetBool("tAttack", true);
    }
}
