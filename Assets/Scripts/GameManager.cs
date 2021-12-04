using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public InputField EnterName;

    public string PlayerName;
    public string BestScoreName;
    public int PlayerScore;
    public int BestScore;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);


        LoadPlayerData();
        BestScoreF();
    }

    private void Start()
    {
        EnterName.onValueChanged.AddListener(EnterNamePlayer);
        
    }

    public void EnterNamePlayer(string data)
    {

        GameManager.instance.PlayerName = data;

    }

    public void BestScoreF()
    {
        if (PlayerScore > BestScore)
        {
            BestScore = PlayerScore;
            BestScoreName = PlayerName;
        }
    }

    [System.Serializable]

    class PlayerData
    {
        public string PlayerName;
        public string BestScoreName;
        public int PlayerScore;
        public int BestScore;
    }

    public void SavePlayerData()
    {
        PlayerData data = new PlayerData();
        data.PlayerName = PlayerName;
        data.PlayerScore = PlayerScore;
        data.BestScoreName = BestScoreName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefiles.json", json);

    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefiles.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            PlayerName = data.PlayerName;
            PlayerScore = data.PlayerScore;
            BestScoreName = data.BestScoreName;
            BestScore = data.BestScore;
        }
    }


}
