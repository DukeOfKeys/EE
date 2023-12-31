using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Saves : Hero
{
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/DataSaves.dat");
        SaveData data = new SaveData();
        data.posX = x;
        data.posY = y;
        bf.Serialize(file, data);
        file.Close();
    }

    void Start()
    {
        Load();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/DataSaves.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/DataSaves.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            x = data.posX;
            y = data.posY;
        }
        else
        {
            x = 263.37f;
            y = 263.37f;
        }

        teleportOnPos();    
    }

    public void teleportOnPos()
    {
        playerPos.transform.position = new Vector2(x, y);
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath + "/DataSaves.dat"))
        {
            File.Delete(Application.persistentDataPath + "/DataSaves.dat");
        }
    }
}

[Serializable]
class SaveData
{
    public float posX;
    public float posY;
}

