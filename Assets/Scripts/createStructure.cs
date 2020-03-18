using UnityEngine;
using System.Collections;

public class createStructure : MonoBehaviour {
	public bool hasBlueprintAtCursor = false;
	public bool hasGeneratedBlueprint = false;
	public bool hasPlacedObject = false;

	bool structureIsAttachedToMouse = false;

	Vector3 objectRotation = new Vector3(0,0,0);

	bool hasPlacedStructure= false;

	public string currentModel = "";
	GameObject obj;


	public GameObject mineHoloPrefab;
	public GameObject minePrefab;

	public GameObject stockpilePrefab;

	public GameObject barracksPrefab;


	public GameObject tribalShackPrefab;
	public GameObject tribalshackPrefab;

	public GameObject homeHoloPrefab;

	GameObject holoAtCursor;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.R)) {objectRotation += new Vector3(0,-0.7f,0);}
		if(Input.GetKey(KeyCode.T)) {objectRotation += new Vector3(0,0.7f,0);}



		//recreate this function so it attaches whatever is currently selected to the mose
		//attachStructureToMouse (minePrefab,mineHoloPrefab);
		attachModelToMouse();
	}
	public void attachModelToMouse() {

		if(currentModel == "tribalshack") {       obj = tribalshackPrefab; }

		if(currentModel == "stockpile") {      	  obj = stockpilePrefab; }

		if (currentModel == "mine")	 { obj = mineHoloPrefab; }  //NEEDS WORK 

		if (currentModel == "barracks") {       	  obj = barracksPrefab; }


		if (hasPlacedStructure) {   //if the structures been placed reset everything
			hasGeneratedBlueprint = false;
			hasBlueprintAtCursor = false;
			hasPlacedObject = false;
			hasPlacedStructure = false;
			
		}
		if (Input.GetMouseButtonDown (0) && hasBlueprintAtCursor) {
			RaycastHit hit = new RaycastHit ();
			Ray myray = new Ray ();
			myray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (myray, out hit)) {
				
				if (!hasPlacedStructure) {
					
					Object.Destroy (holoAtCursor);


					if (Physics.Raycast (myray, out hit)) {
						
						GameObject inst = Instantiate (obj  , hit.point + new Vector3 (0, 0.2f, 0), new Quaternion (0,0,0,0));
						inst.transform.eulerAngles = objectRotation + new Vector3(270,0,0);
						Debug.Log ("Attempted to instantiate obj");
					}
					hasPlacedStructure = true;
				}
			
			}
		}
		
		if (hasBlueprintAtCursor && !hasGeneratedBlueprint) {    
			RaycastHit hit = new RaycastHit ();
			Ray myray = new Ray ();
			myray = Camera.main.ScreenPointToRay (Input.mousePosition);

			Debug.Log (objectRotation);

			if (Physics.Raycast (myray, out hit)) {
				if(currentModel == "mine") {  holoAtCursor  =	(GameObject)Instantiate(obj,hit.point + new Vector3(0,4,0),Quaternion.identity); }
				if(currentModel == "home") {  
					holoAtCursor  =	(GameObject)Instantiate(homeHoloPrefab,hit.point + new Vector3(0,0,0),Quaternion.identity);
					holoAtCursor.transform.eulerAngles = new Vector3(270,0,0);
				
				}
				if(currentModel == "stockpile") {
					holoAtCursor  =	(GameObject)Instantiate(stockpilePrefab, hit.point ,Quaternion.identity);
					
					holoAtCursor.transform.eulerAngles = new Vector3(270,0,0);

				}
				if(currentModel == "barracks") {
					holoAtCursor  =	(GameObject)Instantiate(barracksPrefab,hit.point + new Vector3(0,4,0),Quaternion.identity);
					holoAtCursor.transform.eulerAngles = new Vector3(270,0,0);
					
				}
				if(currentModel == "tribalshack") {
					holoAtCursor  =	(GameObject)Instantiate(tribalShackPrefab,hit.point + new Vector3(0,4,0),Quaternion.identity);
					holoAtCursor.transform.eulerAngles = new Vector3(270,0,0);
					
				}
				
				hasGeneratedBlueprint = true;
			}
		}
		
		
		if (hasBlueprintAtCursor) {
			
			RaycastHit hit = new RaycastHit ();
			Ray myray = new Ray ();
			myray = Camera.main.ScreenPointToRay (Input.mousePosition);

			holoAtCursor.transform.eulerAngles = objectRotation + new Vector3(270,0,0);
			if (Physics.Raycast (myray, out hit)) {
				
				if(currentModel == "mine")        {  
					holoAtCursor.transform.position = hit.point + new Vector3(0,4,0);
					holoAtCursor.tag = "construction"; 
				}
				if(currentModel == "home")        {   
					holoAtCursor.transform.position = hit.point + new Vector3(0,0.5f,0);  
					holoAtCursor.tag = "construction";   
				}
				if(currentModel == "stockpile")   {
					holoAtCursor.transform.position = hit.point + new Vector3(0,-0.2f,0); 
					holoAtCursor.tag = "construction";  
				}
				if(currentModel == "barracks")    { holoAtCursor.transform.position = hit.point + new Vector3(0,0.2f,0);  holoAtCursor.tag = "construction";   }
				if(currentModel == "tribalshack") { holoAtCursor.transform.position = hit.point + new Vector3(0,0.2f,0);  holoAtCursor.tag = "construction";   }

			}
		}
		
		


	}
	/*
	public void attachStructureToMouse(GameObject obj,GameObject holoObj) {
		
		if (hasPlacedStructure) {   //if the structures been placed reset everything
			hasGeneratedBlueprint = false;
			hasBlueprintAtCursor = false;
			hasPlacedObject = false;
			
		}
		if (Input.GetMouseButtonDown (0) && hasBlueprintAtCursor) {
			
			RaycastHit hit = new RaycastHit ();
			Ray myray = new Ray ();
			myray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (myray, out hit)) {
				if(currentModel == "mine") {
				Object.Destroy(holoAtCursor);
				Instantiate(obj,hit.point + new Vector3(0,4,0),new Quaternion());
				hasPlacedStructure = true;
				}
			}
			
			
		}
		
		if (hasBlueprintAtCursor && !hasGeneratedBlueprint) {
			
			RaycastHit hit = new RaycastHit ();
			Ray myray = new Ray ();
			myray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (myray, out hit)) {
				if(currentModel == "mine") {  
					holoAtCursor  =	(GameObject)Instantiate(holoObj,hit.point + new Vector3(0,4,0),Quaternion.identity);
					hasGeneratedBlueprint = true;
				}
			}
		}
		
		
		if (hasBlueprintAtCursor) {
			
			RaycastHit hit = new RaycastHit ();
			Ray myray = new Ray ();
			myray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			if (Physics.Raycast (myray, out hit)) {
				
				holoAtCursor.transform.position = hit.point + new Vector3(0,4,0);
			}
		}
		
		
		
	}
	
	
	public void generateMine() {
		hasBlueprintAtCursor = true;
		
		
	}
	*/
	public void generateStructure(string input) {

			currentModel = input;
			hasBlueprintAtCursor = true;


	}
}
