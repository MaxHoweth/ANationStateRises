using UnityEngine;
using System.Collections;

public class shrine : MonoBehaviour {
	public GameObject particleSystem1;
	public GameObject particleSystem2;
	public GameObject particleSystem3;
	public GameObject particleSystem4;

	public int tech_tier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		particleSystem1.transform.RotateAround(gameObject.transform.position,Vector3.up,1);
		particleSystem2.transform.RotateAround(gameObject.transform.position,Vector3.up,1);
		particleSystem3.transform.RotateAround(gameObject.transform.position,Vector3.down,1);
		particleSystem4.transform.RotateAround(gameObject.transform.position,Vector3.down,1);
		//particleSystem2.transform.Rotate(new Vector3(0,-0.4f,-4));
		//particleSystem3.transform.Rotate(new Vector3(-0.5f,-0.1f,6f));
		//particleSystem4.transform.Rotate(new Vector3(0.3f,1,-3f));
	}
}
