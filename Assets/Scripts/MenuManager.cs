using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string PlayerName;
    public int PlayerScore;
    public string BestPlayer;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBest();
    }




    [System.Serializable]
    class SaveData
    {
        public string BestPlayer;
        public int PlayerScore;
    }

    public void SaveBest()
    {
        SaveData data = new SaveData();
        data.BestPlayer = BestPlayer; 
        data.PlayerScore = PlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBest()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayer = data.BestPlayer;
            PlayerScore = data.PlayerScore;
        }
    }
}
