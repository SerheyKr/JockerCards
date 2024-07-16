using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
    public int Number { get; private set; }
    public int Symbol { get; private set; }
    public bool IsStraif { get; private set; }
    public bool IsJoker { get; private set; }

    public double CardPrice => Number * Main.WinMultiplayer + Main.BasicWin;

    public Card(int number, int cardSymbol, bool isStraif, bool isJoker) 
    {
        Number = number;
        Symbol = cardSymbol;
        IsJoker = isJoker;
        IsStraif = isStraif;
    }
}
