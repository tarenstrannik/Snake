using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class loadLeaders : MonoBehaviour
{
    public GameObject leaderPrefab;
    public Vector3 firstLeaderPos = new Vector3(-132.9f, 81.9f, 0f);

    public GameObject GresOps;
    public GameObject leaders;
    private List<LeaderboardEntry> ListOfTheBest;
    private GameObject lidTemp;
    // Start is called before the first frame update
    void OnEnable()
    {
        for (int j = 0; j < leaders.transform.childCount; j++)
        {
            // Получаем ссылку на дочерний объект
            GameObject childObject = leaders.transform.GetChild(j).gameObject;

            // Уничтожаем дочерний объект
            Destroy(childObject);
        }

        ListOfTheBest = GresOps.GetComponent<resultsOperations>().ListOfTheBest;
        int i = 1;
        foreach (LeaderboardEntry entry in ListOfTheBest)
        {
            //Debug.Log(entry.playerName + " " + entry.score);
            if (i==1)
            {
                lidTemp= Instantiate(leaderPrefab, firstLeaderPos, Quaternion.identity);
                
            }
            else
            {
                lidTemp = Instantiate(leaderPrefab, firstLeaderPos- new Vector3(0f, lidTemp.GetComponent<RectTransform>().sizeDelta.y * (i-1), 0f), Quaternion.identity);
            }
            lidTemp.transform.SetParent(leaders.transform, false);
            lidTemp.GetComponent<TextMeshProUGUI>().text = "" + i;
            lidTemp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + entry.playerName;
            lidTemp.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + entry.score;
            i++;
        };

    }

}
