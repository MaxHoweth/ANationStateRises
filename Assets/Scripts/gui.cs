using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gui : MonoBehaviour {
	float guiState = 0;
	public GameObject createStructures;
	public GameObject terrain;
	public GameObject jobsController;
	public GameObject selectedAi;
	public GameObject AStarObject;

	float menuTopPos;
	float buttonWidth;
	float buttonSpacing;
	float buttonHeight;

	public List<GameObject> listOfAis;

	public bool isSelectingTrees = false;
	bool jobMenuHasBeenBuilt = false;

	public bool isFollowingAi = false;
	public bool hasAiSelected = false;

	public bool hasOverlayingMenu = false;
	public string overlayingMenuString = "";

	bool hasScienceMenuOverlay = false;
	bool hasGoldMenuOverlay = false;
	bool hasPopulationMenuOverlay = false;

	public GameObject cameraTargetObj;


	int jobMenuState = 0;
	

	public float resourceGold = 0;
	float resourceScience = 0;
	float resourcePopulation = 4;


	void Update () {
		menuTopPos = Screen.height - 75; 		 //initilizing value for menuTopPos
		buttonWidth = Screen.width / 6; 		 //initilizing value for buttonWidth
		buttonHeight = 75;					     //initilizing value for buttonHeight
		buttonSpacing = (Screen.width / 6) + 2;  //initilizing value for buttonSpacing
	}

	void OnGUI() {

		if(hasOverlayingMenu) {  
			buildResourcesBar();
			buildScienceMenu(); 
		}
		if(!hasOverlayingMenu) { 
			buildResourcesBar();
			runGUIstate (guiState);
			if(hasAiSelected) { runAiSelectedGui();   }
		}

	}
	void runAiSelectedGui()  {
		GUI.Box(new Rect(Screen.width - 150,30,150,200),selectedAi.name.Substring(7).Replace("_"," "));

		if(GUI.Button(new Rect(Screen.width - 110,65,100,30),"Follow")) {  isFollowingAi = !isFollowingAi;   }
		if(isFollowingAi) {
			cameraTargetObj.transform.position = selectedAi.transform.position;
			cameraTargetObj.GetComponent<camTarget>().isFrozen = true;
		}
		else {
			cameraTargetObj.GetComponent<camTarget>().isFrozen = false;

		}
	}

	void runGUIstate(float state) {
		
		if (state == 0) {
				/*
				if(GUI.Button(new Rect(Screen.width - 80, 0, 80, 80),"To World View..")){
					Application.LoadLevel("WorldView");
				}
				*/
			
			if(GUI.Button(new Rect(0,menuTopPos, buttonWidth, buttonHeight),"Orders")){
				guiState = 4;
			}
			if(GUI.Button(new Rect(buttonSpacing ,menuTopPos, buttonWidth, buttonHeight),"Construction")){
				guiState = 2;
			}
			if(GUI.Button(new Rect(buttonSpacing * 2 ,menuTopPos, buttonWidth, buttonHeight),"Structures")){
				guiState = 3;
			}
			if(GUI.Button(new Rect(buttonSpacing * 3,menuTopPos, buttonWidth, buttonHeight),"Production")){

			}
			if(GUI.Button(new Rect(buttonSpacing * 4,menuTopPos, buttonWidth, buttonHeight),"Military")){
				guiState = 6;
			}
			if(GUI.Button(new Rect(buttonSpacing * 5,menuTopPos, buttonWidth, buttonHeight),"Jobs")){
				guiState = 5;
			}
		}
		
		if (state == 1) {

			if(GUI.Button(new Rect(buttonSpacing *5,menuTopPos, buttonWidth, buttonHeight),"Back...")){  guiState = 0;  }
		}
		/*
		if(state == 2){

			if(GUI.Button(new Rect(buttonSpacing ,menuTopPos, buttonWidth, buttonHeight),"Stockpiles")){
				createStructures.GetComponent<createStructure>().generateStructure("stockpile");
				//AStarObject.GetComponent<Grid>().updateGrid();
				Debug.Log ("DEBUG:Just tried to regenerate the A*Grid");


			}

			if(GUI.Button(new Rect(buttonSpacing *5,menuTopPos, buttonWidth, buttonHeight),"Back...")){  guiState = 0;  }
		}
		*/

		if (state == 3) {
			if(GUI.Button(new Rect(0,menuTopPos, buttonWidth, 100),"Mine")){
				//righthere is wherei am working iwant it tosnap a holographic mine to the mouse cursor until you click and then place a mine construction
				createStructures.GetComponent<createStructure>().generateStructure("mine");


			}
			if(GUI.Button(new Rect(buttonSpacing ,menuTopPos, buttonWidth, buttonHeight),"Primitive Home")){
				createStructures.GetComponent<createStructure>().generateStructure("tribalshack");
				//createStructures.GetComponent<createStructure>().generateStructure("home");
				//In later tech tiers it will be home but in tier 1 it will be shack

			}
			if(GUI.Button(new Rect(buttonSpacing *2,menuTopPos, buttonWidth, buttonHeight),"Shrine")){
				guiState = 3;
			}
			if(GUI.Button(new Rect(buttonSpacing *3,menuTopPos, buttonWidth, buttonHeight),"Barracks")){
				createStructures.GetComponent<createStructure>().generateStructure("barracks");

				
			}
			if(GUI.Button(new Rect(buttonSpacing *5,menuTopPos, buttonWidth, buttonHeight),"Back...")){
				guiState = 0;
			}




				}

		/*
		if (state == 4) {
			if(GUI.Button(new Rect(0,menuTopPos, buttonWidth, buttonHeight),"Fell Trees")){
				this.isSelectingTrees = true;
			}
			if(GUI.Button(new Rect(buttonSpacing *5,menuTopPos, buttonWidth, buttonHeight),"Back...")){
				guiState = 0;
				this.isSelectingTrees = false;
			}
		}
		*/

	

		if(state == 5) {
			buildJobMenu();
			if(GUI.Button(new Rect(buttonSpacing *5,menuTopPos, buttonWidth, buttonHeight),"Back...")) { guiState = 0;  }
		}

		
		if(state == 6) {
			if(GUI.Button(new Rect(buttonSpacing ,menuTopPos, buttonWidth, buttonHeight),"Loadouts")){

				
			}
			if(GUI.Button(new Rect(buttonSpacing *2,menuTopPos, buttonWidth, buttonHeight),"")){

			}
			if(GUI.Button(new Rect(buttonSpacing *4,menuTopPos, buttonWidth, buttonHeight),"Call Citizen Militia(X)")){
				
			}

			if(GUI.Button(new Rect(buttonSpacing *5,menuTopPos, buttonWidth, buttonHeight),"Back...")) { guiState = 0;  }
		}

	}
	void buildScienceMenu() {
		if(overlayingMenuString == "science") {
			GUI.Box(new Rect(3,31,Screen.width - 6, Screen.height - 37), "TEST BOX FOR SCIENCE MENU");

		}

		if(overlayingMenuString == "gold") {
			GUI.Box(new Rect(3,31,Screen.width - 6, Screen.height - 37), "TEST BOX FOR MONEY MENU");
		}

		if(overlayingMenuString == "population") {
			GUI.Box(new Rect(3,31,Screen.width - 6, Screen.height - 37), "TEST BOX FOR POPULATION MENU");
		}


	}
	void buildResourcesBar() {
		
		// FOOD - WATER - GOLD - POPLATION - SCIENCE
		if(GUI.Button(new Rect (0, 0, 80, 30),  "Gold: " + resourceGold.ToString() )) {               // Resource indicator for Gold 
			overlayingMenuString = "gold"; 

			hasGoldMenuOverlay = !hasGoldMenuOverlay;
			hasPopulationMenuOverlay = false;
			hasScienceMenuOverlay = false;

			if(hasGoldMenuOverlay) {  hasOverlayingMenu = true;  }
			if(!hasGoldMenuOverlay) { hasOverlayingMenu = false; }
		
		
		}

		if(GUI.Button (new Rect (80, 0, 80, 30), "Sci: " + resourceScience.ToString())) {    // Resource indicator for Science
			overlayingMenuString = "science";

			hasGoldMenuOverlay = false;
			hasPopulationMenuOverlay = false;
			hasScienceMenuOverlay = !hasScienceMenuOverlay;

			
			if(hasScienceMenuOverlay) {  hasOverlayingMenu = true;  }
			if(!hasScienceMenuOverlay) { hasOverlayingMenu = false; }

			
		}
		
		if(GUI.Button (new Rect (160, 0, 80, 30), "Pop: " + resourcePopulation.ToString() )){        // Resource indicator for Population
			overlayingMenuString = "population";

			hasGoldMenuOverlay = false;
			hasPopulationMenuOverlay = !hasPopulationMenuOverlay;
			hasScienceMenuOverlay = false;

			
			if(hasPopulationMenuOverlay) {  hasOverlayingMenu = true;  }
			if(!hasPopulationMenuOverlay) { hasOverlayingMenu = false; }
		}
		
		GUI.Box(new Rect(0,menuTopPos,Screen.width,Screen.height),"");
		
		
		GUI.Box(new Rect(0,0,Screen.width,30),"");
		//GUI.Label (new Rect (30, 0, 80, 30), new string(resourceWood));



	}


	void buildJobMenu(){

		int numberOfAis = 0;

		//---For each AI
		//     Build a row with its name
		//     Make the buttons Toggle so only one can be slected
		//     The buttons correspond to that Ais Job
		foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag("Player"))   {

			if(gameObj.name.Contains("AITest"))
			{

				if(!listOfAis.Contains(gameObj)) {    listOfAis.Add (gameObj);    }

				GUI.Box(new Rect(30,  ((numberOfAis + 1) * 25) + 6,Screen.width - 100, 20),"");   //Background Box
					string nameParsed = gameObj.name.Substring(7).Replace("_"," ");
				GUI.Label(new Rect(30,((numberOfAis + 1) * 25) + 6,200,20)," " + nameParsed + " "   ); // Labels the row with the Ais Name

				GUI.Label(new Rect(180, ((numberOfAis + 1) * 25) + 6, 200, 20),convertJobIntToString(listOfAis[numberOfAis].GetComponent<Ai>().job)); // Display The AIs Current Job

				if ( GUI.Button(new Rect(300,((numberOfAis + 1) * 25) + 6,75,20),"Logger")) { 
						listOfAis[numberOfAis].GetComponent<Ai>().job = 2;     
					    listOfAis[numberOfAis].GetComponent<Ai>().selected = false;
					    listOfAis[numberOfAis].GetComponent<Ai>().mouseOverrideSelected = false;
				}
				if( GUI.Button(new Rect(390,((numberOfAis + 1) * 25) + 6,75,20),"Hauler")) { 
					listOfAis[numberOfAis].GetComponent<Ai>().job = 3;    
					listOfAis[numberOfAis].GetComponent<Ai>().selected = false;
					listOfAis[numberOfAis].GetComponent<Ai>().mouseOverrideSelected = false;			
				
				}
				if( GUI.Button(new Rect(480,((numberOfAis + 1) * 25) + 6,75,20),"Builder")) {
					listOfAis[numberOfAis].GetComponent<Ai>().job = 4;  
					listOfAis[numberOfAis].GetComponent<Ai>().selected = false;
					listOfAis[numberOfAis].GetComponent<Ai>().mouseOverrideSelected = false;
				}
				

				//gameObj.GetComponent<Ai>().job = jobMenuState;
				//Debug.Log(gameObj.GetComponent<Ai>().job);
				//Debug.Log(numberOfAis);
				numberOfAis += 1;
			}
		}


	}

	string convertJobIntToString(int input)
    {
		if (input == 0) { return "Unemployed"; }
		else if (input == 2) { return "Logger"; }
		else if (input == 3) { return "Hauler"; }
		else  if (input == 4) { return "Builder"; }

        else { return "UNDEFINED"; }
	}

}
