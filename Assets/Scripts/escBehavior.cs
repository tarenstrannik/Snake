using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escBehavior : MonoBehaviour
{
    public GameObject child;
    public string command;
    /*void setPrevMenu(GameObject prMenu)
    {
        child.SendMessage("setPrevMenu", prMenu, SendMessageOptions.DontRequireReceiver);
    }*/
    void Escape()
    {
        child.SendMessage("SoundOnClick");
        child.SendMessage(command);
    }
}
