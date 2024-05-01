using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;
using EBAC.Core.Singleton;

public class UiInGameManager : Singleton<UiInGameManager>
{
    public TextMeshProUGUI uiTextCoins;

    public static void UpdateTextCoins(string s)
    {
        Instance.uiTextCoins.text = s;
    }
}
