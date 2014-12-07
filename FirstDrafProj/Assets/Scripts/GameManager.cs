﻿using UnityEngine;
using System.Collections;

public enum Scenes{Loading, MainMenu, Level1, Level2, Level3};

public class GameManager : MonoBehaviour
{
	Scenes currScene;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
		currScene = Scenes.MainMenu;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void GoToNextScene()
	{
		switch(currScene)
		{
		case Scenes.Loading:
			currScene = Scenes.MainMenu;
			Application.LoadLevel("MainMenu");
			break;
		case Scenes.MainMenu:
			currScene = Scenes.Level1;
			Application.LoadLevel("Level 1");
			break;
		case Scenes.Level1:
			currScene = Scenes.Level2;
			Application.LoadLevel("Level 2");
			break;
		case Scenes.Level2:
			currScene = Scenes.Level3;
			Application.LoadLevel("Level 3");
			break;
		}
	}
}
