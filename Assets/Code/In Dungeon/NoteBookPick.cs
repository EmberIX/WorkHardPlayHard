using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBookPick : MonoBehaviour
{

    public GameObject noteBook;
    public PlayerScript PS;
    ChangeScene CS;

    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        CS = GameObject.FindObjectOfType<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PS.weapon = "noteBook";
            Destroy(this.gameObject);
            CS.LoadScene("Tutorial2");

        }
    }
}
