using UnityEngine;
using System.Collections;

public class BuildControls : MonoBehaviour {

	private GameObject block;

	// Use this for initialization
	void Start () {
		block = Resources.Load("Prefabs/Block") as GameObject;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Build")) {
			Vector3 target = RaycastTarget.Cast(Input.mousePosition);
			target += new Vector3(0f, 1f, 0f);
			Instantiate(block, RoundVector(target), Quaternion.identity);
		}
	}

	Vector3 RoundVector(Vector3 roundMe) {
		return new Vector3(Mathf.Round(roundMe.x), Mathf.Round(roundMe.y), Mathf.Round(roundMe.z));
	}
}
