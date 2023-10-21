using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class loadDefaults : MonoBehaviour
{
    public GameObject GSize;
    public GameObject GLength;
    public GameObject GSpeed;
    public GameObject GSpeedIncr;


    // Start is called before the first frame update
    public void loadDef()
    {
        //Debug.Log(GSize.GetComponent<TMP_InputField>().text + " " + globalVar.sdsnakeSize);
        GSize.GetComponent<TMP_InputField>().text = ""+globalVar.sdsnakeSize;
        GLength.GetComponent<TMP_InputField>().text = "" + globalVar.sdstartSnakeLen;
        GSpeed.GetComponent<TMP_InputField>().text = "" + 1/globalVar.sdcircleTime;
        GSpeedIncr.GetComponent<TMP_InputField>().text = "" + 1/globalVar.sdcicleTimeDecrement;

    }


}
