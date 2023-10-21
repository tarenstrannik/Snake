using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class primMenu : MonoBehaviour
{
    public GameObject gameMenu;

    public GameObject paramsMenu;
    public GameObject backMenuGroup;
    public GameObject submitMenuGroup;
    public GameObject resetMenuGroup;

    public GameObject startMenu;
    public GameObject quitMenu;
    public GameObject resultMenu;
    public GameObject congatsMenu;
    public GameObject saveResultMenu;
    public GameObject leatherboard;
    // Start is called before the first frame update
    private void Awake()
    {
        gameMenu.SetActive(true);
        paramsMenu.SetActive(false);
        backMenuGroup.SetActive(false);
        submitMenuGroup.SetActive(false);
        resetMenuGroup.SetActive(false);

        startMenu.SetActive(false);
        quitMenu.SetActive(false);
        resultMenu.SetActive(false);
        congatsMenu.SetActive(false);
        saveResultMenu.SetActive(false);
        leatherboard.SetActive(false);
    }
    private void OnEnable()
    {
        gameMenu.SetActive(true);
        paramsMenu.SetActive(false);
        backMenuGroup.SetActive(false);
        submitMenuGroup.SetActive(false);
        resetMenuGroup.SetActive(false);

        startMenu.SetActive(false);
        quitMenu.SetActive(false);
        resultMenu.SetActive(false);
        congatsMenu.SetActive(false);
        saveResultMenu.SetActive(false);
        leatherboard.SetActive(false);
    }


}
