using UnityEngine;
using System.Collections;

public static class RaycastTarget {

	public static Vector3 Cast()
	{
		return Cast(new Vector3(0.5f, 0.5f, 0f));
	}

	public static Vector3 Cast(Vector3 screenPoint)
	{
		Ray ray = Camera.main.ScreenPointToRay(screenPoint);
		Plane basePlane = new Plane(Vector3.back, Vector3.zero);
		float rayDistance;
		if (!basePlane.Raycast(ray, out rayDistance)) {
			Debug.LogError("Nothing was hit.");
			return new Vector3(0,0,0); //We hit nothing??
		};

		return ray.GetPoint(rayDistance);
	}

}
