using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSetting
{
    public static void SavePlayer(PlayerScript player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        string path = Application.persistentDataPath + "/playerS.Save";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        Debug.Log("Save");
        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerS.Save";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("Load");
            return data;
        }
        else
        {
            Debug.LogError("Save file Not found in " + path);
            return null;
        }
    }

    public static void SaveInfoData(ItemTrack IT)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/itemS.Save";

        FileStream stream2 = new FileStream(path, FileMode.Create);

        ComputerData data = new ComputerData(IT);

        Debug.Log("SaveData");
        formatter.Serialize(stream2, data);
        stream2.Close();

    }

    public static ComputerData LoadData()
    {
        string path = Application.persistentDataPath + "/itemS.Save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream2 = new FileStream(path, FileMode.Open);

            ComputerData data = formatter.Deserialize(stream2) as ComputerData;
            stream2.Close();
            Debug.Log("LoadData");
            return data;
        }
        else
        {
            Debug.LogError("Save file Not found in " + path);
            return null;
        }
    }
}
