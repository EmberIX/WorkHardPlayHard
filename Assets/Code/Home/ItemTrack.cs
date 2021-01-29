using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrack : MonoBehaviour
{
    public List<string> itemList;
    public List<string> workList;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SaveData()
    {
        SaveSetting.SaveInfoData(this);
    }

    public void LoadData()
    {
        ComputerData data = SaveSetting.LoadData();

        itemList = data.itemList;
        workList = data.workList;
    }
}
