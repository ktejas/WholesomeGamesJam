using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text dialogueText2;

    public Animator animator;

    private Queue<string> sentences;
    private Queue<string> sentences2;

    public float delay = 0.3f;
    private float originaldelay;

    void Start()
    {
        originaldelay = delay;
        sentences = new Queue<string>();
        sentences2 = new Queue<string>();
    }

    void Update()
    {
        if (Input.GetButton("Submit") && delay <= 0)
        {
            delay = originaldelay;
            DisplayNextSentence();
        }
    }

    void FixedUpdate()
    {
        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        sentences.Clear();
        sentences2.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string sentence2 in dialogue.sentences2)
        {
            sentences2.Enqueue(sentence2);
        }


        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        string sentence2 = sentences2.Dequeue();
        dialogueText2.text = sentence2;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
