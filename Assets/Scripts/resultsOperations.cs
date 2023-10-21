using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.EventSystems.EventTrigger;

public class resultsOperations : MonoBehaviour
{
    public TextMeshProUGUI score;
   private LeaderboardManager leaderboardManager;
    public  List<LeaderboardEntry> ListOfTheBest;
    private int minScore;
    // Start is called before the first frame update
    void Start()
    {
        leaderboardManager = GetComponent<LeaderboardManager>();
        ListOfTheBest = leaderboardManager.LoadDataFromFile();
        ListOfTheBest.Sort((x, y) => y.score.CompareTo(x.score));
        if (ListOfTheBest.Count > 0) minScore = ListOfTheBest[ListOfTheBest.Count - 1].score;
        else minScore = 0;
        //Debug.Log(minScore);
    }
    void saveRes(string plName)
    {
        LeaderboardEntry newLBentry =  new LeaderboardEntry { playerName = plName, score = int.Parse(score.text) };
        ListOfTheBest.Add(newLBentry);
        ListOfTheBest.Sort((x, y) => y.score.CompareTo(x.score));
        if (ListOfTheBest.Count > 10)
        {
            ListOfTheBest.RemoveRange(10, ListOfTheBest.Count - 10);
        }

        leaderboardManager.SaveDataToFile(ListOfTheBest);
    }
    public bool isRecord()
    {
        //Debug.Log(minScore+" "+ int.Parse(score.text)+" "+ ListOfTheBest.Count);
        if ( (int.Parse(score.text) > minScore) ||(ListOfTheBest.Count < 10))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
