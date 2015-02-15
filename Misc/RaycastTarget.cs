using UnityEngine;

public static class RaycastTarget {

	public static Vector3 Cast()
	{
		return Cast(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0f));
	}

	public static Vector3 Cast(Vector3 screenPoint)
	{
		return Cast(screenPoint, Vector3.up);
	}

	public static Vector3 Cast(Vector3 screenPoint, Vector3 axis)
	{
		Ray ray = Camera.main.ScreenPointToRay(screenPoint);
		Plane basePlane = new Plane(axis, Vector3.zero);
		float rayDistance;
		if (!basePlane.Raycast(ray, out rayDistance)) {
			Debug.LogError("Nothing was hit.");
			return new Vector3(0,0,0); //We hit nothing??
		};
		return ray.GetPoint(rayDistance);
	}

}
