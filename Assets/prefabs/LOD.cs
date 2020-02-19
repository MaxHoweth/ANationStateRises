/*
Simple level of detail script.
It allows for up to 2 lower level of detail.
If nothing is assigned to lod0, this game object will be assigned to lod0.
It is ok to only have 1 lower level og detail, lod2 will simply be ignored.
If Cull Mesh is checked the mesh will be culled when max distance is reached.
The lod changes between the specified distances.
*/
/*
Usage:
Create new empty gameobject and attach the script to it
put your model with it's levels of detail in the scene and attach them to the script LOD slots
attach your camera or player to the script at "scene camera" slot

*/
using UnityEngine;
using System.Collections;


public class LOD: MonoBehaviour
{
	

	public GameObject SceneCamera;
	public float CheckInterval = 1f;
	public float Dist1 = 300;

	private float distance;
	
	void  Start ()
	{
		StartCoroutine (DistanceCheck ());
	}
	
	IEnumerator DistanceCheck ()
	{
		while (true) {
			distance = Vector3.Distance (Camera.main.transform.position, transform.position);
			
			if (distance < Dist1) {
				gameObject.SetActive (true);

				
			}
			else if (distance > Dist1 ) {
				gameObject.SetActive (false);

			} 
			yield return new WaitForSeconds (CheckInterval);		
		}
		
	}
}
// Coded by Lasse Westmark
// Free to use by anyone and anything, and for anything
//modefied and Converted to c# by abdoo47