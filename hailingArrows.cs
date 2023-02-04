using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hailingArrows : MonoBehaviour
{
    GameObject gObject = new GameObject();
    public GameObject arrow;
    public GameObject player;
    private Vector3 startPos;
    private Vector3 targetPos;
    protected float Animation;
    private bool isArrowSpawned = false;
    public float TimeToLive = 1f;
    public int arrowCount = 12;
    public int maxArrowExisting = 0;

    //private float cooldown;


    // Start is called before the first frame updateMoldedKale
    void Start()
    {
        startPos = GameObject.FindGameObjectWithTag("RightArm").transform.position;
        targetPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isArrowSpawned);
        //if (!isArrowSpawned)        
        
        Animation += Time.deltaTime;
        Animation = Animation % 10f;

        if(maxArrowExisting <= arrowCount)
        {
            spawnArrow();
        }

        if (isArrowSpawned)
        {
            shootArrow();
            Destroy(gObject, 2f);
            isArrowSpawned = false;
        }
    }
    
    void spawnArrow()
    {
        for (int i = 1; i <= arrowCount; i++)
        {
            gObject = Instantiate(arrow);
            gObject.transform.position = startPos;
            isArrowSpawned = true;
            maxArrowExisting += 1;
        }
    }

    void shootArrow()
    {
        gObject.transform.position = MathParabola.Parabola(startPos, targetPos * 10f, 5f, Animation / 5f);
    }
}
