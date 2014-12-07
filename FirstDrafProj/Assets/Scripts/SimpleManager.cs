using UnityEngine;
using System.Collections;

public class SimpleManager : MonoBehaviour
{
	public GameManager upperManagement;

	public string	sheepTag = "Sheep";

	int numberOfSheep;

	// Use this for initialization
	void Start ()
	{	numberOfSheep = GameObject.FindGameObjectsWithTag(sheepTag).Length;	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void SheepSent()
	{
		numberOfSheep -= 1;

		if(numberOfSheep == 0)
		{	upperManagement.GoToNextScene();	}
	}

	void SheepSetup()
	{

	}
}
