using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmusic : MonoBehaviour
{
    public GameObject music;
    public GameObject music2;
    public GameObject music3;

    public int selected = 0;

    void Update()
    {
        if(selected == 1)
        {
            music.SetActive(true);
            music2.SetActive(false);
            music3.SetActive(false);
        }
        else if(selected == 2)
        {
            music.SetActive(false);
            music2.SetActive(true);
            music3.SetActive(false);
        }
        else if(selected == 3)
        {
            music.SetActive(false);
            music2.SetActive(false);
            music3.SetActive(true);
        }
        else if(selected == 0)
        {
            music.SetActive(false);
            music2.SetActive(false);
            music3.SetActive(false);
        }
    }

    public void play(int number)
    {
        selected = number;
    }
}
