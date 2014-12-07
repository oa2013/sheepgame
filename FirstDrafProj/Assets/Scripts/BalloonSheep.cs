using UnityEngine;
using System.Collections;

public class BalloonSheep : MonoBehaviour {
	
	public Transform target;
	public float speed=2;
	float sheepX=-1.7813109f;
	float LandZoneX=1252.208f;
	float LandZoneY=32.74061f;
	float LandZoneZ=642.4691f;
	
	public GameObject BalloonSheepClone;
	public GameObject Sheep;
	public GameObject LandingZone;
	public GameObject CloneSheep;
	
	void  Start()
	{
		LandingZone = GameObject.FindGameObjectWithTag("LandingZone");
		Sheep = GameObject.FindGameObjectWithTag ("Sheep");
		target = LandingZone.transform;
	}
	
	void Update() {
		LandingZone.transform.position.Set( LandZoneX, LandZoneY,LandZoneZ);
		speed = 2;
		Sheep = GameObject.FindGameObjectWithTag ("Sheep");
		
		
		float step = speed * Time.deltaTime;
		transform.Translate(Vector3.up * Time.deltaTime, Space.World);
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		transform.position.Set (sheepX, transform.position.y, transform.position.z);
		if ((transform.position - target.transform.position).magnitude < .25) 
		{
			CloneSheep = Instantiate(Sheep, transform.position, transform.rotation) as GameObject;
			DestroyObject(gameObject);
		}
	}
}
