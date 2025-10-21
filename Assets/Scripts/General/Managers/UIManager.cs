using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	public Text[] Text;
	[HideInInspector]public bool optionsAfterWin;
	float delay;

	void Start()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}

	public void BeginningOfTheGame(int time)
	{
		switch(time)
		{
		case 5:
			Text[0].text = "" + (time - 2);
			break;
		case 4:
			Text[0].text = "" + (time - 2);
			break;
		case 3:
			Text[0].text = "" + (time - 2);
			break;
		case 2:
			Text[0].text = "FIGHT";
			break;
		case 0:
			Text[0].text = " ";
			break;
		}
	}

	public void WhoWon(int player)
	{
		Text[0].text = "WINNER: PLAYER " + player.ToString();

		if(delay < 5f)
			delay += Time.deltaTime;

		if(delay > 2f)
		{
			optionsAfterWin = true;
			Text[1].text = "Press     to go back to Menu";
			Text[2].text = "O";
			Text[3].text = "Press     for a rematch";
			Text[4].text = "X";
		}
	}
}
