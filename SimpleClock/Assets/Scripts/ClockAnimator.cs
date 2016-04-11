using UnityEngine;
using System;
using System.Collections;

public class ClockAnimator : MonoBehaviour {

	private const float hoursToDegrees = 360f / 12f;
	private const float minutesToDegrees = 360f / 60f;
	private const float secondsToDegrees = 360f / 60f;

	public Transform hours;

	public Transform minutes;

	public Transform seconds;

	public bool analog;

	// Use this for initialization
	void Start () 
	{
	
	}

	// Update is called once per frame
	void Update () 
	{

		if (analog) 
		{
			var timeSpan = DateTime.Now.TimeOfDay;

			hours.localRotation = Quaternion.Euler (0, 0, (float)timeSpan.TotalHours * -hoursToDegrees);

			minutes.localRotation = Quaternion.Euler (0, 0, (float)timeSpan.TotalMinutes * -minutesToDegrees);

			seconds.localRotation = Quaternion.Euler (0, 0, (float)timeSpan.TotalSeconds * -secondsToDegrees);
		} 
		else 
		{
			var time = DateTime.Now;

			hours.localRotation = Quaternion.Euler (0f, 0f, time.Hour * -hoursToDegrees);

			minutes.localRotation = Quaternion.Euler (0f, 0f, time.Minute * -minutesToDegrees);

			seconds.localRotation = Quaternion.Euler (0f, 0f, time.Second * -secondsToDegrees);
		}
	}
}
