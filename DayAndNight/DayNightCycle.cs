using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour
{
	public bool cycleEnabled = true;
	public float timeOfDay = 720; //In minutes, 720 == noon, Modulate this.
	public bool modulateTime = true;

	[Tooltip("Only used at runtime.")]
	public int realtimeMsPerCycle = 1000;

	private float timeSinceLastUpdate = 0;
	private float minutesPerDegree = 4; //Not realtime
	private float currentAngle = 0;
	private float minutePerSecond = 100;
	
	// Use this for initialization
	void Start()
	{
		minutePerSecond = 1440 / (realtimeMsPerCycle / 100);
	}

	// Update is called once per frame
	void Update()
	{
		if (cycleEnabled)
		{
			if (modulateTime)
			{
				timeOfDay += minutePerSecond * Time.deltaTime;
			}

			float angle = timeOfDay / minutesPerDegree;
			if (currentAngle != angle)
			{
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.left);
			}
		}
	}
}
