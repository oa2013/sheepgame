using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour
{
	int numberOfEnemies;
	public string enemyTag = "Enemy";
	public string playerTag = "Player";
	public int mainMenuIndex = 0;
	public int nextLevelIndex = 2;
	public int loseMenu = 3;

	// Use this for initialization
	void Start()
	{
		numberOfEnemies = GameObject.FindGameObjectsWithTag(enemyTag).Length;
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void GODied(string goTag)
	{
		if(goTag == enemyTag)
		{
			numberOfEnemies -= 1;
			if(numberOfEnemies <= 0)
			{
				Application.LoadLevel(nextLevelIndex);
			}
		}
		if(goTag == playerTag)
		{
			Application.LoadLevel(loseMenu);
		}
	}
}
