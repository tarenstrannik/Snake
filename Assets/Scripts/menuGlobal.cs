using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuGlobal : MonoBehaviour
{

    public GameObject gameMenu;

    public GameObject startMenu;

    public  GameObject curMenu;
    public GameObject resultMenu;

    // Start is called before the first frame update
    private void Awake()
    {
        gameMenu.SetActive(true);


        curMenu = gameMenu;
    }

    private void OnEnable()
    {
        gameMenu.SetActive(true);
     
        curMenu = gameMenu;
    }

    // Update is called once per frame
    void changeCurMenu(GameObject newCurMenu)
    {
        curMenu = newCurMenu;
    }
    void firstStart()
    {
        //Debug.Log("firststart");
        gameMenu.SetActive(false);
        startMenu.SetActive(true);
        curMenu = startMenu;
    }
    void result()
    {
        //Debug.Log("firststart");
        gameMenu.SetActive(false);
        resultMenu.SetActive(true);
        curMenu = resultMenu;
    }

}
