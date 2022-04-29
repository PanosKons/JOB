using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem //This class is responsible for saving-loading data
{
    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.dat";
        FileStream stream = new FileStream(path, FileMode.Create);
        SavedData savedData = new SavedData();
        savedData.Init();
        formatter.Serialize(stream, savedData);
        stream.Close();
    }
    public static void LoadData()
    {
        string path = Application.persistentDataPath + "/game.dat";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SavedData savedData = formatter.Deserialize(stream) as SavedData;
            DataManager.Gems = savedData.gems;
            DataManager.Coins = savedData.coins;
            DataManager.UnlockedLevel = savedData.level;
            stream.Close();
        }
        else
        {
            DataManager.UnlockedLevel = 0;
            DataManager.Coins = 50;
            DataManager.Gems = 10;
        }
    }
}
