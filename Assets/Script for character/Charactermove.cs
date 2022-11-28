using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermove : MonoBehaviour
{

    Rigidbody2D rigid;
    public float moveSpeed = 5f;
    public float jumpSpeed = 5f;
    float moveValue = 0f;
    float jumpValue = 0f;
    Animator anim;
    private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveValue = -moveSpeed;
            anim.SetBool("Moving", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveValue = moveSpeed;
            anim.SetBool("Moving", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            moveValue = 0f;
            anim.SetBool("Moving", false);
        }

        if (Input.GetKey(KeyCode.J))
        {
            anim.SetBool("Attack", true);

        }
        else
        {
            anim.SetBool("Attack", false);
        }


        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
            anim.SetBool("grounded", grounded);
        }

        
        
        rigid.velocity = new Vector2(moveValue, rigid.velocity.y + jumpValue);
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(jumpSpeed, rigid.velocity.x + jumpSpeed);
        anim.SetTrigger("Jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = true;
    }
}
