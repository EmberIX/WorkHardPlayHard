using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public DialogueTrigger DT;
    public Queue<string> sentences;
    public Animator ani;

    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {

    }

    public void StartDialogue (Dialogue dialogue)
    {
        ani.SetBool("isOpen", true);
        
        nameText.text = dialogue.dialogueName;
        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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
        Debug.Log(sentence);
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        Debug.Log("EndDialogue");
        ani.SetBool("isOpen", false);
        DT.isDialogue = false;
    }
}
