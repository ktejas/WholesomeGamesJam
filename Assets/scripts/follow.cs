using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    public Rigidbody2D rb;
    public Animator anim;

    public Transform target;

    Vector2 Movement;
    Vector3 oldpos;

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        Movement = transform.position - oldpos;

        if (Movement.y < 0)
        {
            anim.SetBool("down", true);

            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
        }
        else if (Movement.y > 0)
        {
            anim.SetBool("up", true);

            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("down", false);
        }

        if (Movement.x < -0.002)
        {
            anim.SetBool("left", true);

            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        else if (Movement.x > 0.002)
        {
            anim.SetBool("right", true);

            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }

        if (Movement == new Vector2(0, 0))
        {
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }

        oldpos = transform.position;
    }
}
