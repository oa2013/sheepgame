using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//9/8/2014
//From JJ's Unity Tutorials

public class PlayerMovement : MonoBehaviour {

	//Instance Variables
	public float moveSpeed = 20;
	public float jumpForce = 500;
	bool isTouchingGround;
	// Use this for initialization
	void Start () {
		isTouchingGround = false;
	}
	
	// Update is called once per frame
	void Update () {
		KeyMovement();
	}
	void KeyMovement()
	{
		Vector3 moveVect = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		moveVect *= (moveSpeed*Time.deltaTime);
		transform.Translate(moveVect);//this is how we move it
		
		if(Input.GetKeyDown(KeyCode.Space) && isTouchingGround == true)
		{
			rigidbody.AddForce(Vector3.up*jumpForce);	
		}
	}
	void OnCollisionEnter(Collision colliInfo)
	{
		if(colliInfo.gameObject.tag == "Ground")
		{
			isTouchingGround = true;
		}
	}
	void OnCollisionExit(Collision colliInfo)
	{
		if(colliInfo.gameObject.tag == "Ground")
		{
			isTouchingGround = false;
		}
	}
}
