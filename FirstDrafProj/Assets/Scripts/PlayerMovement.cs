using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//9/8/2014
//From JJ's Unity Tutorials

public class PlayerMovement : MonoBehaviour
{
	public Animation	childAnimate;
	public float		runSpeed = 10;
	public float		walkSpeed = 5;
	public float		jumpForce = 500;

	Transform	sheepNode;
	bool		holdingSheep;
	bool		isTouchingGround;

	void Start ()
	{
		childAnimate = GetComponent<Animation> ();
		holdingSheep = false;
		isTouchingGround = false;
	}
	
	void Update ()
	{	KeyMovement();	}

	void KeyMovement()
	{
		Vector3 moveVect = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		moveVect *= (walkSpeed*Time.deltaTime);
		transform.Translate(moveVect);//this is how we move it

		if (isTouchingGround)
		{
			print ("catch");

			if(Input.GetKeyDown(KeyCode.Space))
			{
				rigidbody.AddForce(Vector3.up*jumpForce);
				childAnimate.CrossFade("jump");
				isTouchingGround = false;
			}
			if(Input.GetKeyDown(KeyCode.LeftShift))
			{
				childAnimate.CrossFade("run");
			}
			if(Input.GetKeyDown(KeyCode.E))
			{

				foreach(GameObject sheep in GameObject.FindGameObjectsWithTag("Sheep"))
				{
					if((sheep.transform.position-gameObject.transform.position).magnitude < 10 && !holdingSheep)
					{
						sheep.SendMessage("Lift",sheepNode);
						holdingSheep = true;
						break;
					}
				}
			}
			else
			{
				childAnimate.CrossFade("walk");
			}
		}
	}
	void OnCollisionEnter(Collision colliInfo)
	{
		if(colliInfo.gameObject.tag == "Ground")
		{
			isTouchingGround = true;
			if(Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Verticle") > 0)
			{	childAnimate.CrossFade("run");	}
			else
			{	childAnimate.CrossFade("idle");	}
		}
	}
}
