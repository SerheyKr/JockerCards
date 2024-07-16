using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Main : MonoBehaviour
{
	[SerializeField]
	private int cardsNumber = 10;
	public int CardsNumber => cardsNumber;

	[SerializeField]
	private double curentCash = 100;
	public double CurentCash => curentCash;
	[SerializeField]
	private double curentWin = 0;
	public double CurentWin => curentWin;
	[SerializeField]
	private double rollCost = 1.95d;
	public double RollCost => rollCost;
	public static double WinMultiplayer => winMultiplayer;
	public static double BasicWin => basicWin;


	[SerializeField]
	private float straifChance = 15;
	[SerializeField]
	private float jokerChance = 5;
	[SerializeField]
	private int maxStraifCount = 3; // set to -1 to unlimited
	[SerializeField]
	private int maxJokerCount = 3; // set to -1 to unlimited
	[SerializeField]
	private const double winMultiplayer = 0.15d;
	private const double basicWin = 1d;

	public List<Card> Roll() 
	{
		if (curentCash - rollCost < 0) 
		{
			// U can`t roll bruhh
			return new List<Card>();
		}
		curentCash -= rollCost;
		curentCash += curentWin;
		curentWin = 0;

		return GenerateCards();
	}

	private List<Card> GenerateCards()
	{
		List<Card> cards = new List<Card>();
		var jokerCount = 0;
		var straifCount = 0;

		for (int i = 0; i < cardsNumber; i++) 
		{
			var roll = Random.Range(0, 100f);
			bool isJoker = roll < jokerChance;

			if (maxJokerCount != -1 && jokerCount >= maxJokerCount)
			{
				isJoker = false;
			}

			if (isJoker)
				jokerCount++;

			bool isStraif = !isJoker && (roll < straifChance);// Don`t wanna to be at one time both joker and straif

			if (maxStraifCount != -1 && straifCount >= maxStraifCount)
			{
				isStraif = false;
			}
			if (isStraif)
				straifCount++;

			var card = new Card(Random.Range(1, 10),
								Random.Range(0, 3),
								isStraif,
								isJoker);
			cards.Add(card);
		}

		foreach (var card in cards) 
		{
			if (straifCount >= 3 && card.IsStraif) 
			{
                curentWin += card.CardPrice;
            } else if (card.IsJoker) // Card can`t be joker and straif at same time
			{
				curentWin += card.CardPrice;
			}
		}

		return cards;
	}
}
