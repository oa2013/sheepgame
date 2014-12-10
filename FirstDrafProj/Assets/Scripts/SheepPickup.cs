using UnityEngine;
using System.Collections;

public class SheepPickup : MonoBehaviour
{   

	public GameObject	balloonSheep;
	public Transform	sheepNode;

	public bool	holdingSheep = false;

	GameObject		sheep;
	GUIStyle		myStyle;
	Texture			eKey;
	GameManager		upperManagement;
	SceneManager	manager;
	PlayerTimer		timer;

	float	sw;
	float	sh;
	float	newTimer; 
	bool	isNearSheep;
	bool	firstLevel;

	// Use this for initialization
	void Start ()
	{
		sw = Screen.width;
		sh = Screen.height;
		upperManagement = GameObject.Find("GameManager").GetComponent<GameManager>();
		manager = GameObject.Find ("SceneManager").GetComponent<SceneManager> ();
		timer = GameObject.Find("SheepTimer").GetComponent<PlayerTimer>();
		isNearSheep = false;
		firstLevel = manager.firstLevel;

		eKey = (Texture)Resources.Load ("eKey");

		myStyle = new GUIStyle();
		myStyle.fontSize = (int)sh/16;
		myStyle.normal.textColor = Color.white;
		myStyle.font = (Font)Resources.Load("Fonts/Boingo");
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnGUI()
	{
		GUI.Label(new Rect(sw/16,10,100,20), "Score: " + upperManagement.score.ToString(), myStyle);

		if(isNearSheep) 
		{	GUI.DrawTexture (new Rect (sw*2/5, sh / 2, 100, 100), eKey);	}

	}

	void OnTriggerEnter(Collider col)
	{
		if(firstLevel && (col.tag == "Sheep" || col.tag == "Balloon" || col.tag == "Toy"))
		{	isNearSheep = true;	}

	}

	void OnTriggerExit(Collider other)
	{
		if(firstLevel && (other.tag == "Sheep" || other.tag == "Balloon" || other.tag == "Toy"))
		{	isNearSheep = false;	}
	}
		
	void OnTriggerStay(Collider other)
	{
		if(holdingSheep)
		{

			if(Input.GetKeyDown(KeyCode.E) && other.tag == "Balloon")
			{
				other.audio.Play();
				upperManagement.score = upperManagement.score+100+(int)timer.timer/10;
				GameObject.Instantiate(balloonSheep,sheep.transform.position,sheep.transform.rotation);
				Destroy(sheep);
				manager.SheepSent();
				holdingSheep = false;
				isNearSheep = false;
			}
		}
		else
		{
			if(Input.GetKey(KeyCode.E) && other.tag == "Sheep")
			{
				sheep = other.gameObject;
				sheep.transform.parent = sheepNode;
				//sheep.SendMessage("Lift",sheepNode);
				holdingSheep = true;
				isNearSheep = false;

			}
		}
		if(Input.GetKey(KeyCode.E) && other.tag == "Toy")
		{
			upperManagement.score = upperManagement.score+50;
			Destroy(other.gameObject);
		}
	}
}