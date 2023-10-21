using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class menuGoToMenuButtonBack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject curMenu;
    public GameObject targetMenu;
    public GameObject targetMenuIfNoChange;
    public GameObject targetMenuIfNoChangeMain;
    public GameObject resetBtn;
    public GameObject glMenu;


    private Button resBtn;
    void Awake()
    {
        resBtn = resetBtn.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToMenu()
    {
        StartCoroutine(IgoToMenu());
    }
   /* void setPrevMenu(GameObject prMenu)
    {
        targetMenuIfNoChange = prMenu;
    }*/
    IEnumerator IgoToMenu()
    {
        while (true)
        {
            if (GetComponent<menuButtonsActions>().soundPlayed)
            {
                yield return new WaitForSeconds(0.5f);
                if (resBtn.IsInteractable())
                {
                    targetMenu.SetActive(true);
                    glMenu.SendMessage("changeCurMenu", targetMenu);
                }
                else
                {
                    if (globalVar.firstStart && targetMenuIfNoChangeMain != null)
                    {

                        glMenu.SendMessage("changeCurMenu", targetMenuIfNoChangeMain);
                        targetMenuIfNoChangeMain.SetActive(true);
                    }
                    else
                    {
                        glMenu.SendMessage("changeCurMenu", targetMenuIfNoChange);
                        targetMenuIfNoChange.SetActive(true);
                    }
                   
                }

                    curMenu.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }
}
