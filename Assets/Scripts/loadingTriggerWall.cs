using UnityEngine;
using System.Collections;

public class loadingTriggerWall : MonoBehaviour {
	public GameObject terrainGenerator;
	bool needsToSelfDestruct = false;

	public 	bool triggerManualGenerateChunck = false;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(triggerManualGenerateChunck) {  
			transform.parent.GetComponent<loadWallController>().onChildTrigger(this.gameObject); 
			transform.parent.GetComponent<loadWallController>().needsToGenerateTrees = true;
			Destroy(this.gameObject);
			triggerManualGenerateChunck = false;
		}

		if(needsToSelfDestruct) {  Destroy(this.gameObject);   }
			
	}


	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			transform.parent.GetComponent<loadWallController>().onChildTrigger(this.gameObject);
			transform.parent.GetComponent<loadWallController>().needsToGenerateTrees = true;


			Debug.Log ("found somethin touching the wall" + other.name);
			//terrainGenerator.GetComponent<terrainGenerator>().generateTrees(2000,10000,new Vector2(-550,-1100),new Vector2(550,-550));
			needsToSelfDestruct = true;
		}
	}
}
