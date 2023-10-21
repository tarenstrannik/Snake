using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParamsMenu : MonoBehaviour
{
    public GameObject GSize;
    public GameObject GLength;
    public GameObject GSpeed;
    public GameObject GSpeedIncr;

    public GameObject SubmitBtn;
    public GameObject ResetBtn;

    private Button sbmBtn;
    private Button resBtn;

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

       

        Size.text = "" + globalVar.ssnakeSize;
        Length.text = "" + globalVar.sstartSnakeLen;
        Speed.text = "" + (1 / globalVar.scircleTime);
        SpeedIncr.text = "" + (1 / globalVar.scicleTimeDecrement);
        sbmBtn = SubmitBtn.GetComponent<Button>();
            resBtn = ResetBtn.GetComponent<Button>();
    }
    // Start is called before the first frame update
    private void Update()
    {
        if((Size.text != "" + globalVar.ssnakeSize) ||(Length.text != "" + globalVar.sstartSnakeLen) || (Speed.text != "" + (1 / globalVar.scircleTime))||(SpeedIncr.text != "" + (1 / globalVar.scicleTimeDecrement)))
        {
            sbmBtn.interactable = true;
            resBtn.interactable = true;
        }
        else
        {
            sbmBtn.interactable = false;
            resBtn.interactable = false;
        }
        
    }
}
