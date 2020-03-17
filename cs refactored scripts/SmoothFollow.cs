using UnityEngine;



public class SmoothFollow : MonoBehavior {
	Transform target;      // The target we are following
	float distance = 10.0f; // The distance in the x-z plane to the target
	float height = 5.0f;    // the height we want the camera to be above the target

	float heightDamping = 2.0f;
	float rotationDamping = 3.0f;

	void LateUpdate() {
		
		if (!target) {   return;   }    // Early out if we don't have a target

		// Calculate the current rotation angles
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;

		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;

		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the height of the camera
		transform.position.y = currentHeight;

		// Always look at the target
		transform.LookAt (target);


	}

}

