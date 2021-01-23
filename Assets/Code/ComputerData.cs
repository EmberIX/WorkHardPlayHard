using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ComputerData
{
    public List<string> itemList;
    public List<string> workList;

    public ComputerData(ItemTrack IT)
    {
        itemList = IT.itemList;
        workList = IT.workList;
    }
}