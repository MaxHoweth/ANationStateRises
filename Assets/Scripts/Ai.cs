using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ai : MonoBehaviour {

	public GameObject selectedIndicatorPrefab;
	public GameObject movementIndicatorPrefab;
	public GameObject guiObject;
	public GameObject target;//***************************************************************************
	public GameObject jobsController;
	public GameObject targetLog;
	public GameObject carryObject;
	public GameObject toolObject;
	public GameObject homeObject;

		   GameObject obj;

	//A* Variables and objects///////////////////////////////////////////////////////////

	public GameObject pathFindingObj;
	public float speed = 2;
	public List<Node> path= new List<Node>();
	int targetIndex;
	bool needsToGeneratePath = false;
	////////////////////////////////////////////////////////////////////////////////////
	public float health   = 10;
	public float hunger   = 1000;
	public float thirst   = 100;
	public float sleepDep = 0;
	public float faith = 0;

	public Vector3 moveTowardsVector; //************************************************************


	public string currentAnimation = "";


		   float actionDistance = 3;
		   float Distance = 0;
		   float damping = 10;
		float prayTimer = 0;
		float prayElapsedTime = 0;
		float toolRotation = 0;

	public int job;

	public bool mouseOverrideSelected = false;
	public bool selected = false;
	public bool isCarrying = false;
		   bool hasGeneratedSelectedMarker = false;
	public bool isChoppingLogs = false;
	public bool isSleeping = false;
	public bool isPraying = false;
	// carry to be a script i,e :  carry(stoneOBject) & stopCarrying(stoneObject)


	void FixedUpdate() {
		sleepDep += 0.005f;
		thirst -= 0.002f;
		hunger -= 0.001f;
		faith += 0.002f;

		if(faith > 30) {
			//Debug.Log("Attempting to go to shrine"); this will eventually work to go the shrin but for now ais get stuck in job 25
			//job = 25;
		}

		if(isSleeping) {
			goToSleep();
        }

	}




	void Start () {
		moveTowardsVector = transform.position;    // Initilizes the target positon to where the AI currently is
		this.name = "AITest_" + generateNames();   // Sets the AIs name through generateNames()
	}

	void Awake() {
		//InvokeRepeating("forceAstarPathForMoveTowardsVector",0.1f,0.5f);

	}
	

	void LateUpdate() {

		animateMotion(currentAnimation); 


		if (getDistance(moveTowardsVector, transform.position) > 2) { //If the distance between (moveTowardsVector and Ais Position) > 2
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			transform.eulerAngles = new Vector3(0,transform.eulerAngles.y, transform.eulerAngles.z);

			lookAt ( moveTowardsVector );							  //Look at where the Ais going
			forceAstarPathForMoveTowardsVector();


			//moveTowards();											  //Move towards that point

		}
		else{ 
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

		}






	}
	void Update () {
		

		if(isPraying) {
			Debug.Log(prayElapsedTime);
			if(prayElapsedTime < 30) {
				if(prayTimer < 95 ) {
					transform.eulerAngles = new Vector3(prayTimer,0,0);
					transform.position = new Vector3(transform.position.x,0.4f,transform.position.z);
					prayTimer += 1.3f;
					prayElapsedTime += 0.1f;
				}
				else{
					prayTimer = 0;
					prayElapsedTime += 0.1f;
				}
				//rotate around to make it look like hes praying
			}
			else{
				transform.eulerAngles = new Vector3(0,0,0);
				Debug.Log("Done praying");
				isPraying = false;
			}
		}


		if(GetComponent<Renderer>().isVisible && Input.GetMouseButton(0)) {                        // If the Ai is in screen and the left mouse button is pressed
			Vector3 camPos = Camera.main.WorldToScreenPoint(transform.position);           		   // sets camPos to the cameras current position
			camPos.y = cameraOperator.InvertMouseY(camPos.y);								       // I THINK that this inverts the y coordinate from bottom to top
			if(!mouseOverrideSelected) { selected = cameraOperator.selection.Contains(camPos); }   // If (!mouseovverride) set selected to the Ais that are in box
			else if(mouseOverrideSelected) { selected = true; }                                    // For when the Ai is clicked on directly
		}

		doJob ();


		if(Input.GetMouseButtonDown(1) && selected) {


			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit)){

				moveTowardsVector = hit.point + new Vector3(0,1,0);
				//path = pathFindingObj.GetComponent<Pathfinding>().FindPath(gameObject.transform.position,moveTowardsVector);
				//PathRequestManager.RequestPath(transform.position,moveTowardsVector, OnPathFound);

				GameObject obj = (GameObject)Instantiate ((Object)movementIndicatorPrefab,moveTowardsVector,Quaternion.identity);

			}
		}

		if (selected == true) {
			GetComponent<Renderer>().material.color = Color.red;
			guiObject.GetComponent<gui>().selectedAi = this.gameObject;
			guiObject.GetComponent<gui>().hasAiSelected = true;
			

			
		}
		if (selected == true && !hasGeneratedSelectedMarker) {
			GetComponent<Renderer>().material.color = Color.red;
			obj = (GameObject)Instantiate ((Object)selectedIndicatorPrefab);
			
			obj.transform.parent = transform;
			obj.transform.localPosition = new Vector3 (0, -0.9f, 0);
			obj.transform.localRotation = new Quaternion (0.7071067811865475f, 0, 0.7071067811865476f, 0);
			hasGeneratedSelectedMarker = true;
		}
		
		if (selected == false) {
			GetComponent<Renderer>().material.color = Color.white;
			hasGeneratedSelectedMarker = false;
			Object.Destroy(obj);
			
		}
	}
	void OnMouseDown(){

		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {  mouseOverrideSelected = true;  }
		else{
			foreach(GameObject gameObj in GameObject.FindGameObjectsWithTag("Player")){
				if(gameObj.name.Contains("AItest"))
				{
					
					gameObj.GetComponent<Ai>().selected = false;
					gameObj.GetComponent<Ai>().mouseOverrideSelected = false;
					
				}
			}
			mouseOverrideSelected = true;
			}
	}


	void lookAt(Vector3 lookVec) {
			Quaternion rotation = Quaternion.LookRotation(new Vector3(lookVec.x - transform.position.x, lookVec.y - transform.position.y , lookVec.z - transform.position.z));
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
		}

	void moveTowards() {

		//transform.Translate(Vector3.forward * 0.1f);
		// could i just plug A* Right in here
			

		}
	void goToSleep() {
			transform.eulerAngles = new Vector3(90, 0, 0);
			transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);

	}

	float getDistance(GameObject obj1,GameObject obj2) { return Vector3.Distance (obj1.transform.position, obj2.transform.position);   }
	float getDistance(Vector3 obj1,Vector3 obj2) 	   { return Vector3.Distance (obj1, obj2);  } //Overload for getDistance


	void setTarget(GameObject targ){
		moveTowardsVector =  targ.transform.position;


	}

	void doJob() {
	
		if (job == 2) {   // LOGGER JOB
			if (target == null)
			{
				//obj = returnNearestOfTag ("tree");

				List<GameObject> targets = new List<GameObject>();

				foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("Player"))
				{  // Currently Picks a tree at random i would prefer it find the closest one
					if (!targets.Contains(gameObj))
					{
						targets.Add(gameObj.GetComponent<Ai>().target);
					}
				}

				
					GameObject targetTree = returnNearestOfTag("tree.selected");
					target = targetTree;
					moveTowardsVector = targetTree.transform.position;
					targetTree.tag = "tree.claimed";
				


			}

			if (target != null) {  
				moveTowardsVector = target.transform.position;

				if (getDistance (this.transform.position, moveTowardsVector) < 4) { // if the AI is close enough cut down the tree -> Take Logs to stockpile
					target.GetComponent<tree> ().health -= 0.5f;
					animateMotion ("axe_side_swipe");
					if (target.GetComponent<tree> ().health < 5) {
						animateMotion ("axe_putaway_back");
						}
					}
				}
			}
		if(job == 3) {   // HAULER JOB 
			targetLog = returnNearestOfTag("log");    


				if ( !isCarrying ) { 
					target = targetLog; //needs to find a log not in a stockpile
					moveTowardsVector =  target.transform.position;
						
						if( (getDistance(this.gameObject,targetLog) < 2) ) {
							targetLog.transform.parent = this.transform;
							targetLog.GetComponent<Rigidbody>().isKinematic = true;
							
							isCarrying = true;
							target = null;
							targetLog = null;
						}

						else if (Distance > actionDistance) {     moveTowardsVector = targetLog.transform.position;    }
				}
				
				if(isCarrying == true) {
					GameObject stockpileTarget = GameObject.FindGameObjectWithTag("stockpile");
					target = stockpileTarget;
						

						if( (getDistance(this.gameObject, target) < 3.5f) && isCarrying == true ) {
								target.GetComponent<stockpile>().addLogs(1,targetLog);
								isCarrying = false;

							
						}
						else {
								startCarrying(targetLog);
								//carryObject.tag = "Untagged";
								
								moveTowardsVector = target.transform.position;



						}



				}

			
		
		}

		if (job == 4) {   // BUILDER JOB 
			
		
			//First look for stockpiles with logs
			//If none are found find logs off the ground
			if (!isCarrying) {

				target = returnNearestOfTag("stockpilelog");
					moveTowardsVector = target.transform.position;
				

					if (getDistance (target, transform.gameObject) < 2.4f ) {
						startCarrying (target.transform.parent.GetComponent<stockpile> ().removeLogs (1, this.gameObject));
						isCarrying = true;
						//target.gameObject.tag = "resc.log.carried";
					}

				
				// find log source
				//walk towards Logger source
				//if dist to source is low enough pick up and begin carrying 

			}
			if (isCarrying) {
				target = returnNearestOfTag ("constr.inprogress");


				if (target != null) {
					moveTowardsVector = target.transform.position;

					if (getDistance (target, transform.gameObject) < 3) {
						stopCarrying ();

						if (target.GetComponent<constructableObject> () != null) {


							target.GetComponent<constructableObject> ().numOfLogsCollected += 1;

							//target.GetComponent<constructableObject> ().instantiateOnce ();

							isCarrying = false;
							Destroy (carryObject);
						}
					}
				}
			}

		

		}
		if(job == 25) {  // Go to the nearest shrine and pray

		
			//and the ai goes the shrine prays for a while then goes to a house to sleep and if he has another AI living with him then they mate
			//and a little baby Ai is born and will grow up


		}
	

	

	}
	void startCarrying(GameObject carry_obj)   {
		carryObject = carry_obj;

	

		carryObject.GetComponent<Rigidbody>().isKinematic = true;
		carryObject.transform.eulerAngles = transform.rotation.eulerAngles + new Vector3(270,0,0);
		carryObject.transform.localPosition = new Vector3(0.9f,1,0);
		carryObject.tag = "resc.log.carried";


	}


	void stopCarrying() {



	}
	void forceAstarPathForMoveTowardsVector() {
		//gameObject.GetComponent<Pathfinding>().target = moveTowardsVector;

		StopCoroutine("followPath");

		if(getDistance(this.transform.position,moveTowardsVector) > 1.5f) {

			path = pathFindingObj.GetComponent<Pathfinding>().FindPath(transform.position,moveTowardsVector);
			targetIndex = 0;
			StartCoroutine("followPath");

		}
		/*
		StopCoroutine("followPath");
		if(getDistance(this.transform.position,moveTowardsVector) > 1.5f) {
			//path = pathRequestManagerObj.GetComponent<aStarPathfinding>().forceFindPath(this.transform.position, moveTowardsVector); 
			Debug.Log ("movetowardsvector =" + moveTowardsVector);

			targetIndex = 0;
			StartCoroutine("followPath");
		}
		*/
	}

	void requestPathFromManager(Vector3 pos1,Vector3 pos2) {
		//pathRequestManager.requestPath(pos1,pos2, OnPathFound); // Request an A* path
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccesful) {
			if(pathSuccesful) {
			//path = newPath;
			//StopCoroutine("followPath");
			//StartCoroutine("followPath");

			}


		}

	IEnumerator followPath() {
		path = pathFindingObj.GetComponent<Pathfinding>().grid.path;  //Grabs a path from PathFinding obj(How is this generated?)

			Node currentWaypoint = path[0];                               //Sets current waypoint at the begging, 0

		while (getDistance(this.transform.position, moveTowardsVector) > 1.5f) {  // While distance between this and taget > 1.5
			
			if(getDistance(transform.position,currentWaypoint.worldPosition) < 1) {
				targetIndex++;
				if(targetIndex >= path.Count) { 
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}
			transform.position = Vector3.MoveTowards(  transform.position,currentWaypoint.worldPosition,speed * Time.deltaTime   );//0.6f is the movement speed

			yield return null;


		}

			


	}


	

	void animateMotion(string mot) {
		////////////////////////////////////////////////////////RESOURCE ANIMATIONS///////////////////////////////////////
		if(mot == "axe_putaway_back") {  
			toolObject.transform.localPosition = new Vector3(0.06f,0.23f,-0.55f);
			toolObject.transform.localEulerAngles = new Vector3(71,270,270);
		}

		if(mot == "axe_side_swipe")  {	
			if(toolRotation < 130) { 
				toolRotation += 2.2f; 
				toolObject.transform.RotateAround(gameObject.transform.position, Vector3.up, -toolRotation * Time.deltaTime );
			}
			else { 
				toolRotation = 0;
				toolObject.transform.localPosition = new Vector3(0.7f,0,0);
				toolObject.transform.localEulerAngles = new Vector3(0,90,0);
			}
		}
		if(mot == "pickaxe_putaway_back") {
			toolObject.transform.localPosition = new Vector3(0.06f,0.23f,-0.55f);
			toolObject.transform.localEulerAngles = new Vector3(71,270,270);
		}
		
		if(mot == "pickaxe_swing")  {	
			Debug.Log(toolRotation);

			if(toolRotation > 250 ) {
				toolRotation = 0;
				
				toolObject.transform.localPosition = new Vector3(0.5f,1.7f,0.1f);
				toolObject.transform.localEulerAngles = new Vector3(270,90,0);

			}

			if(toolRotation < 170) { 

				toolRotation += 2.5f; 
				toolObject.transform.RotateAround(gameObject.transform.position + new Vector3(0.5f,0.7f,0), Vector3.left, -toolRotation * Time.deltaTime );
			}
			if( !(toolRotation < 170) ) {
				toolRotation += 1.5f;
				toolObject.transform.RotateAround(gameObject.transform.position + new Vector3(0.5f,0.7f,0), Vector3.left, (toolRotation * Time.deltaTime) * 0.5f );

			}
		}




		//////////////////////////////////////////////////////MELEE COMBAT ANIMATIONS//////////////////////////////////////////
		if(mot == "sword_side_swipe") {
			if(toolRotation < 210) { 
				toolRotation += 3f; 
				toolObject.transform.RotateAround(gameObject.transform.position, Vector3.up, -toolRotation * Time.deltaTime );
			}
			else { 
				toolRotation = 0;
				toolObject.transform.localPosition = new Vector3(1.7f,0,0);
				toolObject.transform.localEulerAngles = new Vector3(90,90,0);
			}
		}
		if(mot == "sword_putaway_back") {
			toolObject.transform.localPosition = new Vector3(0,0.2f,-0.5f);
			toolObject.transform.localEulerAngles = new Vector3(0,180,220);
		}
	
	}



	void MoveToPoint(Vector3 point) {
		moveTowardsVector = point + new Vector3(0,1f,0);
	}



	GameObject returnNearestOfTag(string tag) {
		GameObject[] objs = GameObject.FindGameObjectsWithTag (tag);
		GameObject bestTarget = null;

		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;

		foreach(GameObject potentialTarget in objs) {

			Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;

			if(dSqrToTarget < closestDistanceSqr) {
					closestDistanceSqr = dSqrToTarget;
					bestTarget = potentialTarget;
				}
			}

		return bestTarget;
	
	
	}


	/*
		Transform GetClosestEnemy (Transform[] enemies)
		    {
		        Transform bestTarget = null;
		        float closestDistanceSqr = Mathf.Infinity;
		        Vector3 currentPosition = transform.position;
		        foreach(Transform potentialTarget in enemies)
		        {
		            Vector3 directionToTarget = potentialTarget.position - currentPosition;
		            float dSqrToTarget = directionToTarget.sqrMagnitude;
		            if(dSqrToTarget < closestDistanceSqr)
		            {
		                closestDistanceSqr = dSqrToTarget;
		                bestTarget = potentialTarget;
		            }
		        }
		     
		        return bestTarget;
		    }

	 */



	string generateNames() {
		string[] names_a_section = {"Mitch","Max","Mike","Phil","Sam","Jose","Alex","Chris","Colton","Lincoln","Richard"}; 
		string[] names_b_section = {"A","D","G","George","Jimmy","F","El","Frank","Hank","J","Phillipe","Jamal"};
		string[] names_c_section = {"Smith","Gorbachev","Carpenter","Adams","Gonzales","Martin","Lee","Mitchels","Schumaker","Glenn","Scott","Artois"};

		string a = "";
		string b = "";
		string c = "";

		float ran1 = Random.Range(0,11);
			a = names_a_section[(int)ran1];
		float ran2 = Random.Range(0,11);
			b = names_b_section[(int)ran2];
		float ran3 = Random.Range(0,11);
			c = names_c_section[(int)ran3];

		return a + "_" + b + " _" + c;
	}


























}
