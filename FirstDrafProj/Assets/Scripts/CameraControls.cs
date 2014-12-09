using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour 
{
	public Transform	camera;

	public float	zoomSpeed = 1.5f;
	public float	minDist = 3;
	public float	maxDist = 7;

	public float	xSpeed = 15;
	public float	ySpeed = 40;
	public float	rangeX = 10;
	public float	rangeY = 30;

	Vector3	line;
	float	zoom;
	float	distance;

	public float	x;
	public float	y;

	void Start() 
	{
		x = transform.eulerAngles.x;
		y = transform.eulerAngles.y;
	}
	
	void LateUpdate() 
	{
		x -= Input.GetAxis("Mouse Y") * xSpeed * Time.deltaTime;
		y += Input.GetAxis("Mouse X") * ySpeed * Time.deltaTime;

		x = Mathf.Clamp(x,-rangeX,rangeX);
		y = Mathf.Clamp(y,-rangeY,rangeY);

		transform.localEulerAngles = new Vector3(x, y, 0);

		line = transform.position - camera.position;
		zoom = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; //zoom
		distance = Vector3.Magnitude(line);

		if(distance < maxDist && distance > minDist)
		{	camera.Translate(Vector3.Normalize(line) * zoom * Time.deltaTime,Space.World);	}
		else if(distance >= maxDist && zoom > 0)
		{	camera.Translate(Vector3.Normalize(line) * zoom * Time.deltaTime,Space.World);	}
		else if(distance <= maxDist && zoom < 0)
		{	camera.Translate(Vector3.Normalize(line) * zoom * Time.deltaTime,Space.World);	}

		distance = 0;
	}
/*
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(camera.position, camera.position + Vector3.Normalize(transform.position - camera.position));
	}
*/
}
