using UnityEngine;
using System.Collections;

public class girlController : MonoBehaviour 
{
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.E)) 
		{
			anim.SetBool("pickup", true);
		} else 
		{
			anim.SetBool("pickup", false);
		}

		if (Input.GetKeyDown(KeyCode.W)) 
		{
			anim.SetBool("jump", true);
		} else 
		{
			anim.SetBool("jump", false);
		}

	}
}


