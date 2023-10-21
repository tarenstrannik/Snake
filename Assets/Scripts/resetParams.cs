using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class resetParams : MonoBehaviour
{
    public GameObject GSize;
    public GameObject GLength;
    public GameObject GSpeed;
    public GameObject GSpeedIncr;

    private TMP_InputField Size;
    private TMP_InputField Length;
    private TMP_InputField Speed;
    private TMP_InputField SpeedIncr;

    private void Awake()
    {
        Size = GSize.GetComponent<TMP_InputField>();
        Length = GLength.GetComponent<TMP_InputField>();
        Speed = GSpeed.GetComponent<TMP_InputField>();
        SpeedIncr = GSpeedIncr.GetComponent<TMP_InputField>();

    }

    public void Reset()
    {
        Size = GSize.GetComponent<TMP_InputField>();
        Length = GLength.GetComponent<TMP_InputField>();
        Speed = GSpeed.GetComponent<TMP_InputField>();
        SpeedIncr = GSpeedIncr.GetComponent<TMP_InputField>();
        Size.text = "" + globalVar.ssnakeSize;
        Length.text = "" + globalVar.sstartSnakeLen;
        Speed.text = "" + (1 / globalVar.scircleTime);
        SpeedIncr.text = "" + (1 / globalVar.scicleTimeDecrement);
    }
}
