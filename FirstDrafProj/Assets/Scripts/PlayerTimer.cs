using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//11/21/2014
//Rukia Brooks

public class PlayerTimer : MonoBehaviour
{
	string text;

	float sw;
	float sh;

	public float timer = 600; //default: 600

	GUIStyle timerStyle;
	GUIStyle directionsStyle;

	bool showDirections;
	bool jump;

	Texture arrowKeys;
	Texture spaceKey;
	
	void Start()
	{
		sw = Screen.width;
		sh = Screen.height;
		showDirections = true;
		jump = true;

		timerStyle = new GUIStyle();
		timerStyle.fontSize = (int)sh/8;
		timerStyle.normal.textColor = Color.white;
		timerStyle.font = (Font)Resources.Load("Fonts/sheeptype_0");

		directionsStyle = new GUIStyle();
		directionsStyle.fontSize = (int)sh/16;
		directionsStyle.normal.textColor = Color.white;
		directionsStyle.font = (Font)Resources.Load("Fonts/Boingo");

		arrowKeys = (Texture)Resources.Load ("arrowKeys");
		spaceKey = (Texture)Resources.Load ("spaceKey");
	}

	void OnGUI () 
	{
		GUI.Label(new Rect(sw*3/8,10,100,20), text, timerStyle);

		if(showDirections)
		{  GUI.DrawTexture(new Rect (sw*1/2 - 275, sh*1/16, 550, 300), arrowKeys);	}
		
		if(jump) 
		{   GUI.DrawTexture (new Rect (sw*1/2 - 150, sh*3/7, 300, 100), spaceKey);	}
	}
	
	bool isMoving()
	{
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
		{	return false;	}
		else
		{	return true;	}
	}

	bool isJumping()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{	return false;	}
		else
		{	return true;	}
	}

	void Update()
	{
		if(timer > 0)
		{
			timer -= Time.deltaTime;
		}

		float t = Mathf.Abs(timer); // get the absolute timer value
		int seconds = (int) t % 60; // calculate the seconds
		int minutes = (int) t / 60; // calculate the minutes
		string minSec = minutes + ":" + seconds; // create the formatted string

		if(seconds < 10)
		{	minSec=minutes+":"+"0"+seconds;	}
	 	
		if(showDirections)
		{	showDirections = isMoving();	}

		if(jump) 
		{	jump = isJumping();	}

		text = minSec;

		if(timer <= 0)
		{	
			Debug.Log("Done");
			Application.LoadLevel("GameOver");
		}
	}


}