using UnityEngine;
using System.Collections;

public class movementMArker : MonoBehaviour {
	float timer = 0;
	bool destroyed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		timer += 1;

		if (timer > 50 && !destroyed) {
			destroyed = true;
			Object.Destroy (this.gameObject);

				}
		}
}
