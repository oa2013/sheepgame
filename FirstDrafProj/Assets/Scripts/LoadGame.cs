using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour 
{

	void Start ()
	{

	}

	void OnMouseDown() //click
	{
		if (GameObject.Find ("Start")) 
		{
			GameObject.Find("GameManager").GetComponent<GameManager>().GoToNextScene();
		}
	}

}
