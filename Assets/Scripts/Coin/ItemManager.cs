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
    public SOInt coins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        score.text = coins.ToString();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        score.text = coins.value.ToString();
    }
    /*
     private void UpdateUI()
    {
        UiInGameManager.UpdateTextCoins(coins.value.ToString());
    }
    */
}