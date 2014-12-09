using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour 
{

	void Start ()
	{

	}

	void OnMouseOver()
	{
		if (GameObject.Find ("Start")) 
		{
			Application.LoadLevel("MainScene");
		}
	}

}
