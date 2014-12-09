using UnityEngine;
using System.Collections;

public class SheepPickup : MonoBehaviour
{   
	PlayerTimer timer;
	float sw;
	float sh;

	public GameObject	balloonSheep;
	public Transform	sheepNode;
	GameObject	sheep;
	public bool	holdingSheep = false;

	public int score = 0;
	GUIStyle myStyle;
	bool isNearSheep;

	float newTimer; 
	float onlyOnce = 0;

	// Use this for initialization
	void Start ()
	{
		sw = Screen.width;
		sh = Screen.height;
		timer = GameObject.Find("SheepTimer").GetComponent<PlayerTimer>();
		isNearSheep = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnGUI()
	{
		myStyle = new GUIStyle();
		myStyle.fontSize = (int)sh/16;
		myStyle.normal.textColor = Color.white;
		myStyle.font = (Font)Resources.Load("Fonts/Boingo");

		GUI.Label(new Rect(sw/4-50,10,100,20), "Score: " + score.ToString(), myStyle);

		if(isNearSheep) 
		{
			GUI.Label (new Rect (sw / 2 - 300, sh / 2, 100, 20), "Press E to pick up the sheep", myStyle);
		}

	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Sheep" && onlyOnce == 0)
		{
			onlyOnce++;
			isNearSheep = true;
		}

	}
	
		
	void OnTriggerStay(Collider other)
	{
		if(holdingSheep)
		{
			newTimer += Time.deltaTime;
			
			if(newTimer > 2)
			{
				isNearSheep = false;
			}


			if(Input.GetKeyDown(KeyCode.E) && other.tag == "Balloon")
			{
				other.audio.Play();
				score = score+100;
				GameObject.Instantiate(balloonSheep,sheep.transform.position,sheep.transform.rotation);
				Destroy(sheep);
				holdingSheep = false;
			}
		}
		else
		{
			if(Input.GetKey(KeyCode.E) && other.tag == "Sheep")
			{
				print ("pickup");
				sheep = other.gameObject;
				sheep.transform.parent = sheepNode;
				//sheep.SendMessage("Lift",sheepNode);
				holdingSheep = true;


			}
		}
	}
}