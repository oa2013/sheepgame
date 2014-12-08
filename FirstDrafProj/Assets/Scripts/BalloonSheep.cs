using UnityEngine;
using System.Collections;

public class BalloonSheep : MonoBehaviour {
	
	public Transform target;
	public float speed;
	public float lift;

	public GameObject Sheep;
	public GameObject CloneSheep;
	
	void  Start()
	{
		target = GameObject.FindGameObjectWithTag("LandingZone").transform;
		lift = Mathf.Sqrt (Mathf.Pow (transform.position.x - target.transform.position.x, 2) + Mathf.Pow (transform.position.z - target.transform.position.z, 2))/(Mathf.Abs(transform.position.y-target.transform.position.y+1)*3);
	}
	
	void Update() {
		speed = 2;
		lift = Mathf.Sqrt (Mathf.Pow (transform.position.x - target.transform.position.x, 2) + Mathf.Pow (transform.position.z - target.transform.position.z, 2))/(Mathf.Abs(transform.position.y-target.transform.position.y+1)*3);

		transform.Translate(Vector3.up * lift * Time.deltaTime, Space.World);
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		if ((transform.position - target.transform.position).magnitude < .25) 
		{
			CloneSheep = Instantiate(Sheep, transform.position, transform.rotation) as GameObject;
			DestroyObject(gameObject);
		}
	}
}
