using System;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public Color SelectedColor { get; private set; }



    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadColor();
    }

    public void StoreSelectedColor(Color selectedColor)
    {
        SelectedColor = selectedColor;
    }




    [Serializable]
    class SaveData
    {
        public Color teamColor;
    }

    public void SaveColor()
    {
        SaveData data = new()
        {
            teamColor = SelectedColor
        };

        string saveFile = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", saveFile);
    }

    public void LoadColor()
    {
        string saveFile = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(saveFile))
        {
            string json = File.ReadAllText(saveFile);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            SelectedColor = data.teamColor;
        }
    }
}