using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentWeapon : MonoBehaviour
{
    public GameObject penIm;
    public GameObject noteBookIm;
    public PlayerScript Ps;

    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        penIm = GameObject.FindGameObjectWithTag("penIm");
        noteBookIm = GameObject.FindGameObjectWithTag("noteBookIm");

        penIm.SetActive(false);
        noteBookIm.SetActive(false);

        if(Ps.weapon == "pen")
        {
            penIm.SetActive(true);
            noteBookIm.SetActive(false);
        }

        if (Ps.weapon == "noteBook")
        {
            penIm.SetActive(false);
            noteBookIm.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPen()
    {
        Ps.weapon = "pen";
        penIm.SetActive(true);

        noteBookIm.SetActive(false);
    }

    public void OnClickNoteBook()
    {
        Ps.weapon = "noteBook";

        penIm.SetActive(false);
        //penUse.SetActive(false);

        noteBookIm.SetActive(true);
        //noteBookUse.SetActive(true);
    }
}
