using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
	public GameManager upperManagement;
	
	string	sheepTag = "Sheep";
	string	spawnTag = "Spawnpoint";
	
	int numberOfSheep;
	
	// Use this for initialization
	void Start ()
	{
		upperManagement = GetComponent<GameManager>();

		GameObject[] sheep = GameObject.FindGameObjectsWithTag(sheepTag);
		numberOfSheep = sheep.Length;

		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);
		for(int i = 0; i < numberOfSheep; i += 1)
		{	sheep[i].transform.position = spawnPoints[Random.Range(0,spawnPoints.Length)].transform.position;	}
	}
	
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
}
