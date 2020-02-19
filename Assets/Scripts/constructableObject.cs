using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constructableObject : MonoBehaviour {
	public string constructionType = "";

	public int stepOfConstruction = 0;
	int prevStepOfConstruction = 0;
	public int numOfLogsCollected = 0;
	public bool needToInstantiate = false;

	public GameObject tribalshack_step0;
	public GameObject tribalshack_step1;
	public GameObject tribalshack_step2;
	public GameObject tribalshack_step3;

	public GameObject home_step0;
	public GameObject home_step1;
	public GameObject home_step2;
	public GameObject home_step3;

	public GameObject tribal_barracks0;
	public GameObject tribal_barracks1;
	public GameObject tribal_barracks2;
	public GameObject tribal_barracks3;
	public GameObject tribal_barracks4;
	public GameObject tribal_barracks5;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		switch (constructionType) {
			case "tribalShack"   : tribalShackUpdate();   break;
			case "colonialHome"  : colonialHomeUpdate();  break;
			case "tribalBarracks": tribalBarracksUpdate();     break;
			case "shrine"        : shrineUpdate();        break; 

		}
		Debug.Log (stepOfConstruction);
		if (stepOfConstruction != prevStepOfConstruction) { 
			needToInstantiate = true;
		} 
		else {
			needToInstantiate = false;
		}


		prevStepOfConstruction = stepOfConstruction;
	} 







	void tribalShackUpdate()  {
		if(numOfLogsCollected < 4)							  {   stepOfConstruction = 0;   }
		if(numOfLogsCollected > 4 && numOfLogsCollected < 6)  {   stepOfConstruction = 1;   }
		if(numOfLogsCollected > 6 && numOfLogsCollected < 10) {   stepOfConstruction = 2;   }
		if(numOfLogsCollected > 10 && numOfLogsCollected < 14){   stepOfConstruction = 3;   }

		if(stepOfConstruction == 0 && needToInstantiate) {
			//Quaternion thisRotation = this.transform.rotation;
			//thisRotation.eulerAngles += new Vector3(270, 0, 0);

			GameObject createdObject = (GameObject)Instantiate(tribalshack_step0,this.transform.position, this.transform.rotation);

			createdObject.GetComponent<constructableObject>().stepOfConstruction = 0;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			//createdObject.transform.eulerAngles += new Vector3(270,0,0);
			Destroy(gameObject);
			needToInstantiate = false;
		}
		if(stepOfConstruction == 1 && needToInstantiate) {
			//Quaternion thisRotation = this.transform.rotation;
			//thisRotation.eulerAngles += new Vector3(270, 0, 0);


			GameObject createdObject = (GameObject)Instantiate(tribalshack_step1,this.transform.position, this.transform.rotation);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 1;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			//createdObject.transform.eulerAngles += new Vector3(270,0,0);
			Destroy(gameObject);
			needToInstantiate = false;
		}
		if(stepOfConstruction == 2 && needToInstantiate) {
			//Quaternion thisRotation = this.transform.rotation;
			//thisRotation.eulerAngles += new Vector3(270, 0, 0);

			GameObject createdObject = (GameObject)Instantiate(tribalshack_step2, this.transform.position, this.transform.rotation);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 2;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			//createdObject.transform.eulerAngles += new Vector3(270,0,0);
			Destroy(gameObject);
			needToInstantiate = false;
		}
		if(stepOfConstruction == 3 && needToInstantiate) {
			//Quaternion thisRotation = this.transform.rotation;
			//thisRotation.eulerAngles += new Vector3(270, 0, 0);

			GameObject createdObject = (GameObject)Instantiate(tribalshack_step3, this.transform.position, this.transform.rotation);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 3;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			//createdObject.transform.eulerAngles += new Vector3(270,0,0);
			Destroy(gameObject);
			needToInstantiate = false;
		}
	}

	void colonialHomeUpdate() {
		if(numOfLogsCollected < 8)							   {  stepOfConstruction = 0;   }
		if(numOfLogsCollected > 8 && numOfLogsCollected < 16)  {  stepOfConstruction = 1;   }
		if(numOfLogsCollected > 16 && numOfLogsCollected < 24) {  stepOfConstruction = 2;   }
		if(numOfLogsCollected > 24 && numOfLogsCollected < 31) {  stepOfConstruction = 3;    }

		if(stepOfConstruction == 0 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(home_step0,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 0;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);
			Destroy(gameObject);
			needToInstantiate = false;
		}
		if(stepOfConstruction == 1 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(home_step1,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 1;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);
			Destroy(gameObject);
			needToInstantiate = false;
		}
		if(stepOfConstruction == 2 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(home_step2,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 2;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);
			Destroy(gameObject);
			needToInstantiate = false;
		}
		if(stepOfConstruction == 3 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(home_step3,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 3;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);
			Destroy(gameObject);
			needToInstantiate = false;
		}
	}

	void shrineUpdate() { 
		// SHRINE NEEDS CONSTRUCTION STEPS 






	}



	void tribalBarracksUpdate() {
		if(numOfLogsCollected < 5)							   {  stepOfConstruction = 0;    }
		if(numOfLogsCollected > 5 && numOfLogsCollected <= 10)  {  stepOfConstruction = 1;    }
		if(numOfLogsCollected > 10 && numOfLogsCollected <= 25) {  stepOfConstruction = 2;    }
		if(numOfLogsCollected > 25 && numOfLogsCollected <= 40) {  stepOfConstruction = 3;    }
		if(numOfLogsCollected > 40 && numOfLogsCollected < 50) {  stepOfConstruction = 4;    }
		if(numOfLogsCollected == 50) {  						  stepOfConstruction = 5;    }

		if(stepOfConstruction == 0 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(tribal_barracks0,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 0;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);


			Destroy(gameObject);
			needToInstantiate = false;

		}
		if(stepOfConstruction == 1 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(tribal_barracks1,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 1;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);


			Destroy(gameObject);
			needToInstantiate = false;

		}
		if(stepOfConstruction == 2 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(tribal_barracks2,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 2;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);


			Destroy(gameObject);
			needToInstantiate = false;

		}

		if(stepOfConstruction == 3 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(tribal_barracks3,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 3;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);


			Destroy(gameObject);
			needToInstantiate = false;

		}

		if(stepOfConstruction == 4 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(tribal_barracks4,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 4;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);


			Destroy(gameObject);
			needToInstantiate = false;

		}

		if(stepOfConstruction == 5 && needToInstantiate) { 
			GameObject createdObject = (GameObject)Instantiate(tribal_barracks5,this.transform.position,Quaternion.identity);
			createdObject.GetComponent<constructableObject>().stepOfConstruction = 5;
			createdObject.GetComponent<constructableObject>().numOfLogsCollected = numOfLogsCollected;
			createdObject.transform.eulerAngles = new Vector3(270,0,0);


			Destroy(gameObject);
			needToInstantiate = false;

		}




	}

	public void instantiateOnce()  {
		needToInstantiate = true;


	}


}
