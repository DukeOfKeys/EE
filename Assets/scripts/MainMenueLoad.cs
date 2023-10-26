using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class MainMenueLoad : ScriptableObject
{
    public float tempX, tempY;
    public void OnLoadButton()
    {
        if (File.Exists(Application.persistentDataPath + "/DataSaves.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/DataSaves.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            tempX = data.posX;
            tempY = data.posY;
            Debug.Log("Game data loaded!");
            Debug.Log($"{tempX}, {tempY}");
        }
        else
        {
            tempX = 263.37f;
            tempY = 263.37f;
            Debug.Log("There is no save data!");
        }

    }
}
