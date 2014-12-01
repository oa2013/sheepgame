using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//9/8/2014
//From JJ's Unity Tutorials

public class PlayerMovement : MonoBehaviour
{
	//Instance Variables
	public float	moveSpeed = 10;
	public float	rotateSpeed = 90;
	public float	jumpForce = 20;
	public bool	isTouchingGround;

	CharacterController	controller;
	girlController		girl;
	
	float	verticalSpeed = 0;
	bool	isNearSheep;
	// Use this for initialization
	void Start ()
	{
		controller = GetComponent<CharacterController>();
		girl = GetComponentInChildren<girlController>();
		isTouchingGround = false;
		isNearSheep = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		KeyMovement();
	}
	void KeyMovement()
	{
		Vector3 moveVect = new Vector3(0,0,Input.GetAxis("Vertical"));
		moveVect = transform.TransformDirection(moveVect);
		moveVect *= (moveSpeed*Time.deltaTime);
		if(isTouchingGround)
		{	moveVect -= 9.8f*transform.up*Time.deltaTime;	}
		else
		{
			moveVect += verticalSpeed*transform.up*Time.deltaTime;
			verticalSpeed -= 9.8f*Time.deltaTime;
		}
		controller.Move(moveVect);

		Vector3 rotateVect = new Vector3(0,Input.GetAxis("Horizontal"),0);
		rotateVect *= (rotateSpeed*Time.deltaTime);
		transform.Rotate(rotateVect);

		//transform.Translate(moveVect, Space.Self);//this is how we move it
		
		if(Input.GetKeyDown(KeyCode.Space) && isTouchingGround == true)
		{
			girl.Jump();
			verticalSpeed = 5;
			isTouchingGround = false;
		}
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if(hit.gameObject.tag == "Ground")
		{
			girl.EndJump();
			verticalSpeed = 0;
			isTouchingGround = true;
		}
	}
}
