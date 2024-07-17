using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
    public int Number { get; private set; }
    public int Symbol { get; private set; }
    public bool IsDrawl { get; private set; }
    public bool IsJoker { get; private set; }

    private double Bonus;

    public double CardPrice => Number * Main.Instance.WinMultiplayer + Main.Instance.BasicWin + Bonus;

    public Card(int number, int cardSymbol, bool isDrawl, bool isJoker, double bonus) 
    {
        Number = number;
        Symbol = cardSymbol;
        IsJoker = isJoker;
        IsDrawl = isDrawl;
        Bonus = bonus;
    }
}
