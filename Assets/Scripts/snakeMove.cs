using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;


public class snakeMove : MonoBehaviour
{
    
    private float cicleTimeDecrement = 1.1f;
    public Vector2 forward;
   // private Rigidbody2D rbSnake;

    private bool isnoBack = false;
    private snakeBody SnakeBody;
    private Vector2 snakeElementSize;
    private float circleTime;
    private float curMaxCircleTime;
    private bool haveChild = false;
    private GameObject child;

    private bool isDead = false;

    public Sprite collideSprite;
    public Color collideColor;

    private snakeEatandGrowandDie SnScore;
    private int curstartSnakeLen=1;
    // Start is called before the first frame update
    void Awake()
    {
        SnScore = GetComponent<snakeEatandGrowandDie>();
        cicleTimeDecrement = globalVar.scicleTimeDecrement;
        snakeElementSize = new Vector2(globalVar.ssnakeSize, globalVar.ssnakeSize);
        SnakeBody = GetComponent<snakeBody>();
        //rbSnake = GetComponent<Rigidbody2D>();
        circleTime = globalVar.scircleTime;
        curMaxCircleTime = circleTime;
        Vector2[] directions = { Vector2.right, Vector2.left, Vector2.up, Vector2.down };

        forward = directions[Random.Range(0, directions.Length)];
        if (forward == Vector2.up)
        {
            
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (forward == Vector2.down)
        {
           
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }
        else if (forward == Vector2.left)
        {
            
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (forward == Vector2.right)
        {
            
            transform.rotation = Quaternion.Euler(0f, 0f, 270f);
        }
        //Debug.Log(forward);
        Vector2 sdvig = forward * snakeElementSize;
        
        SnakeBody.prevPosition=transform.position-  new Vector3(sdvig.x, sdvig.y, 0);
        //Debug.Log(transform.position + " " + forward + " " + sdvig+" "+ SnakeBody.prevPosition);
        StartCoroutine(snakeStepMove());
    }

    // Update is called once per frame
    void Update()
    {
        //rbSnake.transform.rotation = Quaternion.identity;
        if(!globalVar.menuActive)
        {

            if (!haveChild)
            {
                if (GetComponent<snakeBody>().childBody != null)
                {
                    haveChild = true;
                    child = GetComponent<snakeBody>().childBody;
                }
            }
            //Debug.Log(Mathf.Abs(forward.x));
            
            
            
            //rbSnake.velocity = direction;
            //Debug.Log(rbSnake.GetInstanceID() +" "+ rbSnake.velocity);
        }
        else
        {
            //rbSnake.velocity = new Vector2(0, 0);
        }
    }
    public void rotate(Vector2 direction)
    {
        if (!isnoBack)
        {
            forward = direction;
            if (direction == Vector2.up)
            {
               // forward = Vector2.up;
                transform.rotation =  Quaternion.Euler(0f, 0f, 0f);
            }
            else if (direction == Vector2.down)
            {
               // forward = Vector2.down;
                transform.rotation = Quaternion.Euler(0f, 0f,180f);
            }
            else if (direction == Vector2.left)
            {
               // forward = Vector2.left;
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
            else if (direction == Vector2.right)
            {
               // forward = Vector2.right;
                transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            }
        }
        else
        {
            Vector3 direction3D = SnakeBody.prevPosition - transform.position;
            Vector2 direction2D = new Vector2(direction3D.x, direction3D.y).normalized;
            if (direction != direction2D)
            {
                forward = direction;
                if (direction == Vector2.up)
                {
                    // forward = Vector2.up;
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (direction == Vector2.down)
                {
                    // forward = Vector2.down;
                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }
                else if (direction == Vector2.left)
                {
                    // forward = Vector2.left;
                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                }
                else if (direction == Vector2.right)
                {
                    // forward = Vector2.right;
                    transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                }
                /*if (direction == "up" && forward != Vector2.down)
                {
                    forward = Vector2.up;
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                if (direction == "down" && forward != Vector2.up)
                {
                    forward = Vector2.down;
                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }
                if (direction == "left" && forward != Vector2.right)
                {
                    forward = Vector2.left;
                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                }
                if (direction == "right" && forward != Vector2.left)
                {
                    forward = Vector2.right;
                    transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                }*/
            }
        }
        circleTime = 0f;




    }
    void speedIncrease()
    {

       
        //Debug.Log("O"+cicleTime);
        //cicleTime = cicleTime/speedIncrement;
        circleTime *= cicleTimeDecrement;
        curMaxCircleTime = circleTime;
        //Debug.Log("N"+cicleTime);
        //globalVar.speed *= speedIncrement;
    }
    void noBack()
    {
        //Debug.Log("NoBACK");
        isnoBack = true;
    }
    IEnumerator snakeStepMove()
    {
     
        while (true)
        {
            if (!globalVar.menuActive )
            {
                if (isDead) yield break;

                circleTime -= Time.deltaTime;
                if (circleTime <= 0)
                {
                    //Debug.Log(transform.position);
                   /* if (Mathf.Abs(forward.x) > 0)
                    {
                        rbSnake.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
                    }
                    else
                    {
                        rbSnake.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                    }*/
                    circleTime = curMaxCircleTime;
                    Vector2 sdvig = forward * snakeElementSize;
                    SnakeBody.prevPosition = transform.position;
                    //Debug.Log("Head " + SnakeBody.prevPosition);
                    transform.position += new Vector3(sdvig.x, sdvig.y, 0);
                    //Debug.Log("Head " + SnakeBody.prevPosition+" "+ transform.position);
                    if (haveChild)
                    {
                        //Debug.Log(child.name);
                        child.SendMessage("moveBody");
                    }
                    if(curstartSnakeLen<globalVar.sstartSnakeLen)
                    {
                        SnScore.SendMessage("Grow");
                        curstartSnakeLen++;
                    }

                }
            }
            yield return null;
        }

    }

    void Die()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
        GetComponent<SpriteRenderer>().sprite = collideSprite;
        GetComponent<SpriteRenderer>().color = collideColor;
        isDead = true;
        StartCoroutine(Death());

    }

    IEnumerator Death()
    {
        GameObject deadChild = null;
        while (true)
        {
            if (!globalVar.menuActive)
            {
                

                circleTime -= Time.deltaTime;
                if (circleTime <= 0)
                {
                    circleTime = curMaxCircleTime;
                    if (child == null)
                    {
                        Destroy(gameObject);
                    }
                   
                   else

                    {
                        deadChild = child;

                        child = child.GetComponent<snakeBody>().childBody;
                        

                    Destroy(deadChild);

                        //Debug.Log("Head " + SnakeBody.prevPosition+" "+ transform.position);

                        //Debug.Log(child.name);
                        if (child != null)
                        {
                            child.GetComponent<snakeBodyMove>().SendMessage("changeParent", gameObject.GetComponent<snakeBody>(),SendMessageOptions.DontRequireReceiver);
                            child.SendMessage("moveBody");
                        }
                    }

                }
            }
            yield return null;
        }
    }


}
