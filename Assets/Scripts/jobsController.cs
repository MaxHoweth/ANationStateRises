using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class jobsController : MonoBehaviour {

	public List<GameObject> AiTargets = new List<GameObject>();

	// Use this for initialization
	void Awake () {
		//InvokeRepeating("repopulateAiTargetList",0.1f,5);
	}
	
	public void addObjectToTargetList(GameObject obj) {
		if(!AiTargets.Contains(obj)) {  AiTargets.Add( obj);  }
			




	}
	public void removeObjectFromTargetList(GameObject obj) {
		if(AiTargets.Contains(obj)) {  AiTargets.Remove(obj);  }


	}



}
