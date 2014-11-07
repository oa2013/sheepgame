using UnityEngine;
using System.Collections;

public enum SheepState{Grazing,Hiding,Wandering,Running,Carried};

public class SheepMovement : MonoBehaviour
{
	public float	walkSpeed = .45f;
	public float	runSpeed = 2;
	public float	minActionTime = 4;
	public float	maxActionTime = 7;

	//GameObject	player;
	public SheepState	currState;

	Animation	childAnimation;
	Vector3		startAngle;
	Vector3		endAngle;
	float		currMoveSpeed;
	float		stateTime;
	float		randTime;

	// Use this for initialization
	void Start ()
	{
		//player = GameObject.Find("Player");
		currState = SheepState.Grazing;
		childAnimation = GetComponentInChildren<Animation> ();
		startAngle = transform.eulerAngles;
		endAngle = transform.eulerAngles;
		currMoveSpeed = 0;
		stateTime = Time.time;
		randTime = Random.Range(minActionTime,maxActionTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(currState != SheepState.Running && currState != SheepState.Carried && Time.time-stateTime > randTime)
		{
			SwitchStates();
			stateTime = Time.time;
			randTime = Random.Range(minActionTime,maxActionTime);
		}
		else if(currState == SheepState.Carried && transform.position != transform.parent.position)
		{	transform.position = Vector3.Lerp(transform.position,transform.parent.position,Time.deltaTime);	}

		transform.Translate(Vector3.forward*currMoveSpeed*Time.deltaTime);
		float t = (Time.time - stateTime)/4;
		if(t <= 1)
		{	transform.eulerAngles = Vector3.Lerp(startAngle,endAngle,t);	}
		else
		{	transform.eulerAngles = endAngle;	}
	}

	void SwitchStates()
	{
		print("switch");
		int randNum = Random.Range(0,2);
		if(randNum == 0)
		{
			Graze();
			//childAnimation.CrossFade("Armature|HeadNod");
		}
		else
		{
			Wander();
			//childAnimation.CrossFade("Armature|WalkCycle");
		}
	}

	void Graze()
	{
		currState = SheepState.Grazing;
		currMoveSpeed = 0;
		startAngle = transform.eulerAngles;
		endAngle = transform.eulerAngles;
	}

	void Wander()
	{
		currState = SheepState.Wandering;
		currMoveSpeed = walkSpeed;
		startAngle = transform.eulerAngles;
		endAngle = transform.eulerAngles + new Vector3(0,Random.Range(-90,90),0);
	}

	void Lift(Transform liftNode)
	{
		currState = SheepState.Carried;
		currMoveSpeed = 0;
		childAnimation.CrossFade ("SheepLift");
		transform.parent = liftNode;
		GetComponent<Rigidbody> ().useGravity = false;
	}
}
