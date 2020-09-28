using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public Text AmountOfGoldText;
    void Awake()
    {
        GoldCounter.OnChangeGold += ChangeAmountOfGold;
        LocationLevelsSceneManager.OnEndLocationLevel += UnsubscribeFromEvents;
    }

    void ChangeAmountOfGold(int AmountOfGold)
    {
        AmountOfGoldText.text = AmountOfGold.ToString();
    }

    void UnsubscribeFromEvents()
    {
        GoldCounter.OnChangeGold -= ChangeAmountOfGold;
        LocationLevelsSceneManager.OnEndLocationLevel -= UnsubscribeFromEvents;
    }
}
