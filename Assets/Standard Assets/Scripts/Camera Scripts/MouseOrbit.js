
/*

var target : Transform;
var camTarget : Transform;
var distance = 10.0;
var Yzoom = 5;

var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

private var x = 0.0;
private var y = 0.0;

public var rotation;
public var position;

@script AddComponentMenu("Camera-Control/Mouse Orbit")

function Start () {
    var angles = new Vector3(10,170,0);
    x = angles.y;
    y = angles.x;
	
	

	// Make the rigid body not change rotation
   	if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
		
		

}

sa

function LateUpdate () {
	//Some kind of LOD related to the height of the camera ; ends p creating bscene amunts of lag
	//Camera.mainCamera.farClipPlane = (this.transform.position.y * 5) + 200;
		
    if (target && Input.GetMouseButton(2)) {
        x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
 		
    }
    		
		 if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		        {
		            if(Yzoom > 0.1f) {
		            	Yzoom -= 1;
		            	camTarget.transform.position.y = Yzoom;
		            	}
					else{
					//move away from cameeaTarget

					} 
		 
		        }
		  if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		        {
		            if(Yzoom < 80) {
		            
		            	Yzoom += 1;
		            	camTarget.transform.position.y = Yzoom;
		            	}
		            
		            }
 
 		y = ClampAngle(y, yMinLimit, yMaxLimit);
 		       
        rotation = Quaternion.Euler(y, x + 180, 0);
        position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
        
        transform.rotation = rotation;
        transform.position = position;
}


public function rotateLeft() {
	 x += 1 * xSpeed * 0.015;



}
public function rotateRight() {

 	x -= 1 * xSpeed * 0.015;


}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}



*/