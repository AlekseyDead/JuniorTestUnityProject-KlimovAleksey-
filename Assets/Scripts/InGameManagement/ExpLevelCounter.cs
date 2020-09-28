using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//I did not this class static cause i want, that all entities have represenation on scene, and i dont forget about this
//Maybe this is absolutely incorrect
public class ExpLevelCounter : MonoBehaviour
{

    public delegate void ChangeExpHandler(int amountOfExp, int requiredExp);
    public static event ChangeExpHandler OnChangeExp;

    public delegate void IncreaseLevelHandler(int levelNumber);
    public static event IncreaseLevelHandler OnIncreaseLevel;

    static int CurrentLevel=1;

    static int AmountOfExperience=0;

    static int RequiredForLevelExperience=1000;

    //Changing Exp Coefficient For Every NextLevel
    //For Example:
    //1 - means for each next level the same amount of experience will be required
    //1.2f - means for each next level 20% more experience will be required
    //0.8f - means for each next level 20% less experience will be required
    static float ChangingExpCoeff=1.2f;


    public static void InitializeThis(int requiredForLevelExperience,  float changingExpCoeff)
    {
        RequiredForLevelExperience = requiredForLevelExperience;
        ChangingExpCoeff = changingExpCoeff;
        int requiredForNextLevelExperience = Mathf.RoundToInt(RequiredForLevelExperience * Mathf.Pow(ChangingExpCoeff, CurrentLevel - 1));
        OnChangeExp?.Invoke(AmountOfExperience, requiredForNextLevelExperience);
        OnIncreaseLevel?.Invoke(CurrentLevel);
    }


    public static void ToChangeAmountOfExp(int changeNumber)
    {
        AmountOfExperience += changeNumber;

        int requiredForNextLevelExperience = Mathf.RoundToInt(RequiredForLevelExperience * Mathf.Pow(ChangingExpCoeff, CurrentLevel - 1));

        if (AmountOfExperience >= requiredForNextLevelExperience)
        {
            AmountOfExperience -= requiredForNextLevelExperience;
            requiredForNextLevelExperience = Mathf.RoundToInt(RequiredForLevelExperience * Mathf.Pow(ChangingExpCoeff, CurrentLevel - 1));
            IncreaseLevel();
        }

        OnChangeExp?.Invoke(AmountOfExperience, requiredForNextLevelExperience);
    }

    static void IncreaseLevel()
    {
        CurrentLevel++;
        OnIncreaseLevel?.Invoke(CurrentLevel);

    }
}
