using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//11/21/2014
//Rukia Brooks

public class PlayerTimer : MonoBehaviour {
	
	public GameObject SheepTimer;

	float sw;
	float sh;

	float timer;
	float timerXf=-5.218667f;
	float timerYf=2.224511f;
	float timerZf=0.6856623f;

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

		timer = 300;
		SheepTimer.transform.position.Set(timerXf,timerYf,timerZf);

	}

	void OnGUI () 
	{
		timerStyle = new GUIStyle();
		timerStyle.fontSize = (int)sh/8;
		timerStyle.normal.textColor = Color.white;
		timerStyle.font = (Font)Resources.Load("Fonts/sheeptype_0");
		GUI.Label(new Rect(sw/2-50,10,100,20), SheepTimer.GetComponent<TextMesh>().text, timerStyle);

		directionsStyle = new GUIStyle();
		directionsStyle.fontSize = (int)sh/16;
		directionsStyle.normal.textColor = Color.white;
		directionsStyle.font = (Font)Resources.Load("Fonts/Boingo");

		if(showDirections)
		{
		  GUI.Label (new Rect (sw / 2 - 300, sh / 2, 100, 20), "Use the arrow keys to move the girl", directionsStyle);
		}

		if(jump) 
		{
		   GUI.Label (new Rect (sw / 2 - 300, (sh / 2)+70, 100, 20), "Press space to jump", directionsStyle);
		}

	}
	
	bool isMoving()
	{
	
		if(Input.GetKey (KeyCode.UpArrow)) 
		{
			return true;
		}

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			return true;
		}

		if(Input.GetKey (KeyCode.RightArrow)) 
		{
			return true;
		}
				
		if(Input.GetKey (KeyCode.LeftArrow)) 
		{
			return true;
		}

		return false;
	}

	bool isJumping()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			return true;
		}
		return false;
	}


	void Update()
	{
		if(timer > 0)
		{
			timer -= Time.deltaTime;
		}

		if(timer <= 0)
		{
			Debug.Log("GAME OVER");
		}

		float t = Mathf.Abs(timer); // get the absolute timer value
		int seconds = (int) t % 60; // calculate the seconds
		int minutes = (int) t / 60; // calculate the minutes
		string minSec = minutes + ":" + seconds; // create the formatted string
		if (seconds < 10) {
			minSec=minutes+":"+"0"+seconds; //fixing the awkward error that is Rukia's Mistake.
		}
	 	
		SheepTimer.GetComponent<TextMesh>().text = minSec;

		if(isMoving()) 
		{
			showDirections = false;
		}

		if (isJumping ()) 
		{
			jump = false;		
		}


	}

}