using UnityEngine;
using System.Collections;

public class stockpile : MonoBehaviour {
	public bool needToInstantiate = false;

	public int numberOfLogs = 0;

	public GameObject instanceOne;
	public GameObject instanceTwo;
	public GameObject instanceThree;
	public GameObject instanceFour;

	public GameObject logPrefab;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


			if(numberOfLogs == 0) {}

			if(numberOfLogs == 1) {


				
			}

			if(numberOfLogs == 2) {}

			if(numberOfLogs == 3) {}

			if(numberOfLogs == 4) {
				this.gameObject.tag = "fullstockpile";
		}
		else  this.gameObject.tag = "stockpile";










	}


	public void addLogs(int number,GameObject logOne) {
		if(numberOfLogs < 3 || numberOfLogs == 3) {
			logOne.GetComponent<Rigidbody>().isKinematic = true;


			if(numberOfLogs == 0) { 
				instanceOne = logOne; 
				logOne.transform.rotation = transform.rotation;
				logOne.transform.position =  transform.position + new Vector3(0.6f,1.3f,0);
			}

			if(numberOfLogs == 1) {
				instanceTwo = logOne; 
				logOne.transform.rotation = transform.rotation;
				logOne.transform.position =  transform.position + new Vector3(-0.8f,1.3f,0);
			}
			if(numberOfLogs == 2) { 
				instanceThree = logOne;
				logOne.transform.rotation = transform.rotation;
				logOne.transform.position =  transform.position + new Vector3(0.6f,2.3f,0);
			}
			if(numberOfLogs == 3) { 
				instanceFour = logOne; 
				logOne.transform.rotation = transform.rotation;
				logOne.transform.position =  transform.position + new Vector3(-0.6f,2.3f,0);
			
			}

			numberOfLogs = numberOfLogs + 1;


			logOne.tag = "stockpilelog";
			logOne.transform.parent = gameObject.transform;



		}


	}

	public GameObject removeLogs(int number, GameObject parent) {
		GameObject returnObj = new GameObject();

		if(numberOfLogs < 4 || numberOfLogs == 4) { 
			if(numberOfLogs == 1) {
				returnObj = instanceOne;
				instanceOne.transform.parent = parent.transform;
				//instanceOne = null;
				numberOfLogs = 0;
				
			}
			if(numberOfLogs == 2) {
				returnObj = instanceTwo;
				instanceTwo.transform.parent = parent.transform;
				//instanceTwo = null;
				numberOfLogs = 1;
				
			}
			if(numberOfLogs == 3) {
				returnObj = instanceThree;
				instanceThree.transform.parent = parent.transform;
				//instanceThree = null;
				numberOfLogs = 2;
				
			}

			if(numberOfLogs == 4) {
				returnObj = instanceFour;
				instanceFour.transform.parent = parent.transform;
				//instanceFour = null;
				numberOfLogs = 3;

			}

		
		
		
		
		
		
		}


		return returnObj;




	}

}
