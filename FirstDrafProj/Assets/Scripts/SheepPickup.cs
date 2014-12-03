using UnityEngine;
using System.Collections;

public class SheepPickup : MonoBehaviour
{
	public GameObject	balloonSheep;
	public Transform	sheepNode;

	GameObject	sheep;
	bool	holdingSheep;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if(holdingSheep)
		{
			if(Input.GetKeyDown(KeyCode.E) && other.tag == "Balloon")
			{
				GameObject.Instantiate(balloonSheep,sheep.transform.position,sheep.transform.rotation);
				Destroy(sheep);
				holdingSheep = false;
			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.E) && other.tag == "Sheep")
			{
				sheep = other.gameObject;
				sheep.transform.parent = sheepNode;
				//sheep.SendMessage("Lift",sheepNode);
				holdingSheep = true;
			}
		}
	}
}