using UnityEngine;
using System.Collections;

public class tree : MonoBehaviour{
	public GameObject selectedIndicatorPrefab;
	public GameObject guiObj;

	bool hasGeneratedSelectedMarker;
	public float health = 100;
	public bool hasBeenClicked = false;
	public GameObject ResourceLog;
	public GameObject treePrefab;
	bool isHarvested = false;
	public bool selected = false;

	void Update() {
		if (selected) { beenSelectedRuntime (); } 
	}

	void hit(float damage) {  
		health -= damage;  
	}
		
	void beenSelectedRuntime() {
		if (selected == true && !hasGeneratedSelectedMarker) {
			GameObject obj = (GameObject)Instantiate ((Object)selectedIndicatorPrefab);
				obj.transform.parent = transform;
				obj.transform.localPosition = new Vector3 (0, 0, 0);
				obj.transform.eulerAngles = new Vector3(180,180,180);
			hasGeneratedSelectedMarker = true;
			gameObject.tag = "tree.selected";
		}


		if (health < 0.5f) {
			if(!isHarvested){

				GameObject inst1 = (GameObject)Instantiate(ResourceLog,gameObject.transform.position + new Vector3(0,0.7f,0),new Quaternion());
				inst1.tag = "log";
				GameObject inst2 = (GameObject)Instantiate(ResourceLog,gameObject.transform.position + new Vector3(0.3f,3.9f,0),new Quaternion()); //logs spawn off center so they dont stack up
				inst2.tag = "log";
				GameObject inst3 = (GameObject)Instantiate(ResourceLog,gameObject.transform.position + new Vector3(-0.4f,6.5f,0.3f),new Quaternion());
				inst3.tag = "log";
				GameObject inst4 = (GameObject)Instantiate(ResourceLog,gameObject.transform.position + new Vector3(0,9.6f,0),new Quaternion());
				//inst4.tag = "log";
				Object.Destroy(gameObject);

			}
		}


	}

}
