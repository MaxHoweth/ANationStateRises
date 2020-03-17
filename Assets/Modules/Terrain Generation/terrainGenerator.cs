 using UnityEngine;
using System.Collections;

public class terrainGenerator : MonoBehaviour {
	public GameObject treePrefab;
	public GameObject rockPrefab;
	public GameObject saveLoad;
	public GameObject mainCameraObject;

	public GameObject guiObj;
	

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}


	public void renderLevel() {
		Destroy(GameObject.Find("Menu_tex"));
		Destroy(GameObject.Find("menuGui"));
		Destroy(GameObject.Find("Menu Camera"));

		mainCameraObject.SetActive(true);

		//Application.LoadLevelAdditive("template_world");

		generateTrees(800,1500,-500,-500,1000);//  new Vector2(-550,-550), new Vector2 (550,550)
		//generateRocks(200,1000,new Rect(-550,-550,550,550));

		guiObj.SetActive(true);



		}

	public void generateTrees(int lowerLimit,int upperLimit,int startX, int startZ, int size) {   
		int limitOfTrees = Random.Range(lowerLimit,upperLimit); 
		Debug.Log ( "MAP GENERATOR:" + limitOfTrees + " Trees generated" + " @:(" + startX + ","  + startZ + ")");

		for(int x = 0;x < limitOfTrees; x++) {
			int randomX = Mathf.RoundToInt(Random.Range(startX, startX + size));
			int randomZ = Mathf.RoundToInt(Random.Range(startZ, startZ + size));

			GameObject obj = (GameObject)Instantiate(treePrefab, new Vector3(randomX,0,randomZ),Quaternion.identity);
			obj.transform.eulerAngles = new Vector3(270,0,0);
			obj.GetComponent<tree>().guiObj = guiObj;
		}  
	}

	void generateRocks(int lowerLimit,int upperLimit,Rect rec) {
		int limitOfRocks = Random.Range(lowerLimit,upperLimit);//700,1500
		
		Debug.Log ( limitOfRocks + " rocks generated");
		
		for(int x = 0;x < limitOfRocks; x++) {
			int randomX = Mathf.RoundToInt(Random.Range(rec.xMin,rec.xMax));
			int randomZ = Mathf.RoundToInt(Random.Range(rec.yMin,rec.yMax));

			GameObject obj = (GameObject)Instantiate(rockPrefab, new Vector3(randomX,-0.3f,randomZ),Quaternion.identity);
			obj.transform.eulerAngles = new Vector3(270,0,0);
		//	obj.GetComponent<tree>().guiObj = guiObj;
		}








	}
		
	public void loadWorld(string path) {
		Destroy(GameObject.Find("Menu_tex"));
		Destroy(GameObject.Find("menuGui"));
		Destroy(GameObject.Find("Menu Camera"));
		
		mainCameraObject.SetActive(true);

		saveLoad.GetComponent<saveLoad>().loadGameWorld(path);


		guiObj.SetActive(true);

	}



	}

