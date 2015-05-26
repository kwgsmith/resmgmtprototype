using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrapManager : MonoBehaviour {

	public Text junkPileNum;
	public float scrapValue;
	public int scrapTotal;

	public static int scrapAmount;

	private Text scrapText;
	private float lastUpdate, timePassed;
	private int count;
	private bool buttonPressed;

	void OnEnable()
	{
		Timer.Tick += AddScrap;

	}
	void OnDisable()
	{
		Timer.Tick += AddScrap;

	}

	// Use this for initialization
	void Start () {
		scrapAmount = 0;
		buttonPressed = false;
		scrapText = this.GetComponent<Text>();
		scrapTotal = 100 * int.Parse(junkPileNum.text);

		scrapText.text = scrapAmount + "/" + scrapTotal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CollectScrap()
	{
		if (count >= 5) {
			count = 1;
		}
		buttonPressed = true;
	}

	public void AddScrap(float currentTime)
	{

		timePassed += (currentTime - lastUpdate);

		//if collect button is pressed, for 5 seconds add 1 scrap/sec
		if (timePassed >= 1 && buttonPressed && count <= 5) {
			count++;
			scrapAmount++;
			timePassed = 0;
			scrapText.text = scrapAmount.ToString ();
		}
		if (count >= 5) {
			buttonPressed = false;
		}

		lastUpdate = currentTime;
	}

	public void RefineScrap()
	{
		MoneyManager.MakeMoney (scrapAmount * scrapValue);
		scrapAmount = 0;
		scrapText.text = scrapAmount.ToString ();

	}
}
