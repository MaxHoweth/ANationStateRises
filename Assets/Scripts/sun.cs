using UnityEngine;
using System.Collections;

public class sun : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(new Vector3(0,0,0), Vector3.forward, 6 * Time.deltaTime );


		//Quaternion rotation = Quaternion.LookRotation(new Vector3(0 - transform.position.x, 0 - transform.position.y , 0 - transform.position.z));
		//transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * 10);


	}
}
