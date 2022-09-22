using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] [HideInInspector] public SaveData saveData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Load();
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    private void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData();
            saveData.lstScore = new List<Score>();
        }

    }

    public void Save()
    {
         string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}

[System.Serializable]
public class SaveData
{
    public List<Score> lstScore;
    public string currentUser;
    public int bestScore;
    public string bestPlayer;
}

[System.Serializable]
public class Score
{
    public int score;
    public string player;
    public string date;
    public Score(int iScore, string sPlayer)
    {
        score = iScore;
        player = sPlayer;
        date = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
}