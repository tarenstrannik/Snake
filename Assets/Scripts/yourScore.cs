using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class yourScore : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI resScore;
    private void Awake()
    {
        resScore.text = score.text;
    }
}
