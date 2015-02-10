using UnityEngine;
using UnityEditor;
using System.Collections;

public class OrthographicCameraControls : MonoBehaviour
{
	public Camera childCamera;
	private Vector3 orginalPosition = new Vector3();
	private Quaternion orginalRotation = new Quaternion();
	private float orginalSize = 0f;

	[Header("Panning")]
	[Range(0.1f, 10f)]
	public float panSensitivity = 5f;
	public float panRange = 250f;
	public Vector3 panStartCenter = new Vector3(0f, 0f, 0f);
	private bool panDragging = false;
	private Vector3 startMousePan;

	[Header("Zoom")]
	[Range(0.01f, 0.5f)]
	public float zoomSensitivity = 0.1f;
	[Range(0.01f, 0.5f)]
	public float zoomFeedback = 0.2f;
	public bool zoomLimiting = false;
	public float zoomMax = 3.5f;
	public float zoomMin = 0.5f;
	private float zoomFactor = 1f;

	[Header("Rotation")]
	private float currentAngle = 0f;
	private float targetAngle = 90f;
	private bool rotationTween = false;

	void Start()
	{
		orginalPosition = this.gameObject.transform.position;
		orginalRotation = this.gameObject.transform.rotation;
		orginalSize = childCamera.orthographicSize;
	}

	public void ResetToStartingValues()
	{
		this.gameObject.transform.position = orginalPosition;
		this.gameObject.transform.rotation = orginalRotation;
		childCamera.orthographicSize = orginalSize;
	}

	void Update()
	{
		/* Start Mouse Zoom */

		float mouseScrollDelta = Input.GetAxis("Mouse ScrollWheel");
		if (mouseScrollDelta != 0)
		{
			float currentZoom = childCamera.orthographicSize;
			zoomFactor += zoomFactor * ((zoomSensitivity) * Mathf.Sign(-mouseScrollDelta));
			if (zoomLimiting)
			{
				if (zoomFactor > zoomMax)
				{
					zoomFactor = zoomMax ;
				}
				else if (zoomFactor < zoomMin)
				{
					zoomFactor = zoomMin;
				}
			}
			childCamera.orthographicSize = orginalSize * zoomFactor;
		}
		/* End Mouse Zoom */

		/* Start Mouse Panning */
		if (Input.GetButtonDown("PanMouse"))
		{
			panDragging = true;
			startMousePan = Input.mousePosition;
		}
		else if (Input.GetButtonUp("PanMouse"))
		{
			panDragging = false;
		}

		if (panDragging)
		{
			Vector3 translation = new Vector3(0, 0, 0);
			translation = (startMousePan - Input.mousePosition) * panSensitivity * zoomFactor;
			translation *= Time.deltaTime;
			startMousePan = Input.mousePosition;
			transform.Translate(translation);
		}
		/* End Mouse Panning */

		/* Start Mouse Rotation */
		if (Input.GetButtonDown("Rotate"))
		{
			currentAngle = 0f;
			rotationTween = true;
		}
		if (rotationTween)
		{
			float rayDistance = 0f;
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			Plane basePlane = new Plane(Vector3.up, Vector3.zero);
			basePlane.Raycast(ray, out rayDistance);
			Vector3 cameraTarget = ray.GetPoint(rayDistance);
			float rotation = targetAngle * Time.deltaTime;
			currentAngle += rotation;
			if (currentAngle >= targetAngle)
			{
				rotation = targetAngle - currentAngle;
				rotationTween = false; ;
			}

			transform.RotateAround(cameraTarget, Vector3.up, rotation);

		}
		/* End Mouse Rotation */
	}
}
