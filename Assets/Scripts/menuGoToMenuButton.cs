using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class menuGoToMenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject curMenu;
    public GameObject targetMenu;
    public GameObject targetMenuMain;
    public GameObject glMenu;

    public void goToMenu()
    {
        StartCoroutine(IgoToMenu());
    }
    /*void setPrevMenu(GameObject prMenu)
    {
        targetMenu = prMenu;
    }*/
    IEnumerator IgoToMenu()
    {
        while (true)
        {
            if (GetComponent<menuButtonsActions>().soundPlayed)
            {
                yield return new WaitForSeconds(0.5f);
                curMenu.SetActive(false);
                if (globalVar.firstStart&& targetMenuMain!=null)
                {

                    glMenu.SendMessage("changeCurMenu", targetMenuMain);
                    targetMenuMain.SetActive(true);
                }
                else
                {
                    glMenu.SendMessage("changeCurMenu", targetMenu);
                    targetMenu.SetActive(true);
                }
                //targetMenu.SendMessage("setPrevMenu", curMenu,SendMessageOptions.RequireReceiver);

                yield break;
            }
            yield return null;
        }
    }
}
