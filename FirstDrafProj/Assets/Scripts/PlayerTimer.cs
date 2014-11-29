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

	void Start(){
		timer = 300;
		SheepTimer.transform.position.Set(timerXf,timerYf,timerZf);
	}
	
	
	
	void Update(){
		if(timer > 0){
			timer -= Time.deltaTime;
		}
		if(timer <= 0){
			Debug.Log("GAME OVER");
		}
		float t = Mathf.Abs(timer); // get the absolute timer value
		int seconds = (int) t % 60; // calculate the seconds
		int minutes = (int) t / 60; // calculate the minutes
		string minSec = minutes + ":" + seconds; // create the formatted string
	 	GetComponent<TextMesh>().text =minSec; // update the GUIText
	}

}