using UnityEngine;
using System.Collections;

public class BalloonSheep : MonoBehaviour {

	public Transform target;
	public float speed;
	float sheepX=-0.7813109f;

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		transform.Translate(Vector3.up * Time.deltaTime, Space.World);
	}
}
