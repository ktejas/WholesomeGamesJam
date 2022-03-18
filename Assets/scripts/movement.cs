using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speed = 2f;
    public float sprintModifier;

    public SpriteRenderer sprite;

    public Animator anim;

    public Rigidbody2D rb;

    Vector2 Movement;

    void Update()
    {

        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        if (Movement.y < 0)
        {
            anim.SetBool("down", true);

            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
        }
        else if(Movement.y > 0)
        {
            anim.SetBool("up", true);

            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
        }

        if(Movement.x < 0)
        {
            anim.SetBool("left", true);

            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        else if(Movement.x > 0)
        {
            anim.SetBool("right", true);

            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }

    }

    void FixedUpdate()
    {
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float adjustedSpeed = speed;

        if (sprint)
        {
            adjustedSpeed *= sprintModifier;
        }

        rb.MovePosition(rb.position + Movement * adjustedSpeed * Time.fixedDeltaTime);
    }
}