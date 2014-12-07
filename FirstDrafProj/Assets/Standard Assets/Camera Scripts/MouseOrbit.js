var target : Transform;

var distance = 10.0;
var distanceMin = 3;
var distanceMax = 15;

var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20f;
var yMaxLimit = 80f;

private var x = 0.0;
private var y = 0.0;

var rotationY = 0;

@AddComponentMenu("Camera-Control/Mouse Orbit")
partial class MouseOrbit { }

function Start () {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;

	// Make the rigid body not change rotation
   	if (rigidbody)
		rigidbody.freezeRotation = true;
		
}

function LateUpdate () {
    if (target) {
    
        x += Input.GetAxis("Horizontal") * xSpeed * 0.02; //follow the player's horizontal rotation
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 		
 		//y = ClampAngle(y, yMinLimit, yMaxLimit);
		//Quaternion toRotation = Quaternion.Euler(x,y,0);
		//Quaternion rotation = toRotation;
 		       
        var rotation = Quaternion.EulerAngles(y * Mathf.Deg2Rad, x * Mathf.Deg2Rad, 0);
        
        distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel")*2, 0, 50);
      
        var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
       
    }
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}