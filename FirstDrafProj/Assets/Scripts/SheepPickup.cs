using UnityEngine;
using System.Collections;

public class SheepPickup : MonoBehaviour
{
	public GameObject	balloonSheep;
	public Transform	sheepNode;
	GameObject	sheep;
	public bool	holdingSheep = false;

	public int score = 0;
	GUIStyle myStyle;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnGUI()
	{
		myStyle = new GUIStyle();
		myStyle.fontSize = 50;
		myStyle.normal.textColor = Color.white;
		myStyle.font = (Font)Resources.Load("Fonts/Boingo");

		GUI.Label(new Rect(10,10,100,20), "Score: " + score.ToString(), myStyle);

	}
	
	void OnTriggerStay(Collider other)
	{
		if(holdingSheep)
		{
			if(Input.GetKeyDown(KeyCode.E) && other.tag == "Balloon")
			{
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

				score = score+100;
			}
		}
	}
}