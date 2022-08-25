using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private float moveInput;

    private Rigidbody2D rb;
    private bool faceRight = true;

    private int count = 0;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float getLevel;
    public GameObject player;
    public GameObject companionCrate;
    public Animator animator;
    public Animator run;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (run.GetBool("isJumping") == false)
        {
            count++;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (run.GetBool("isJumping") == false)
        {
            if (isGrounded && count > 10)
            {
                run.SetBool("isJumping", true);
                count = 0;
            }
        }

        if(rb.velocity.y > 0 && Input.GetKeyUp(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, y:rb.velocity.y/2f);
        }

        if(rb.velocity.y > 0)
        {
            rb.gravityScale = 2f;
        }
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = 3f;
        }
        if(rb.velocity.y == 0)
        {
            rb.gravityScale = 1f;
        }

        moveInput = Input.GetAxis("Horizontal");
        run.SetFloat("Speed", Mathf.Abs(moveInput));
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        rb.freezeRotation = true;

        if(faceRight == false && moveInput > 0)
        {
            flip();
        }
        else if(faceRight == true && moveInput < 0)
        {
            flip();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpHeight;
            run.SetBool("isJumping", false);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            restart();
        }
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetInteger("Attract") == 0)
        {
            animator.SetInteger("Attract", 1);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && animator.GetInteger("Attract") == 1)
        {
            animator.SetInteger("Attract", 0);
        }
    }

    void flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
