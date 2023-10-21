using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuGoToMenuButtonRes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject curMenu;
    public GameObject targetMenu;
    public GameObject targetMenuIfRecord;
   
    public GameObject glMenu;

    public GameObject resOps;

    // Update is called once per frame
    void Update()
    {

    }
    public void goToMenu()
    {
        StartCoroutine(IgoToMenu());
    }

    IEnumerator IgoToMenu()
    {
        while (true)
        {
            if (GetComponent<menuButtonsActions>().soundPlayed)
            {
                yield return new WaitForSeconds(0.5f);
                if (!resOps.GetComponent<resultsOperations>().isRecord())
                {
                    targetMenu.SetActive(true);
                    glMenu.SendMessage("changeCurMenu", targetMenu);
                }
                else
                {
                    targetMenuIfRecord.SetActive(true);
                    glMenu.SendMessage("changeCurMenu", targetMenuIfRecord);
                }

                curMenu.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }
}
