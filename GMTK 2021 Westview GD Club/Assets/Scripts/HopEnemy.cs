using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopEnemy : MonoBehaviour
{
    public int jForceX, jForceY;
    public Rigidbody2D rb;
    public float timerInitVal;
    private float timer;

    public Transform groundCheck;
    public float checkRadius = .5f;
    public LayerMask whatIsGround;
    public bool isGrounded;

    public Transform wallCheck;
    bool hitWall;
    bool facingRight = true;
    private int fRight = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = timerInitVal;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        hitWall = Physics2D.OverlapCircle(wallCheck.position, checkRadius, whatIsGround);

        if (isGrounded)
        { 
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }
        if (timer <= 0) 
        {
            rb.AddForce(new Vector2(jForceX * fRight, jForceY));
            Debug.Log("wheeeee");
            timer = timerInitVal;
        }

        if (hitWall)
            flip();
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        fRight *= -1;

    }
}
