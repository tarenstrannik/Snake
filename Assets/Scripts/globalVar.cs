using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class globalVar : MonoBehaviour
{
    

    public static bool menuActive = false;
    public GameObject gameFieldPrefab;
    public GameObject Snake;
    public GameObject SnakeHeadPrefab;
    public float widthPercentage = 0.95f;
    public GameObject ScoreObj;
    public TextMeshProUGUI scoreText;
    
    private snakeEatandGrowandDie SnScore;
    public float snakeSize = 0.2f;
    public static float ssnakeSize = 0.2f;
    public static float sdsnakeSize = 0.2f;
    public float spaceForScore = 1.5f;
    public float circleTime = 0.5f;
    public static float scircleTime = 0.5f;
    public static float sdcircleTime = 0.5f;
    public static float scicleTimeDecrement = 0.95f;
    public static float sdcicleTimeDecrement = 0.95f;
    public float cicleTimeDecrement = 0.95f;
  

    public int startSnakeLen = 3;
    public static int sstartSnakeLen;
    public static int sdstartSnakeLen;

    public static bool firstStart=true;
    public static bool isGameStarted = false;
    public static bool progressSaved = false;
    //public float deathStep = 0.5f;
    // Start is called before the first frame update
    private void Awake()
    {
        sstartSnakeLen = PlayerPrefs.GetInt("sstartSnakeLen", startSnakeLen);
        ssnakeSize = PlayerPrefs.GetFloat("ssnakeSize", snakeSize);
        scircleTime = PlayerPrefs.GetFloat("scircleTime", circleTime);
        scicleTimeDecrement = PlayerPrefs.GetFloat("scicleTimeDecrement", cicleTimeDecrement);


        sdstartSnakeLen = startSnakeLen;
        sdsnakeSize = snakeSize;
        sdcircleTime = circleTime;
        sdcicleTimeDecrement = cicleTimeDecrement;

        if (parametersStore.sfirstStart==false)
        {
            firstStart = false;
        }




    }
    void Start()
    {
        
       


        if (!firstStart)
        {
            GetComponent<keys>().Menu.SetActive(false);
            menuActive = GetComponent<keys>().Menu.activeSelf;
            ScoreObj.SetActive(true);
            StartGame();
        }
        else
        {
            ScoreObj.SetActive(false);
            parametersStore.sfirstStart = false;
            GetComponent<keys>().Menu.SetActive(true);
            menuActive = GetComponent<keys>().Menu.activeSelf;
            GetComponent<keys>().Menu.SendMessage("firstStart");
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            //Debug.Log(SnScore);
            scoreText.text = "" + SnScore.SnakeScore;
        }
    }
    void StartGame()
    {
        firstStart = false;
        isGameStarted = true;
        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = screenHeight * Camera.main.aspect;

        // Вычисляем высоту объекта пропорционально ширине экрана
        float objectWidth = screenWidth * widthPercentage;
        float objectHeight = screenHeight - spaceForScore;
        Vector2 gfPos = new Vector2(0, -spaceForScore / 3);
        // Создаем объект из префаба и устанавливаем его масштаб и позицию
        GetComponent<food>().gameField = Instantiate(gameFieldPrefab, gfPos, Quaternion.identity);
        GetComponent<food>().gameField.transform.localScale = new Vector3(objectWidth, objectHeight, 1f);

        Snake = Instantiate(SnakeHeadPrefab, gfPos, Quaternion.identity);
        Snake.transform.localScale = new Vector3(ssnakeSize, ssnakeSize, ssnakeSize);
        Snake.GetComponent <snakeEatandGrowandDie>().glVar = gameObject;
        GetComponent<keys>().SnakeHead = Snake;
        SnScore = Snake.GetComponent<snakeEatandGrowandDie>();
        /*
        for (int i = 0; i < sstartSnakeLen - 1; i++)
        {
            //   Debug.Log(SnScore.name + " " + SnScore.GetInstanceID());
            SnScore.SendMessage("Grow");
        }*/
    }

    void snakeDead()
    {
        StartCoroutine(IsnakeDead());
    }
    IEnumerator IsnakeDead()
    {
        while(true)
        {
            if(Snake==null)
            {
                GetComponent<keys>().Menu.SetActive(true);
                menuActive = GetComponent<keys>().Menu.activeSelf;
                GetComponent<keys>().Menu.SendMessage("result");
                yield break;
            }
            yield return null;
        }
    }
}
