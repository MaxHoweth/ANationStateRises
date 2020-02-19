using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {
	public GameObject terrain;
	public GameObject[]  trees;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void searchTreesInRange() {
		foreach(GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
		{
			if(gameObj.name.Contains("tree"))
			{
				Debug.Log (gameObj.name);
				
				
			}
		}
		
	}



	}

