using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{

    public float speed = 5f;

    public float closestDistance = 6f;

    private bool playerFound;

    private Vector3 startPos;
    private Quaternion startRot;

    Player colsestPlayer;

    void Start() {
        setStartPosition();
    }

    void Update() {
        if(playerFound == true) {
            homingMove();
        }
    }

    public void FindClosestPlayer() {
        Player[] playerList = FindObjectsOfType<Player>();

        if(playerList != null) {
            playerFound = true;

            foreach(Player player in playerList) {
                float distanceToPlayer = (player.transform.position - transform.position).sqrMagnitude;

                if(distanceToPlayer < closestDistance) {
                    //closestDistance = distanceToPlayer;
                    colsestPlayer = player;
                } else {
                    playerFound = false;
                    resetPosition();
                }
            }
        }

        if(playerList.Length == 0) {
            playerFound = false;
        }
    }

    void homingMove() {
        Vector3 direction = transform.position - colsestPlayer.transform.position;
        direction = -direction.normalized;
        transform.rotation = Quaternion.LookRotation(transform.forward, direction);
        transform.position += direction * speed * Time.deltaTime;
    }
    
    void setStartPosition() {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void resetPosition() {
        transform.position = startPos;
        transform.rotation = startRot;
    }
}
