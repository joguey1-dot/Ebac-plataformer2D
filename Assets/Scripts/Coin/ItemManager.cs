using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro; 

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public TextMeshProUGUI uiTextCoins; 

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        UpdateUI(); 
    }

    public void addCoins(int amount = 1)
    {
        coins += amount;
        UpdateUI(); 
    }

    private void UpdateUI()
    {
        if (uiTextCoins != null)
        {
            uiTextCoins.text = coins.ToString(); 
        }
    }
}