using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Main : SingletonMonoBehaviour<Main>
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
	public double WinMultiplayer => winMultiplayer;
	public double BasicWin => basicWin;

	private int brawlCount = 0;
	public int BrawlCount => brawlCount;


	[SerializeField]
	private float brawlChance = 15;
	[SerializeField]
	private float jokerChance = 5;
	[SerializeField]
	private int maxDrawlCount = 3; // set to -1 to unlimited
	[SerializeField]
	private int maxJokerCount = 3; // set to -1 to unlimited
	[SerializeField]
	private double winMultiplayer = 0.15d;
	[SerializeField]
	private double basicWin = 1d;
	[SerializeField]
	private double brawlBonus = 25d;

	public List<Card> Roll() 
	{
		if (curentCash - rollCost < 0) 
		{
			// U can`t roll bruhh
			return new List<Card>();
		}
		curentCash -= rollCost;

		return GenerateCards();
	}

	private List<Card> GenerateCards()
	{
		List<Card> cards = new List<Card>();
		var jokerCount = 0;
		brawlCount = 0;

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

			bool isBrawl = !isJoker && (roll < brawlChance);// Don`t wanna to be at one time both joker and drawl

			if (maxDrawlCount != -1 && brawlCount >= maxDrawlCount)
			{
				isBrawl = false;
			}
			if (isBrawl)
				brawlCount++;

			var card = new Card(Random.Range(1, 10),
								Random.Range(0, 3),
								isBrawl,
								isJoker,
								isBrawl ? brawlCount * brawlBonus : 0);
			cards.Add(card);
		}

		curentWin = 0;
		foreach (var card in cards) 
		{
			if (brawlCount >= 3 && card.IsDrawl) 
			{
				curentWin += card.CardPrice;
			} else if (card.IsJoker) // Card can`t be joker and straif at same time
			{
				curentWin += card.CardPrice;
			}
		}

		curentCash += curentWin;

		return cards;
	}

	public void RestartGame()
	{
		curentCash = 100;
		curentWin = 0;
		brawlCount = 0;
	}
}
