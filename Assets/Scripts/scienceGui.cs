using UnityEngine;
using System.Collections;

public class scienceGui : MonoBehaviour {
	float camZoom = 1;


	bool hasAgriculture = false;
	bool hasBasicTools  = false;

	void OnGUI() {



		if(GUI.Button(new Rect(10,(Screen.height / 2)- 22.5f,120 * camZoom, 45 * camZoom),"Fire")) {

		}
		if(GUI.Button(new Rect(50,60, 120 * camZoom, 45 * camZoom),"Agriculture")) {
			
		}






		}


	void Update() {
		if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
		{
			//if(transform.position.z  > 0.5f) {
			
			camZoom -= 0.1f;
			//}
			//else{
			//move away from cameeaTarget
			
			//} 
			
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
		{
			//if(Yzoom < 80) {
			
			
			camZoom += 0.1f;
			//}
			
		}


	}


	void beginResearch() {



	}
}
