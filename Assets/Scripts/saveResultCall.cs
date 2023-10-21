using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class saveResultCall : MonoBehaviour
{
    public GameObject gameControl;

    public GameObject textName;


    // Start is called before the first frame update
    public void saveResCall()
    {
        string plName = textName.GetComponent<TMP_InputField>().text;


        gameControl.SendMessage("saveRes", plName);
    }

}
