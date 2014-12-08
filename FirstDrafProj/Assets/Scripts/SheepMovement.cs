﻿using UnityEngine;
using System.Collections;

public enum SheepState{Grazing,Hiding,Wandering,Running,Carried};

public class SheepMovement : MonoBehaviour
{
	public float	walkSpeed = .45f;
	public float	runSpeed = 2;
	public float	minActionTime = 4;
	public float	maxActionTime = 7;
	public int		sheepCounter=0;

	//GameObject	player;
	public SheepState	currState;
	Vector3		startAngle;
	Vector3		endAngle;
	float		currMoveSpeed;
	float		stateTime;
	float		randTime;

	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		//player = GameObject.Find("Player");
		sheepCounter+=1;
		currState = SheepState.Grazing;
		startAngle = transform.eulerAngles;
		endAngle = transform.eulerAngles;
		currMoveSpeed = 0;
		stateTime = Time.time;
		randTime = Random.Range(minActionTime,maxActionTime);
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(currState != SheepState.Running && Time.time-stateTime > randTime)
		{
			SwitchStates();
			stateTime = Time.time;
			randTime = Random.Range(minActionTime,maxActionTime);
		}
		rigidbody.MovePosition (transform.position + transform.forward * currMoveSpeed * Time.deltaTime);
		float t = (Time.time - stateTime)/2;
		if(t <= 1)
		{	transform.eulerAngles = Vector3.Lerp(startAngle,endAngle,t);	}
		else
		{	transform.eulerAngles = endAngle;	}
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Fence")
		{
			if(transform.rotation.y < 180)
			{	endAngle = new Vector3(0,transform.eulerAngles.y + 180,0);	}
			else
			{	endAngle = new Vector3(0,transform.eulerAngles.y - 180,0);	}
		}
	}

	void SwitchStates()
	{
		int randNum = Random.Range(0,2);
		if(randNum == 0)
		{	Graze();	}
		else
		{	Wander();	}
	}

	void Graze()
	{
		currState = SheepState.Grazing;
		currMoveSpeed = 0;
		startAngle = transform.eulerAngles;
		endAngle = transform.eulerAngles;

		anim.SetBool("sheepwalk",false);
		anim.SetBool("headnod", true);
	
	}

	void Wander()
	{
		currState = SheepState.Wandering;
		currMoveSpeed = walkSpeed;
		startAngle = transform.eulerAngles;
		endAngle = transform.eulerAngles + new Vector3(0,Random.Range(-90,90),0);

		anim.SetBool("sheepwalk",true);	
		anim.SetBool("headnod", false);
	}

	void Lift()
	{

	}
}
