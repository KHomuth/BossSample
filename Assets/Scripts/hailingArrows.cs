using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hailingArrows : MonoBehaviour
{
    private GameObject arrowclone;
    public GameObject arrow;
    public GameObject player;
    private Vector2 startPos;
    private Vector2 targetPos;
    protected float Animation;
    //private bool isArrowSpawned = false;
    private int arrowCount = 1;
    private int maxArrowExisting = 0;

    //private float cooldown;


    // Start is called before the first frame updateMoldedKale
    void Start()
    {
        //arrowclone = new GameObject();
        startPos = GameObject.FindGameObjectWithTag("RightArm").transform.position;
        targetPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {         
        Animation += Time.deltaTime;
        Animation = Animation % 2f;

        if(maxArrowExisting < arrowCount)
        {
            //spawnArrow();
        }

        //if (isArrowSpawned)
        {
            shootArrow();
            //Destroy(arrowclone, 2f);
            //isArrowSpawned = false;
        }
    }
    
    void spawnArrow()
    {
        for (int i = 1; i <= 1; i++)
        {
            arrowclone = Instantiate(arrow);
            arrowclone.transform.position = startPos;
            //isArrowSpawned = true;
            maxArrowExisting += 1;
        }
    }

    void shootArrow()
    {
        //Debug.Log("arrow geschossen");
        arrow.transform.position = MathParabola.Parabola(startPos, targetPos, 0, Animation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Animation = 0f;
        //arrow.transform.position = GameObject.FindGameObjectWithTag("RightArm").transform.position;
        //startPos = GameObject.FindGameObjectWithTag("RightArm").transform.position;
        //targetPos = player.transform.position;
    }
}
