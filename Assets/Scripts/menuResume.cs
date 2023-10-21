using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class menuResume : MonoBehaviour
{
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void resumeGame()
    {

        StartCoroutine(WaitAndResume());

    }


    IEnumerator WaitAndResume()
    {
        while (true)
        {
            if (GetComponent<menuButtonsActions>().soundPlayed)
            {
                yield return new WaitForSeconds(0.5f);
                GetComponent<menuButtonsActions>().soundPlayed = false;
                globalVar.menuActive = !globalVar.menuActive;
                Menu.SetActive(!Menu.activeSelf);
                yield break;
            }
            yield return null;
        }
    }
}
