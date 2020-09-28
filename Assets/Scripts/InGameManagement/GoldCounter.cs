using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
    public delegate void ChangeGoldHandler(int goldNumber);
    public static event ChangeGoldHandler OnChangeGold;

    static int AmountOfGold;

    private void Start()
    {
        OnChangeGold?.Invoke(AmountOfGold);
    }


    public static void ToChangeAmountOfGold(int changeNumber)
    {
        AmountOfGold += changeNumber;
        OnChangeGold?.Invoke(AmountOfGold);
    }

}
