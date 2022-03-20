using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubepuzzle : MonoBehaviour
{

    public GameObject cube;
    public GameObject collider;

    public GameObject effect;

    public Animator anim;

    bool isHere;

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "cube")
        {
            Destroy(cube);
            Destroy(collider);
            FindObjectOfType<AudioManager>().Play("step");
            anim.SetBool("open", true);
            effect.SetActive(true);
        }
    }
}
