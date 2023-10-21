using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class saveResultLayout : MonoBehaviour
{
    public Button okBtn;
        public GameObject textName;
    private TMP_InputField textText;

    // Start is called before the first frame update
    void Start()
    {
        textText= textName.GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(textText.text.Trim() != "") okBtn.interactable = true;
        else okBtn.interactable = false;


    }
}
