using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeBodyMove : MonoBehaviour
{
    private snakeBody parentBody;

    private bool haveChild = false;
    private GameObject child;
    private snakeBody thisBody;

    public Sprite bodySprite;
    public Color bodyColor;
    public Sprite startSprite;
    // Start is called before the first frame update
    void Start()
    {
        startSprite = GetComponent<SpriteRenderer>().sprite;

         thisBody = GetComponent<snakeBody>();
        parentBody = thisBody.parentBody.GetComponent<snakeBody>();

        //parentBody = transform.parent.gameObject.GetComponent<snakeBody>();

        parentBody.childBody = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!haveChild)
        {
            if (thisBody.childBody != null)
            {
                haveChild = true;
                child = thisBody.childBody;
                GetComponent<SpriteRenderer>().sprite = bodySprite;
                if(parentBody.GetComponent<SpriteRenderer>().color!= bodyColor)
                {
                    
                    GetComponent<SpriteRenderer>().color = bodyColor;
                }
                else
                { 
                    child.SendMessage("changeColor", bodyColor); 
                }
               // GetComponent<SpriteRenderer>().color = collideColor;
            }
        }
    }

    void moveBody()
    {
        thisBody.prevPosition = transform.position;
        //Debug.Log(gameObject.GetInstanceID()+" " + transform.position + " "+ parentBody.prevPosition);
        transform.position = parentBody.prevPosition;

        //Debug.Log(gameObject.GetInstanceID() + " " + transform.position + " " + parentBody.prevPosition);
        if (haveChild)
        {
            child.SendMessage("moveBody");
        }
        else
        {
           
            Vector2 tailRotationVector = transform.position - parentBody.transform.position;
            Vector3 tailRotationVector3D = new Vector3(tailRotationVector.x, tailRotationVector.y, 0f);

            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, tailRotationVector3D);
            transform.rotation = rotation;
        }
    }
    void changeColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
    void changeParent(snakeBody SB)
    {
        parentBody = SB;
    }
}
