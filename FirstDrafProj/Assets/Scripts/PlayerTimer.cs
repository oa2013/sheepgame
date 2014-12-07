using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//11/21/2014
//Rukia Brooks

public class PlayerTimer : MonoBehaviour {
	
	public GameObject SheepTimer;
	float timer;
	float timerXf=-5.218667f;
	float timerYf=2.224511f;
	float timerZf=0.6856623f;
	GUIStyle timerStyle;

	void Start()
	{
		timer = 300;

		SheepTimer.transform.position.Set(timerXf,timerYf,timerZf);

	}

	void OnGUI () 
	{
		timerStyle = new GUIStyle();
		timerStyle.fontSize = 100;
		timerStyle.normal.textColor = Color.white;
		timerStyle.font = (Font)Resources.Load("Fonts/sheeptype_0");
		GUI.Label(new Rect(800,10,100,20), SheepTimer.GetComponent<TextMesh>().text, timerStyle);
	}
	
	
	void Update(){
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


	}

}