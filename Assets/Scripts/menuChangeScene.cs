using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuChangeScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadScene(string level)
    {
        StartCoroutine(IloadScene(level));
        
    }
    IEnumerator IloadScene(string level)
    {
        while (true)
        {
            if (GetComponent<menuButtonsActions>().soundPlayed)
            {
                yield return new WaitForSeconds(0.5f);
                SceneManager.LoadScene(level);

                yield break;
            }
            yield return null;
        }
    }
}
