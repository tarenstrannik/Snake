using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UIElements;

[Serializable]
public class SerializableLeaderboardEntryList
{
    public List<LeaderboardEntry> instances;
}
// Класс для хранения данных о лидерах
[System.Serializable]
public class LeaderboardEntry
{

    public string playerName;
    public int score;
}
public class LeaderboardManager : MonoBehaviour
{
    public string filename = "leaderboard.json";
    public SerializableLeaderboardEntryList collection;
    // Сохранение данных в файл
    public void SaveDataToFile(List<LeaderboardEntry> leaderboardData)
    {
       /* foreach (LeaderboardEntry entry in leaderboardData)
        {
            Debug.Log("Position: " + ", Player Name: " + entry.playerName + ", Score: " + entry.score);
        }*/
       // Debug.Log(leaderboardData.Count);
        SerializableLeaderboardEntryList serializableList = new SerializableLeaderboardEntryList();
        serializableList.instances = leaderboardData;

        string jsonData = JsonUtility.ToJson(serializableList);
#if UNITY_WEBGL
        // Выполнить сохранение в PlayerPref

    PlayerPrefs.SetString("Leaders", jsonData);
    PlayerPrefs.Save();
#else
        //Debug.Log(jsonData);
        string filePath = Path.Combine(Application.persistentDataPath, filename);
        //Debug.Log("File Path: " + filePath);

        try
        {
            File.WriteAllText(filePath, jsonData);
           // Debug.Log("File write operation completed successfully!");
        }
        catch (Exception e)
        {
            Debug.LogError("Error writing to file: " + e.Message);
        }
#endif
        // File.WriteAllText(Path.Combine(Application.persistentDataPath, filename), jsonData);
    }

    // Загрузка данных из файла
    public List<LeaderboardEntry> LoadDataFromFile()
    {
#if UNITY_WEBGL
string jsonData = PlayerPrefs.GetString("Leaders");
if(jsonData.Trim()!="")
{
                SerializableLeaderboardEntryList serializableList = JsonUtility.FromJson<SerializableLeaderboardEntryList>(jsonData);
                return serializableList.instances;
                }
                else
                {
                    return new List<LeaderboardEntry>();
                }
#else
        string filePath = Path.Combine(Application.persistentDataPath, filename);
        if (File.Exists(filePath))
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                SerializableLeaderboardEntryList serializableList = JsonUtility.FromJson<SerializableLeaderboardEntryList>(jsonData);
                return serializableList.instances;
            }
            catch (Exception e)
            {
                Debug.LogError("Error reading from file: " + e.Message);
                return new List<LeaderboardEntry>();
            }
        }
        else
        {
           // Debug.LogWarning("Leaderboard data file not found.");
            return new List<LeaderboardEntry>();
        }
#endif

    }
}
