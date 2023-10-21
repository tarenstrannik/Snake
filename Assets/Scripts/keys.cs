using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class keys : MonoBehaviour
{
    public GameObject Menu;
    public GameObject SnakeHead;
    public AudioClip menu_beep;
    private menuGlobal glMenu;
    // Start is called before the first frame update
    void Awake()
    {
        glMenu = Menu.GetComponent<menuGlobal>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Здесь можно выполнить нужные действия при нажатии клавиши Escape
            // Например, вызвать метод RestartScene() для перезагрузки сцены
            if (!Menu.activeSelf)
            {
                SoundOnClick();
                globalVar.menuActive = !globalVar.menuActive;
                Menu.SetActive(!Menu.activeSelf);
            }
            else
            {
                glMenu.curMenu.GetComponent<escBehavior>().SendMessage("Escape");
            }

            if (!globalVar.menuActive)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            // Debug.Log(globalVar.menuActive);
        }
        if (SnakeHead != null && !globalVar.menuActive)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Здесь можно выполнить нужные действия при нажатии клавиши Escape
                // Например, вызвать метод RestartScene() для перезагрузки сцены
                SnakeHead.GetComponent<snakeMove>().rotate(Vector2.left);
                // Debug.Log("rotateleft");
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Здесь можно выполнить нужные действия при нажатии клавиши Escape
                // Например, вызвать метод RestartScene() для перезагрузки сцены
                SnakeHead.GetComponent<snakeMove>().rotate(Vector2.right);
                //Debug.Log("rotateright");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Здесь можно выполнить нужные действия при нажатии клавиши Escape
                // Например, вызвать метод RestartScene() для перезагрузки сцены
                SnakeHead.GetComponent<snakeMove>().rotate(Vector2.up);
                // Debug.Log("rotateleft");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Здесь можно выполнить нужные действия при нажатии клавиши Escape
                // Например, вызвать метод RestartScene() для перезагрузки сцены
                SnakeHead.GetComponent<snakeMove>().rotate(Vector2.down);
                //Debug.Log("rotateright");
            }
        }
    }
    public void SoundOnClick()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && menu_beep != null)
        {
            audioSource.PlayOneShot(menu_beep);
            
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

