using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onStartShow : MonoBehaviour
{
    public GameObject gameControl;
    // Start is called before the first frame update
    public GameObject gameField;
    public GameObject ScoreObj;
    private void Awake()
    {
        ScoreObj = gameControl.GetComponent<globalVar>().ScoreObj;
        gameField = gameControl.GetComponent<food>().gameField;
    }

    private void OnEnable()
    {
        if(ScoreObj != null)
        {
            ScoreObj.SetActive(false);
        }
        if(gameField != null)
        {
            Destroy(gameField);
        }

        globalVar.firstStart = true;
    }
}
