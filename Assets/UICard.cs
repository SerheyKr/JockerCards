using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICard : MonoBehaviour
{
    private Card Card;

    [SerializeField]
    private TMP_Text cardNumber;
    [SerializeField]
    private TMP_Text cardSymbl;
    [SerializeField]
    private TMP_Text cardJoker;
    [SerializeField]
    private TMP_Text cardStraif;

    private void Start()
    {
        cardSymbl.gameObject.SetActive(false);
        cardNumber.gameObject.SetActive(false);
        cardJoker.gameObject.SetActive(false);
        cardStraif.gameObject.SetActive(false);
    }

    public void UpdateCard(Card card)
    {
        Card = card;

        cardNumber.text = card.Number.ToString();
        cardSymbl.text = card.Symbol.ToString();

        cardSymbl.gameObject.SetActive(true);
        cardNumber.gameObject.SetActive(true);

        cardJoker.gameObject.SetActive(card.IsJoker);
        cardStraif.gameObject.SetActive(card.IsStraif);
    }
}
