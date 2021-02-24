using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager DM;
    public GameObject E;
    public bool isAtPosition;
    public bool isDialogue;
    PlayerScript PS;

    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
    }

    public void Update()
    {

        if (Input.GetKeyDown("e") && isAtPosition && isDialogue && DM.sentences.Count != 0)
        {
            DM.DisplayNextSentence();
            PS.isInteracted = true;
        }
        else if (Input.GetKeyDown("e") && isDialogue && DM.sentences.Count == 0)
        {
            DM.EndDialogue();
            PS.isInteracted = false;
            return;
        }

        if (Input.GetKeyDown("e") && isAtPosition && isDialogue == false)
        {
            TriggerDialogue();
            PS.isInteracted = true;

        }
       
    }

    public void TriggerDialogue()
    {
        DM.StartDialogue(dialogue);
        isDialogue = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            isAtPosition = true;
            E.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {

            isAtPosition = false;
            E.SetActive(false);

        }
    }
}
