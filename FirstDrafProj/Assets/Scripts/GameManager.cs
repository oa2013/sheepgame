using UnityEngine;
using System.Collections;

public enum Scenes{Loading, MainMenu, Level1, Level2, Level3};

public class GameManager : MonoBehaviour
{
	public int score;
	Scenes currScene;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
		score = 0;
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
			Application.LoadLevel(0);
			break;
		case Scenes.MainMenu:
			currScene = Scenes.Level1;
			Application.LoadLevel(1);
			break;
		case Scenes.Level1:
			currScene = Scenes.Level2;
			Application.LoadLevel(2);
			break;
		case Scenes.Level2:
			currScene = Scenes.Level3;
			Application.LoadLevel(3);
			break;
		case Scenes.Level3:
			currScene = Scenes.MainMenu;
			Application.LoadLevel(0);
			break;
		}
	}
}
