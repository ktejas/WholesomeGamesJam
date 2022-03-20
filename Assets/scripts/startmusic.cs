using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmusic : MonoBehaviour
{
    public GameObject music;

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            music.SetActive(true);
        }
    }
}
