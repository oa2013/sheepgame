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

	float timer;

	GUIStyle timerStyle;
	GUIStyle directionsStyle;

	bool showDirections;
	bool jump;

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

		timer = 600;
	}

	void OnGUI () 
	{
		GUI.Label(new Rect(sw*2/5,10,100,20), text, timerStyle);

		if(showDirections)
		{  GUI.Label (new Rect (sw / 2 - 300, sh / 2, 100, 20), "Use the arrow keys to move the girl", directionsStyle);	}
		
		if(jump) 
		{   GUI.Label (new Rect (sw / 2 - 300, (sh / 2)+70, 100, 20), "Press space to jump", directionsStyle);	}
	}
	
	bool isMoving()
	{
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
		{	return true;	}
		else
		{	return false;	}
	}

	bool isJumping()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{	return true;	}
		else
		{	return false;	}
	}

	void Update()
	{
		if(timer <= 0)
		{	Debug.Log("GAME OVER");	}
		else
		{	timer -= Time.deltaTime;	}

		float t = Mathf.Abs(timer); // get the absolute timer value
		int seconds = (int) t % 60; // calculate the seconds
		int minutes = (int) t / 60; // calculate the minutes
		string minSec = minutes + ":" + seconds; // create the formatted string
		if (seconds < 10)
		{	minSec=minutes+":"+"0"+seconds;	}
	 	
		if(isMoving()) 
		{	showDirections = false;	}

		if (isJumping ()) 
		{	jump = false;	}

		text = minSec;
	}

}