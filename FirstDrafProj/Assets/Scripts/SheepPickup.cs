using UnityEngine;
using System.Collections;

public class SheepPickup : MonoBehaviour
{
	public Transform	sheepNode;

	bool		holdingSheep;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			foreach(GameObject sheep in GameObject.FindGameObjectsWithTag("Sheep"))
			{
				print ((sheep.transform.position-gameObject.transform.position).magnitude);
				if((sheep.transform.position-gameObject.transform.position).magnitude < 10 && !holdingSheep)
				{
					sheep.SendMessage("Lift",sheepNode);
					holdingSheep = true;
					break;
				}
			}
		}
	}
}
