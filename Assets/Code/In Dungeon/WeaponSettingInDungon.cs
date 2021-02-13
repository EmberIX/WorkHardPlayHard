using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSettingInDungon : MonoBehaviour
{

    PlayerScript PS;
    public GameObject pen;
    public GameObject noteBook;
    public Texture2D customCursor;

    void Awake()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        PS.LoadPlayer();
        
        if(PS.weapon == "pen")
        {
            Instantiate(pen, transform.position, Quaternion.identity);
        }

        if (PS.weapon == "noteBook")
        {
            Instantiate(noteBook, transform.position, Quaternion.identity);
        }
    }

    void Start()
    {
        Vector2 cursoroffset = new Vector2(customCursor.width / 2, customCursor.height / 2);
        Cursor.SetCursor(customCursor, cursoroffset, CursorMode.Auto);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
