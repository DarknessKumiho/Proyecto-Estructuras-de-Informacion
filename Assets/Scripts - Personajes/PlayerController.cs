using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;

    public float speed_x;
    public float max_Speed;

    public float jump_Power;

    public bool grounded;

    public bool jump;
    private bool doubleJump;
    
    private Rigidbody2D rb2d;

    private SpriteRenderer sprite_Renderer;
    private Animator animator;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        
        sprite_Renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        animator.SetBool("Grounded", grounded);

        //saltar cuando estoy en el suelo
        if (grounded)
        {
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;
            } else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }
        }
    }

    void FixedUpdate()
    {
        //Friccion Horizontal mientras toca el suelo
        Vector2 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.85f;

        if (grounded && (Input.GetAxis("Horizontal") == 0))
        {
            rb2d.velocity = fixedVelocity;
        }
        if ((Mathf.Abs(rb2d.velocity.x) < 0.25))
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        //Aplicar velocidad horizontal
        horizontalInput = Input.GetAxis("Horizontal");
        rb2d.AddForce(Vector2.right * speed_x * horizontalInput);

        //Girar el sprite a izquierda o derecha
        if(rb2d.velocity.x < 0)
        {
            sprite_Renderer.flipX = true;
        }
        if(rb2d.velocity.x > 0)
        {
            sprite_Renderer.flipX = false;
        }

        //Saltar
        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jump_Power, ForceMode2D.Impulse);
            jump = false;
        }

        //Limitadores de velocidad
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -max_Speed, max_Speed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

    }

    void OnBecameInvisible()
    {
        if (transform.position.y < -7)
        {
            transform.position = new Vector2(-7f, -2.7f);
        }
    }

}
