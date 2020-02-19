using UnityEngine;
using System.Collections;

public class camTarget : MonoBehaviour {
	public GameObject cam;
	bool isPaused = false;
	public bool isFrozen = false;
	int speedModifier = 3;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Quaternion rot = new Quaternion (cam.transform.rotation.x, 0, cam.transform.rotation.z, 0);
		transform.rotation = rot;

		if(isPaused) { Time.timeScale = 0; }
		else{ Time.timeScale = 1; }
		if(Input.GetKey(KeyCode.Space)) { // pause game
			
			isPaused = !isPaused;

		}

		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {    speedModifier = 2;     } 
		else {       speedModifier = 1;       }


		if(Input.GetKey(KeyCode.A) && !isFrozen) {

			//Debug.Log ("A was pressed");

			gameObject.transform.Translate(Vector3.left * speedModifier);
		}

		if(Input.GetKey(KeyCode.D) && !isFrozen) {
			
			//Debug.Log ("D was pressed");
			
			gameObject.transform.Translate(Vector3.right * speedModifier);
		}

		if(Input.GetKey(KeyCode.W)&& !isFrozen) {
			
			//Debug.Log ("W was pressed");
			
			gameObject.transform.Translate(Vector3.back * speedModifier); 
		}

		if(Input.GetKey(KeyCode.S) && !isFrozen) {
			
			//Debug.Log ("S was pressed");
			
			gameObject.transform.Translate(Vector3.forward * speedModifier); 
		}

		if(Input.GetKey (KeyCode.Q)) {
			cam.GetComponent<MouseOrbitCS>().rotateLeft();
		}
		if(Input.GetKey (KeyCode.E)) {
			
			cam.GetComponent<MouseOrbitCS>().rotateRight();
		}
	}
}
