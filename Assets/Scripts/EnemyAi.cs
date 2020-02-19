using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {
	//A* Variables and objects///////////////////////////////////////////////////////////
	public GameObject target;


	public GameObject pathRequestManagerObj;
	public float speed = 10;
	public Vector3[] path;
	int targetIndex;
	bool needsToGeneratePath = false;


	void Awake() {
		InvokeRepeating("forceAstarPathForMoveTowardsVector",0.2f,0.55f);

	}

	void forceAstarPathForMoveTowardsVector() {
		StopCoroutine("followPath");
		if(Vector3.Distance(this.transform.position, target.transform.position) > 1.5f) {
			//path = pathRequestManagerObj.GetComponent<aStarPathfinding>().forceFindPath(this.transform.position, target.transform.position); 
			targetIndex = 0;
			StartCoroutine("followPath");
		}
	}

	void forceAstarPath(Vector3 pos1,Vector3 pos2) {
		//path = pathRequestManagerObj.GetComponent<aStarPathfinding>().forceFindPath(pos1, pos2); 
		StopCoroutine("followPath");
		targetIndex = 0;
		StartCoroutine("followPath");
		
		
		
	}
	void requestPathFromManager(Vector3 pos1,Vector3 pos2) {
		//pathRequestManager.requestPath(pos1,pos2, OnPathFound); // Request an A* path
	}
	
	public void OnPathFound(Vector3[] newPath, bool pathSuccesful) {
		if(pathSuccesful) {
			path = newPath;
			StopCoroutine("followPath");
			StartCoroutine("followPath");
			
		}
		
		
	}
	
	IEnumerator followPath() {
		Vector3 currentWaypoint = path[0];
		
		while (true) {
			if(transform.position == currentWaypoint) {
				
				targetIndex++;
				if(targetIndex >= path.Length) { 
					yield break;
					
					
				}
				currentWaypoint = path[targetIndex];
			}
			transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
			yield return null;
			
			
		}
		
		
	}

}
