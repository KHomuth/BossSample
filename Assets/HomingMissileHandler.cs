using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileHandler : MonoBehaviour
{
    private bool isCoroutineRunning;
    public GameObject leftArm;

    // Update is called once per frame
    void Update()
    {
        HomingMissile missile = GameObject.Find("Left Arm").GetComponent<HomingMissile>();

        if(missile != null) {
            missile.FindClosestPlayer();
        }
    }
}
