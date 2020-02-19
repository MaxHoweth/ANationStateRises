using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class menuGui : MonoBehaviour {
	float guiState = 0;
	bool needsToGenerateListOfSaves = false;
	public GameObject terrainGenerator;
	List<string> loads = new List<string>();
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (guiState == 0) {
						if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2) + 60), 200, 40), "SinglePlayer")) {
							guiState = 1;
						}
						if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2)), 200, 40), "Multiplayer")) {
							guiState = 2;
						}
						if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2) - 60), 200, 40), "Options")) {
			
						}
						if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2) - 120), 200, 40), "Quit...")) {
			
						}
				}
		if (guiState == 1) {
					if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2) + 60), 200, 40), "New Game...")) {
						guiState = 3;
					}
					if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - (Screen.height / 2), 200, 40), "Load Game...")) {
						guiState = 6;
						needsToGenerateListOfSaves = true;
					}



				}

		if (guiState == 3) {
					GUI.Label(new Rect((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2) - 200),100,100),"Choose Your race!");

					if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2) ), 200, 40), "Development Map")) {
						Application.LoadLevel("GameWorld1");

					}
					if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2) + 60), 200, 40), "(L)Load Alpha World")) {
				
					}
					if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2) + 110), 200, 40), "Test TerrainGen Map")) {
							terrainGenerator.GetComponent<terrainGenerator>().renderLevel();
					}
					if (GUI.Button (new Rect ((Screen.width / 2) - 40, Screen.height - ((Screen.height / 2) - 80), 200, 40), "Back....")) {
						guiState = 0;
					}

					

				}

		if(guiState == 6) {
			if(needsToGenerateListOfSaves) {
				int count = 0;



				foreach (string file in System.IO.Directory.GetDirectories(Application.dataPath +"/Resources" + "/saves/")){ 


						
						//FileInfo Fi = System.IO.File.GetAttributes
						
						string fileName = "";
						int lastIndexOfSlash = file.LastIndexOf("/");	
						
						fileName = file.Substring(lastIndexOfSlash).Replace("/","");
						
						Debug.Log ("File Name is: " + fileName.Replace(".txt","").Replace("/",""));
						if(GUI.Button (new Rect((Screen.width / 2) - 40,30 + (count * 45),120,40),fileName)) {
					//save load
					//terain generator
						terrainGenerator.GetComponent<terrainGenerator>().loadWorld(fileName.Replace(".txt","").Replace("/",""));
					}
						count++;


				}
				if( GUI.Button (new Rect((Screen.width / 2) - 40,30 + (count * 45),120,40),"Back..") ) { guiState = 0; }

			}


		}

	}
}
