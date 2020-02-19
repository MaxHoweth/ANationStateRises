using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;





public class saveLoad : MonoBehaviour {

	public GameObject treePrefab;
	public GameObject guiObject;
	public GameObject terrainObject;

	public bool needsToSave = false;
	public bool needsToLoad = false;

	public GameObject createdTerrainPrefab;
	public GameObject terrainGeneratorPrefab;

	string savesDirPath = "";
	string dataToWrite = "";
	string _title;
	
	void Start () {
	
		savesDirPath = Application.dataPath;

		//Debug.Log( getVector3FromText("	(12.0, 2.12345, 15678.0)"));
		//Debug.Log( getVector3FromText("	(0.0, -1738.0,2222222.0)"));
	}


	void saveloadCoroutine() {




	}

	void Update () {
			if(needsToSave)   {
				//StartCoroutine("saveTrees");

				saveGameWorld("test");
				needsToSave = false;
			}
			if(needsToLoad) {
				loadGameWorld("test");
				needsToLoad = false;


			}
	} 
	IEnumerator saveTrees() {
		Debug.Log ("started saving trees");
		dataToWrite += "trees:\r\n";
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("tree")) {
			dataToWrite += "\t" + obj.transform.position + "\r\n";
			yield return null;
		}
		dataToWrite += "endTrees:\r\n";


		StartCoroutine(saveRocks());
		Debug.Log ("done saving trees");

	}

	IEnumerator saveRocks() {
		Debug.Log ("started saving rocks");
		dataToWrite += "stone:\r\n";
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("stone")) {
			dataToWrite += "\t" + obj.transform.position + "\r\n";
			yield return null;
		}
		dataToWrite += "endStone:\r\n";


		StartCoroutine(saveTerrain());
	}

	IEnumerator saveTerrain() {
		Debug.Log ("Started saving terrain");
		//dataToWrite += Terrain.activeTerrain.SampleHeight(new Vector3(500,0,500));
		string terraindata = "";
		int terrain_width  = Terrain.activeTerrain.terrainData.heightmapWidth;
		int terrain_height = Terrain.activeTerrain.terrainData.heightmapHeight;
		
		foreach(int h in Terrain.activeTerrain.terrainData.GetHeights(0,0,terrain_width,terrain_height)){
			terraindata += " " + h;
			yield return null;
			
			
			
		}
		dataToWrite += "terraindata: \r\n";
		dataToWrite += terraindata;
		dataToWrite += "endterraindata:\r\n";
		
		
		
		System.IO.File.WriteAllText(savesDirPath + "/Resources/saves/" + _title + "/" + _title + ".txt",dataToWrite);
		Debug.Log("finished saving...");




	}



	void saveGameWorld(string title){ 
		_title = title;
		StartCoroutine(saveTrees());


	

	}

	public void loadGameWorld(string title) {
		string[] lines = System.IO.File.ReadAllLines(savesDirPath + "/Resources/saves/" + title + "/" + title + ".txt");
		                                     

		int lineCount = 0;
		int currentLine = 0;
		int treeStartLine = 0;
		int treeEndLine = 0;

		foreach(string line in lines) { // first loop find identifiers
			lineCount += 1;
			if(line.Contains("trees:")) {treeStartLine = lineCount; }
			if(line.Contains("endTrees:")) {treeEndLine = lineCount; }
		}

		foreach(string line2 in lines) {
			currentLine += 1;

			if((currentLine > treeStartLine) && (currentLine < treeEndLine) )  { 
				//Debug.Log(line2);   

				GameObject tree_inst = (GameObject)Instantiate(treePrefab, getVector3FromText(line2),Quaternion.identity);
					tree_inst.transform.eulerAngles = new Vector3(270,0,0);
					tree_inst.GetComponent<tree>().guiObj = guiObject;


			
			}


		}

		GameObject terrain_obj_inst = (GameObject)Instantiate(Resources.Load("saves/" + title + "/" + title + "_prefab")) as GameObject;
		terrain_obj_inst.name = "terrainObject";

		
		terrain_obj_inst.transform.parent = terrainGeneratorPrefab.transform;
		terrain_obj_inst.transform.position = new Vector3(-5000,0,-5000);



		//Debug.Log (System.IO.File.ReadAllText(savesDirPath + "/" + title + ".txt").IndexOf("trees") );



	}

	Vector3 getVector3FromText(string text) {
		string output = text.Replace("(","");    // Remove "(" from the string
		string output2 = output.Replace(")",""); // Remove ")" from the string

		string part1 = output2.Substring(0, output2.IndexOf(','));  // Read the first part from the beginning to the first comma
		string part3 = output2.Substring(output2.LastIndexOf(',')).Replace(",",""); // Read from last comma to end and remove the comma

		string step1 = output2.Replace(part1,""); // remove first part 
		string step2 = step1.Replace(part3,"");   // remove last part
		string step3 = step2.Replace(",","");    //remove comma from the remaining center value

		string part2 = step3; //set part 2 to equal the third step of removal to keep naming convention the same

		float part1_f = float.Parse(part1);    //convert them all to float
		//float outIGuess = 0;
		float part2_f;
			float.TryParse(part2, out part2_f);

		float part3_f = float.Parse (part3);

		Vector3 output_vec = new Vector3(part1_f,part2_f, part3_f);  //Make them a new Vector3

		return output_vec;
	}





}
