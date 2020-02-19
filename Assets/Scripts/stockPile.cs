using UnityEngine;
using System.Collections;

public class stockPile : MonoBehaviour {
	public GameObject logResource;

	int resourceType = 0;
	public bool hasFourLogs = false;
	public bool hasInstantiatedFourLogs = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(hasFourLogs) {

			if(!hasInstantiatedFourLogs) { Instantiate(logResource,this.transform.position, Quaternion.Euler(new Vector3(270,0,0)));  }
			hasInstantiatedFourLogs = true;
			//instantiate the 4 logs


		}

		else{

			//destroy the four logs instances

		}
	}
}
