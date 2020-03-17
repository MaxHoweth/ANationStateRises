using UnityEngine;
using System.Collections;

public class loadWallController : MonoBehaviour {
	public GameObject terrainGeneratorObj;

	public bool needsToGenerateTrees = false;

	
	public GameObject wallObjXpos;
	public GameObject wallObjXneg;
	public GameObject wallObjZpos;
	public GameObject wallObjZneg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void onChildTrigger(GameObject trig) {
		if(trig == wallObjZpos) { 
			//terrainGeneratorObj.GetComponent<terrainGenerator>().generateTrees(2000,10000,new Rect(-550,550,1100,1100)); //new Vector2(-550,550),new Vector2(550,1650)
			//needsToGenerateTrees = false;
		}

		if(trig == wallObjZneg) {
			//terrainGeneratorObj.GetComponent<terrainGenerator>().generateTrees(2000,10000,new Rect(-550,-1650,1100,1100));
			//needsToGenerateTrees = false;
		}




	}



}
