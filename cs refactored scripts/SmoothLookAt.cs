using UnityEngine;


public class SmoothLookAt : MonoBehavior {
	Transform target;
	float damping = 6.0f;
	bool smooth = true;

	Rigidbody rigidbody;

	void Start() {   this.transform.freezeRotation = true;   }

	void LateUpdate () { 
		if(target) {
			if (smooth) {
				rigidbody.transform.rotation = Quaternion.LookRotation (target.position - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
			} 
			else {   transform.LookAt (target);  } // Just lookat  
		}	
	}
}

