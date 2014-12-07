using UnityEngine;
using System.Collections;

public class followCamera : MonoBehaviour 
{

	public GameObject target;
	public float damping = 1;
	Vector3 offset;

	public float distance = 50;
	public float sensitivityDistance = 50;
	public float cameraDamping = 10;
	public float minFOV = 5;
	public float maxFOV = 100;


	void Start() 
	{
		offset = target.transform.position - transform.position;
		distance = camera.fieldOfView;
	}
	
	void LateUpdate() 
	{
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = target.transform.eulerAngles.y;
		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
		
		Quaternion rotation = Quaternion.Euler(0, angle, 0);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt(target.transform);

		distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance; //zoom
		distance = Mathf.Clamp(distance, minFOV, maxFOV);
		camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, distance, Time.deltaTime * damping);
	}
}

