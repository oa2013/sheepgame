using UnityEngine;
using System.Collections;

public class girlController : MonoBehaviour 
{
	private Animator anim;
	bool walkCycle = false;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) 
		{
			if(!walkCycle)
			{
				walkCycle = true;
				anim.SetBool("walk",true);
			}

		}
		else
		{
			anim.SetBool("walk", false);
			walkCycle = false;
		}

		if (Input.GetKeyDown(KeyCode.E)) 
		{
			anim.SetBool("pickup", true);
		} else 
		{
			anim.SetBool("pickup", false);
		}

		if (Input.GetKeyDown(KeyCode.Q)) 
		{
			anim.SetBool("jump", true);
		} else 
		{
			anim.SetBool("jump", false);
		}


	}
}


