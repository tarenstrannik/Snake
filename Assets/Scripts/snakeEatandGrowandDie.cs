using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class snakeEatandGrowandDie : MonoBehaviour
{
    public AudioClip EatSound;
    public int SnakeScore = 0;
    private AudioSource audioSource;
    private Component snakeMove;
    private GameObject snakeTail;
    public GameObject snakeTailPrefab;
    private Vector2 snakeElementSize;
    private snakeBody snakeBody;
    private bool isDead=false;
    public GameObject glVar;
    ///private bool isnoBack = false;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        snakeMove = GetComponent<snakeMove>();
        snakeTail = gameObject;
        snakeElementSize = new Vector2(globalVar.ssnakeSize, globalVar.ssnakeSize);
        snakeBody = GetComponent<snakeBody>();
        //Debug.Log("initf");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnCollisionEnter2D(Collision2D hit)
    private void OnTriggerEnter2D(Collider2D hit)
    {
        //Debug.Log(hit.gameObject.name + " " + hit.gameObject.GetInstanceID());
        if(hit.gameObject.tag=="Food")
        {
            if (EatSound != null)
            {
                
                audioSource.PlayOneShot(EatSound);
            }
            Destroy(hit.gameObject);
            SnakeScore++;
            Grow();

            snakeMove.SendMessage("speedIncrease");
            
        }
        else if(hit.gameObject!=snakeBody.childBody)
        {
            if (!isDead)
            {
                isDead = true;

                globalVar.isGameStarted = false;
    snakeMove.SendMessage("Die");
                glVar.SendMessage("snakeDead");
            }
        }
        
    }
    private void Grow()
    {
        Vector3 tailPos;

        tailPos = snakeTail.GetComponent<snakeBody>().prevPosition;
        //Debug.Log("grow position" + tailPos);
        Vector2 tailRotationVector = tailPos - snakeTail.transform.position;
        Vector3 tailRotationVector3D = new Vector3(tailRotationVector.x, tailRotationVector.y, 0f);

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, tailRotationVector3D);

        GameObject stTemp = Instantiate(snakeTailPrefab, tailPos, rotation);
        stTemp.transform.localScale = new Vector3(snakeElementSize.x, snakeElementSize.y);
        //Debug.Log(stTemp.transform.position);
        //stTemp.transform.SetParent(snakeTail.transform);
        //Debug.Log(stTemp.transform.position);
        //snakeTail = stTemp;
        //Debug.Log(snakeTail.transform.position);
        stTemp.GetComponent<snakeBody>().parentBody = snakeTail;
        snakeTail = stTemp;
        Vector2 sdvig = tailRotationVector.normalized * snakeElementSize;
        snakeTail.GetComponent<snakeBody>().prevPosition = snakeTail.transform.position+  new Vector3(sdvig.x, sdvig.y, 0); 
        if (snakeBody.childBody == null)
        {
            snakeBody.childBody = snakeTail;
            snakeMove.SendMessage("noBack");
        }
    }
}
