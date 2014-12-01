using UnityEngine;
using System.Collections;

public class girlController : MonoBehaviour 
{
	private Animator anim;

	PlayerMovement	move;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		move = GetComponentInParent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && move.isTouchingGround)
		{	anim.SetBool("walk",true);	}
		else
		{	anim.SetBool("walk", false);	}
		if(Input.GetKeyDown(KeyCode.E)) 
		{	anim.SetBool("pickup", true);	}
		if(Input.GetKeyUp(KeyCode.E))
		{	anim.SetBool("pickup", false);	}
	}

	public void Jump()
	{	anim.SetBool("jump", true);	}

	public void EndJump()
	{	anim.SetBool ("jump", false);	}
}


