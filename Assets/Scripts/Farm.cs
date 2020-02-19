using UnityEngine;
using System.Collections;

public class Farm : MonoBehaviour {
	public bool isHarvesting = false;

	int growth = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(growth > 1000) {      harvest();    }


	}



	void harvest() {



	}
}
