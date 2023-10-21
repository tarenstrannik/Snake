using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGameIf : MonoBehaviour
{
    // Start is called before the first frame update
    public float exitPause = 1.0f;
    // Start is called before the first frame update

    public void ExitGame()
    {
        if (globalVar.progressSaved)
            StartCoroutine(WaitAndQuit(exitPause));
        else SendMessage("goToMenu");
    }

    IEnumerator WaitAndQuit(float time)
    {
        yield return new WaitForSeconds(time);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
