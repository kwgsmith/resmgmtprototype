using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayNightManager : MonoBehaviour {

	public Text timeText;

	private int hours, minutes, seconds;
	private float lastUpdate, timePassed;
	private const float LENGTHOFSECOND = 0.1f;
	private bool switched;
	private string amPM;

	void Awake()
	{
		switched = false;
		amPM = "AM";
		timeText = this.GetComponent<Text>();
	}

	void OnEnable()
	{
		Timer.Tick += UpdateTime;
	}

	void OnDisable()
	{
		Timer.Tick -= UpdateTime;
	}

	public void UpdateTime(float currentTime)
	{
		//calculations done to make 12 minutes = 1 "day" of game time

		timePassed += (currentTime - lastUpdate);
	
		if (timePassed >= LENGTHOFSECOND) {
			seconds++;
			timePassed = 0;
		}

		if (seconds >= 60) 
		{
			minutes++;
			seconds = 0;
		}

		if (minutes >= 60) 
		{
			hours++;
			minutes = 0;
		}

		if (hours == 12) 
		{
			if(amPM.Equals("AM") && !switched)
			{
				amPM = "PM";
				Debug.Log(amPM);
				switched = true;
			}
			if(amPM.Equals("PM") && !switched)
			{
				amPM = "AM";
				Debug.Log(amPM);
				switched = true;
			}

		}
		else if (hours > 12) 
		{
			hours = 1;
			switched = false;
		}
		 
		timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes,seconds) + " " + amPM;

		lastUpdate = currentTime;
	}
}
