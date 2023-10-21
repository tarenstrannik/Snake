using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class submitParamsInStartMenu : MonoBehaviour
{
    public GameObject GSize;
    public GameObject GLength;
    public GameObject GSpeed;
    public GameObject GSpeedIncr;
    public void saveSession()
    {
        if (globalVar.firstStart)
        {
            var Size = GSize.GetComponent<TMP_InputField>();
            var Length = GLength.GetComponent<TMP_InputField>();
            var Speed = GSpeed.GetComponent<TMP_InputField>();
            var SpeedIncr = GSpeedIncr.GetComponent<TMP_InputField>();

            /*
            parametersStore.sstartSnakeLen = int.Parse(Length.text);
            parametersStore.ssnakeSize = float.Parse(Size.text);
            parametersStore.scircleTime = 1/float.Parse(Speed.text);
            parametersStore.scicleTimeDecrement = 1/float.Parse(SpeedIncr.text);*/
            globalVar.sstartSnakeLen = int.Parse(Length.text);
            globalVar.ssnakeSize = float.Parse(Size.text);
            globalVar.scircleTime = 1 / float.Parse(Speed.text);
            globalVar.scicleTimeDecrement = 1 / float.Parse(SpeedIncr.text);
            PlayerPrefs.SetInt("sstartSnakeLen", globalVar.sstartSnakeLen);
            PlayerPrefs.SetFloat("ssnakeSize", globalVar.ssnakeSize);
            PlayerPrefs.SetFloat("scircleTime", globalVar.scircleTime);
            PlayerPrefs.SetFloat("scicleTimeDecrement", globalVar.scicleTimeDecrement);
            PlayerPrefs.Save();
        }
    }
}
