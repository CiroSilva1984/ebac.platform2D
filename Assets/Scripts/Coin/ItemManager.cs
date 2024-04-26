using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBAC.Core.Singleton;
using UnityEngine.UI;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    //public Text score;
    public TextMeshProUGUI score;
    public int coins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        score.text = coins.ToString();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        score.text = coins.ToString();
    }
}
