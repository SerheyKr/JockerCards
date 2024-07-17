using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICard : MonoBehaviour
{
	private Card Card;

	[SerializeField]
	private GameObject backOfCard;
	[SerializeField]
	private TMP_Text cardNumber;
	[SerializeField]
	private TMP_Text cardSymbol;
	[SerializeField]
	private TMP_Text cardJoker;
	[SerializeField]
	private TMP_Text cardBrawl;
	[SerializeField]
	private TMP_Text cardPrice;

	private Dictionary<int, string> Symbols = new Dictionary<int, string>() 
	{
		{0, @"♠" },
		{1, @"♣" },
		{2, @"♥" },
		{3, @"♦" },
	};

	private void Start()
	{
		cardSymbol.gameObject.SetActive(false);
		cardNumber.gameObject.SetActive(false);
		cardJoker.gameObject.SetActive(false);
		cardBrawl.gameObject.SetActive(false);
		cardPrice.gameObject.SetActive(false);
		backOfCard.SetActive(true);
	}

	public void UpdateCard(Card card)
	{
		Card = card;

		cardNumber.text = card.Number.ToString();
		if (card.IsJoker || !Symbols.ContainsKey(card.Symbol))
			cardSymbol.text = "";
		else
			cardSymbol.text = Symbols[card.Symbol];
		cardPrice.text = $"{card.CardPrice}$";

		cardSymbol.gameObject.SetActive(true);
		cardNumber.gameObject.SetActive(true);
		cardPrice.gameObject.SetActive(true);

		cardJoker.gameObject.SetActive(card.IsJoker);
		cardBrawl.gameObject.SetActive(card.IsBrawl);
		backOfCard.SetActive(false);
	}
}
