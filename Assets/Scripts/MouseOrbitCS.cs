using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOrbitCS : MonoBehaviour {
	public Transform target;
	public Transform camTarget;

	float distance = 10.0f;
	int Yzoom = 3;

	float xSpeed = 250.0f;
	float ySpeed = 120.0f;

	int yMinLimit = -20;
	int yMaxLimit = 80;

	private float x = 0.0f;
	private float y = 0.0f;

	public Quaternion rotation;
	public Vector3 position;

	void Start() {
		Vector3 angles = new Vector3 (10, 170, 0);
		x = angles.y;
		y = angles.x;

		// Make the rigidbody not change rotation
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
	}



	void LateUpdate () {
		if (target && Input.GetMouseButton(2)) {
			x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
			y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
		}

		if (Input.GetAxis("Mouse ScrollWheel") < 0 && target.position.y > 6) { // back
			if(Yzoom > 0.1f ) {
				//Yzoom -= 1;
				//Debug.Log(GetComponent<Rigidbody>().position.y);
				camTarget.Translate(new Vector3(0,Yzoom,0));
			}
		}

		if (Input.GetAxis("Mouse ScrollWheel") > 0 ) { // forward

			if(Yzoom < 80) {

				//Yzoom += 1;
				camTarget.Translate(new Vector3(0,-Yzoom,0));
			}

		}

		y = ClampAngle(y, yMinLimit, yMaxLimit);

		rotation = Quaternion.Euler(y, x + 180, 0);
		position = rotation * new Vector3 (0.0f, 0.0f, -distance) + target.position ;

	

		GetComponent<Rigidbody>().transform.rotation = rotation;
		GetComponent<Rigidbody>().transform.position = position;


	}



	public void rotateLeft()  {  x += 1 * xSpeed * 0.015f;   }
	public void rotateRight() {  x -= 1 * xSpeed * 0.015f;   }

	public float ClampAngle (float angle, float min, float max) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);

	}

}
