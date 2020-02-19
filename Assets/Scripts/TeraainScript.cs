using UnityEngine;
using System.Collections;

public class TeraainScript : MonoBehaviour {

	public GameObject beaconIndicatorPrefab;
	bool hasInstanciatedBeacon = false;



	public bool isPlacingBeacon = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


		if (isPlacingBeacon && Input.GetMouseButton(0)) {
			RaycastHit hit = new RaycastHit ();
			Ray myray = new Ray ();
			myray = Camera.main.ScreenPointToRay (Input.mousePosition);
			

				
			




			if (isPlacingBeacon && !hasInstanciatedBeacon) {
				if (Physics.Raycast (myray, out hit)) 
				
				Instantiate(beaconIndicatorPrefab,hit.point + new Vector3(0,2,0),new Quaternion());
				hasInstanciatedBeacon = true;

				/*
				foreach(GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
				{
					if(gameObj.name.Contains("tree"))
					{
						
					//	if(Vector3.Distance (gameObj.transform.position,) > 12) {




					//	}
						
					}
				}
				*/

				
			}
				
				
			
			
				
			
		}

	}

	void OnMouseDown() {


		Debug.Log("Left mouse button pressed on teraain");




		foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag("Player")) 
		{
			if(gameObj.name.Contains("AItest"))
			{

				gameObj.GetComponent<Ai>().selected = false;
				gameObj.GetComponent<Ai>().mouseOverrideSelected = false;

			}
		}

	}
}
