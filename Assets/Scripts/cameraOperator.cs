﻿using UnityEngine;
using System.Collections;

public class cameraOperator : MonoBehaviour {
	public Texture2D selectionHighlight = null;
	public static Rect selection = new Rect(0,0,0,0);
	float selectionDistance = 500;
	private Vector3 startClick = -Vector3.one;
	public GameObject guiObject;

	void Update () {
		CheckCamera();
	}
		
	private void CheckCamera() {
		if(Input.GetMouseButtonDown(0)) {   startClick = Input.mousePosition;   }
		else if (Input.GetMouseButtonUp(0)) {
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag("tree")) {
				if(obj.GetComponent<Renderer>().isVisible && Vector3.Distance(this.transform.position, obj.transform.position) < selectionDistance ) {
					Vector3 camPos = Camera.main.WorldToScreenPoint(obj.transform.position);
					camPos.y = cameraOperator.InvertMouseY(camPos.y);

					if(guiObject.GetComponent<gui>().isSelectingTrees && cameraOperator.selection.Contains(camPos)){ 
						obj.GetComponent<tree>().selected = true;  
					}
				}
			}
			startClick = -Vector3.one;

		}


		if (Input.GetMouseButton(0))
			selection = new Rect(startClick.x, InvertMouseY(startClick.y), Input.mousePosition.x - startClick.x, InvertMouseY(Input.mousePosition.y) - InvertMouseY(startClick.y));
			if(selection.width <0){
				selection.x += selection.width;
				selection.width = -selection.width;
			}
			
			if(selection.height < 0){
				selection.y += selection.height;
				selection.height = -selection.height;
			}
	}
	private void OnGUI()	{
		if(startClick != -Vector3.one) {
			GUI.color = new Color(1,1,1,0.5f);
			GUI.DrawTexture(selection,selectionHighlight);
		}

	}

	public static float InvertMouseY(float y) {
				return Screen.height - y;
			}

}