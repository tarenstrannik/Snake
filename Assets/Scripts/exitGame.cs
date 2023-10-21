using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGame : MonoBehaviour
{
    public float exitPause = 1.0f;
    // Start is called before the first frame update

    public void ExitGame()
    {
        StartCoroutine(WaitAndQuit(exitPause));
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
