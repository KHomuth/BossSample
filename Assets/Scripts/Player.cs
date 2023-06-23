using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D rigidBody;

	bool movingLeft;
	bool movingRight;
	bool movingUp;
	bool movingDown;

	private float playerSpeed = 0.1f;

	private void Start (){
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	public void ButtonInput (string input){

		switch (input) {
		case "right":
			movingRight = true;
			break;
		case "left":
			movingLeft = true;
			break;
		case "up":
			movingUp = true;
			break;
		case "down":
			movingDown = true;
			break;
		case "right-up":
			movingRight = false;
			break;
		case "left-up":
			movingLeft = false;
			break;
		case "up-up":
			movingUp = false;
			break;
		case "down-up":
			movingDown = false;
			break;
		}
	}

	private void FixedUpdate(){
		if (movingLeft && !movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (-playerSpeed, 0)); 
		} else if (!movingLeft && movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (playerSpeed, 0)); 
		} else if (!movingDown && movingUp) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (0, playerSpeed)); 
		} else if (movingDown && !movingUp) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (0, -playerSpeed)); 
		}
	}
}
