using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public GameObject f;

    private bool isHere;

    void Update()
    {

        f.SetActive(isHere);

        if(isHere && Input.GetKey("f"))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.gameObject.tag == "Player")
        {
            isHere = true;
        }
    }

    public void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {
            isHere = false;
        }
    }
}
