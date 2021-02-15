using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookPick : MonoBehaviour
{

    public GameObject noteBook;
    public PlayerScript PS;

    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(noteBook, transform.position, Quaternion.identity);
            PS.weapon = "noteBook";
            Destroy(this.gameObject);
        }
    }
}
