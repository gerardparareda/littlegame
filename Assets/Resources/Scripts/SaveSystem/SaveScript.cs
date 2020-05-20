using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveScript
{
    public static void Save ()
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game_save";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        FileStream fs = new FileStream(path + "/data.kek", FileMode.Create);

        SaveData saveData = new SaveData();

        var json = JsonUtility.ToJson(saveData);
        bf.Serialize(fs, json);
        fs.Close();

        //InventoryData data = new InventoryData(inv);

        //formatter.Serialize(fs, data);
        //fs.Close();

    }
    
    public static void Load()
    {
        string path = Application.persistentDataPath + "/game_save";

        if (File.Exists(path + "/data.kek"))
        {
            // Load inventory save file
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path + "/data.kek", FileMode.Open);

            SaveData saveData = new SaveData();

            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(fs), saveData);

            // Copy data from variable to inventory, copy player stats, object position
            saveData.LoadToGame();

            fs.Close();
            Debug.Log("Loaded successfully!");
        } else
        {
            Debug.LogError("Inventory file not found path: " + path);
        }
    }



}
