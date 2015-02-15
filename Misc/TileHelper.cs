using UnityEngine;
using System.Collections;

public class TileHelper : MonoBehaviour {

	public Material positive;
	public Material negative;
	public int colliders = 0;

	void OnTriggerExit(Collider other)
	{
		colliders--;
		if (colliders == 0)
		{
			this.renderer.material = positive;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (colliders == 0 && other.gameObject.tag == "Building")
		{
			this.renderer.material = negative;
		}
		colliders++;
	}

}
