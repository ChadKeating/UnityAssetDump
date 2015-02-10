using UnityEngine;
using System.Collections;

public class ClickDrag : MonoBehaviour {

	public GameObject draggingObject;
	public bool dragging;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (dragging) {
			Vector3 target = RaycastTarget.Cast(Input.mousePosition);
			draggingObject.transform.position = new Vector3(target.x, target.y, draggingObject.transform.position.z);
		}
	}
}
