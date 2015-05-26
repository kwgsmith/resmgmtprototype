using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	//This class is designed as an event system and will trigger events every second

	public delegate void Clock(float curTime);
	public static event Clock Tick;

	private float startTime;

	void Awake()
	{
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Tick != null) 
		{
			Tick(Time.time - startTime);
		}
	}
}
