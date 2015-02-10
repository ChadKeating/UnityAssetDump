using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	ClickDrag controller;

	void Start()
	{
		controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<ClickDrag>();
	}

	public void OnMouseDown() {
		controller.draggingObject = this.gameObject;
		controller.dragging = true;
	}
	public void OnMouseUp() {
		controller.dragging = false;
		controller.draggingObject = null;
	}

}
