using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyManager : MonoBehaviour {

	public static float moneyAmount;

	public Text moneyText;
	private static bool updateMoney;

	// Use this for initialization
	void Start () {
		moneyText = this.GetComponent<Text>();
		updateMoney = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (updateMoney) {
			moneyText.text = moneyAmount.ToString();
			updateMoney = false;
		}
	}
	
	public static void MakeMoney(float moneyToAdd)
	{
		moneyAmount += moneyToAdd;
		updateMoney = true;
	}

	
	public static void SpendMoney(float moneyToSpend)
	{
		moneyAmount -= moneyToSpend;
		updateMoney = true;
	}
}
