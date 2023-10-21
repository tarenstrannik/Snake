using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NUnit.Framework.Constraints;

[RequireComponent(typeof(AudioSource))]
public class menuButtonsActions : MonoBehaviour
{

  
    public AudioClip menu_beep;
    public bool soundPlayed = false;
    void Awake()
    {

    }
    // Start is called before the first frame update
 

    public void SoundOnClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && menu_beep != null)
        {
            audioSource.PlayOneShot(menu_beep);
            soundPlayed = true;
        }
        else
        {
            if (audioSource == null)
            {
                Debug.Log("MissingAudio1");
            }
            else
            {
                Debug.Log("MissingAudio");
            }
        };


    }
}
