using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private GameObject cardPrefab;
	[SerializeField]
	private GameObject cardsField;
	[SerializeField]
	List<UICard> uiCards = new List<UICard>();

	[SerializeField]
	private Main main;

	[SerializeField]
	private TMP_Text totalCashText;

	[SerializeField]
	private TMP_Text brawlText;

	[SerializeField]
	private TMP_Text winText;

	[SerializeField]
	private TMP_Text costText;

	[SerializeField]
	private GameObject StartScreen;
	[SerializeField]
	private GameObject GameScreen;

	private void Start()
	{
		GenerateCards(main.CardsNumber);
		UpdateNumbers();
		StartScreen.SetActive(true);
		GameScreen.SetActive(false);
	}

	private void UpdateNumbers() 
	{
		totalCashText.text = $"Total cash: {Math.Round(main.CurentCash, 2)}";
		winText.text = $"Win: {Math.Round(main.CurentWin, 2)}";
		costText.text = $"Cost: {Math.Round(main.RollCost, 1)}";
		brawlText.text = $"Brawls: {main.BrawlCount}";

	}

	private void PlaceCards(List<Card> cards) 
	{
		if (cards.Count == 0) 
		{
			//bruh
		}

		if (cards.Count == uiCards.Count)
		{
			SetCardsValues(cards);
		}
		else 
		{
			ClearCards();
			GenerateCards(cards.Count);
			SetCardsValues(cards);
		}
	}

	private void ClearCards()
	{
		foreach (var x in uiCards) 
		{
			Destroy(x.gameObject);
		}
	}

	private void SetCardsValues(List<Card> cards)
	{
		for (int i = 0; i < cards.Count; i++)
		{
			Card card = cards[i];
			var uiCard = uiCards[i];

			uiCard.UpdateCard(card);
		}
	}

	private void GenerateCards(int count)
	{
		for (int i = 0; i < count; i++)
		{
			cardPrefab.SetActive(true);
			var uiCard = GameObject.Instantiate(cardPrefab);

			uiCard.transform.SetParent(cardsField.transform, true);

			uiCards.Add(uiCard.GetComponent<UICard>());
			cardPrefab.SetActive(false);
		}
	}

	public void Roll()
	{
		PlaceCards(main.Roll());
		UpdateNumbers();
	}

	public void StartGame() 
	{
		StartScreen.SetActive(false);
		GameScreen.SetActive(true);
	}

	public void ShowInfo()
	{
		StartScreen.SetActive(true);
		GameScreen.SetActive(false);
	}

	public void RestartGame()
	{
		main.RestartGame();
		UpdateNumbers();
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
