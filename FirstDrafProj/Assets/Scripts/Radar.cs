using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour
{
	public Texture blip; // texture to use when the enemy isn't chasing
	public Texture station;
	public Texture radarBG;
	
	public Transform centerObject;
	public float mapScale = 3;
	public float mapSizePercent = 15;
	
	string enemyTag = "Sheep";
	string stationTag = "Balloon";
	
	enum radarLocationValues {topLeft, topCenter, topRight, middleLeft, middleCenter, middleRight, bottomLeft, bottomCenter, bottomRight, custom}
	radarLocationValues radarLocation = radarLocationValues.bottomLeft;
	
	private float mapWidth;
	private float mapHeight;
	private Vector2 mapCenter;
	Vector2 mapCenterCustom;
	
	SheepPickup pickup;


	// Use this for initialization
	void Start ()
	{
		centerObject = transform;
		setMapLocation();
		pickup = GetComponent<SheepPickup>();
	}

	void OnGUI()
	{
		float bX=centerObject.transform.position.x * mapScale;
		float bY=centerObject.transform.position.z * mapScale;	
		GUI.DrawTexture(new Rect(mapCenter.x - mapWidth/2,mapCenter.y-mapHeight/2,mapWidth,mapHeight),radarBG);
		
		if(pickup.holdingSheep)
		{
			DrawBlipsForStations();
			// Draw blips for Enemies
			DrawBlipsForEnemies();
		}
		else
		{
			DrawBlipsForEnemies();
			DrawBlipsForStations();
		}
	}
	
	void drawBlip (GameObject go, Texture aTexture)
	{
		Vector3 centerPos=centerObject.position;
		Vector3 extPos=go.transform.position;
		
		// first we need to get the distance of the enemy from the player
		float dist=Vector3.Distance(centerPos,extPos);
		
		float dx=centerPos.x-extPos.x; // how far to the side of the player is the enemy?
		float dz=centerPos.z-extPos.z; // how far in front or behind the player is the enemy?
		
		// what's the angle to turn to face the enemy - compensating for the player's turning?
		float deltay=Mathf.Atan2(dx,dz)*Mathf.Rad2Deg - 270 - centerObject.eulerAngles.y;
		
		// just basic trigonometry to find the point x,y (enemy's location) given the angle deltay
		float bX=dist*Mathf.Cos(deltay * Mathf.Deg2Rad);
		float bY=dist*Mathf.Sin(deltay * Mathf.Deg2Rad);
		
		bX=bX*mapScale; // scales down the x-coordinate so that the plot stays within our radar
		bY=bY*mapScale; // scales down the y-coordinate so that the plot stays within our radar

		if(dist<=mapWidth*.5/mapScale){ 
			// this is the diameter of our largest radar circle
			GUI.DrawTexture(new Rect(mapCenter.x+bX,mapCenter.y+bY,30,30),aTexture);
		}
	}

	void DrawBlipsForEnemies()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(enemyTag); 
		
		var distance = Mathf.Infinity; 
		var position = transform.position; 
		
		// Iterate through them and call drawBlip function
		foreach (GameObject go in gos)  { 
			Texture blipChoice = blip;
			drawBlip(go,blipChoice);
		}
	}

	void DrawBlipsForStations()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(stationTag); 
		
		var distance = Mathf.Infinity; 
		var position = transform.position; 
		
		// Iterate through them and call drawBlip function
		foreach (GameObject go in gos)  { 
			Texture blipChoice = station;
			drawBlip(go,blipChoice);
		}
	}

	void setMapLocation()
	{
		mapWidth = Screen.width*mapSizePercent/100;
		mapHeight = mapWidth;
		
		//sets mapCenter based on enum selection
		if(radarLocation == radarLocationValues.topLeft){
			mapCenter = new Vector2(mapWidth/2, mapHeight/2);
		} else if(radarLocation == radarLocationValues.topCenter){
			mapCenter = new Vector2(Screen.width/2, mapHeight/2);
		} else if(radarLocation == radarLocationValues.topRight){
			mapCenter = new Vector2(Screen.width-mapWidth/2, mapHeight/2);
		} else if(radarLocation == radarLocationValues.middleLeft){
			mapCenter = new Vector2(mapWidth/2, Screen.height/2);
		} else if(radarLocation == radarLocationValues.middleCenter){
			mapCenter = new Vector2(Screen.width/2, Screen.height/2);
		} else if(radarLocation == radarLocationValues.middleRight){
			mapCenter = new Vector2(Screen.width-mapWidth/2, Screen.height/2);
		} else if(radarLocation == radarLocationValues.bottomLeft){
			mapCenter = new Vector2(mapWidth/2, Screen.height - mapHeight/2);
		} else if(radarLocation == radarLocationValues.bottomCenter){
			mapCenter = new Vector2(Screen.width/2, Screen.height - mapHeight/2);
		} else if(radarLocation == radarLocationValues.bottomRight){
			mapCenter = new Vector2(Screen.width-mapWidth/2, Screen.height - mapHeight/2);
		} else if(radarLocation == radarLocationValues.custom){
			mapCenter = mapCenterCustom;
		}
	}
}
