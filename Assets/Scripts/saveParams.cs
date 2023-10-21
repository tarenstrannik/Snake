using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class saveParams : MonoBehaviour
{
    public GameObject GSize;
    public GameObject GLength;
    public GameObject GSpeed;
    public GameObject GSpeedIncr;
   public void saveSession()
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

        PlayerPrefs.SetInt("sstartSnakeLen", int.Parse(Length.text));
        PlayerPrefs.SetFloat("ssnakeSize", float.Parse(Size.text));
        PlayerPrefs.SetFloat("scircleTime", 1 / float.Parse(Speed.text));
        PlayerPrefs.SetFloat("scicleTimeDecrement", 1 / float.Parse(SpeedIncr.text));
        PlayerPrefs.Save();
    }
}
