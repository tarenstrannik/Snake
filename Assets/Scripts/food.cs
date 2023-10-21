using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class food : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject gameField;
    private GameObject curFood;

    private Vector2 bottomLeft;
    private Vector2 topRight;

    private float otstup;

    private bool fieldGenerated = false;
    // Start is called before the first frame update
    void Start()
    {
        otstup = globalVar.ssnakeSize/2;
        StartCoroutine(WaitForGFGen());
       

        // Генерируем случайные координаты внутри углов прямоугольника

    }

    // Update is called once per frame
    void Update()
    {
        if (curFood == null && fieldGenerated && gameField!=null)
        {
            curFood = Instantiate(foodPrefab, GetRandomPositionOnScreen(), Quaternion.identity);
            curFood.transform.localScale = new Vector3(globalVar.ssnakeSize, globalVar.ssnakeSize, globalVar.ssnakeSize);
            curFood.transform.SetParent(gameField.transform);
        }

    }
    public Vector2 GetRandomPositionOnScreen()
    {
        Vector2 randomPosition = new Vector2(Random.Range(bottomLeft.x+ otstup, topRight.x- otstup), Random.Range(bottomLeft.y+ otstup, topRight.y- otstup));
        return randomPosition;
    }

    IEnumerator WaitForGFGen()
    {
        while(true)
        {
            if (gameField!=null)
            {
                bottomLeft = gameField.transform.GetChild(0).GetComponent<Renderer>().bounds.min;
                topRight = gameField.transform.GetChild(0).GetComponent<Renderer>().bounds.max;
                fieldGenerated = true;
                yield break;
            }
            yield return null;
        }
       
    }
}
