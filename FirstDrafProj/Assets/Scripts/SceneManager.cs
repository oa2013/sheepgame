using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
	public GameManager	upperManagement;
	public Texture2D	counter;

	public bool	firstLevel;
	
	string	sheepTag = "Sheep";
	string	spawnTag = "Spawnpoint";
	
	GUIStyle counterStyle;
	float sw;
	float sh;
	int numberOfSheep;
	
	// Use this for initialization
	void Start ()
	{
		upperManagement = GameObject.Find("GameManager").GetComponent<GameManager>();

		sw = Screen.width;
		sh = Screen.height;
		GameObject[] sheep = GameObject.FindGameObjectsWithTag(sheepTag);
		numberOfSheep = sheep.Length;

		GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnTag);
		for(int i = 0; i < numberOfSheep; i += 1)
		{	sheep[i].transform.position = spawnPoints[Random.Range(0,spawnPoints.Length)].transform.position;	}

		counterStyle = new GUIStyle();
		counterStyle.fontSize = (int)sh/8;
		counterStyle.normal.textColor = Color.black;
		counterStyle.font = (Font)Resources.Load("Fonts/Boingo");
	}
	
	// Update is called once per frame
	void OnGUI ()
	{
		GUI.DrawTexture(new Rect(sw*3/4,10,256,128),counter);
		GUI.Label(new Rect(sw*3/4+160,25,10,10),numberOfSheep.ToString(),counterStyle);
	}
	
	public void SheepSent()
	{
		numberOfSheep -= 1;
		
		if(numberOfSheep == 0)
		{	upperManagement.GoToNextScene();	}
	}	
}
