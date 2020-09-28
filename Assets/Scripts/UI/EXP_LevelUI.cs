using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP_LevelUI : MonoBehaviour
{
    public Text CurrentAmountExpText;
    public Text RequiredExpText;

    public Text CurrentLevelText;

    public Image FilledContent;

    void Awake()
    {
        ExpLevelCounter.OnChangeExp += ChangeAmountOfExperinece;
        ExpLevelCounter.OnIncreaseLevel += IncreaseLevel;
        LocationLevelsSceneManager.OnEndLocationLevel += UnsubscribeFromEvents;
    }


    void ChangeAmountOfExperinece(int amountOfExperience, int requiredExperience)
    {
        CurrentAmountExpText.text = amountOfExperience.ToString();
        RequiredExpText.text = requiredExperience.ToString();
        FilledContent.fillAmount = (float)amountOfExperience / requiredExperience;
    }

    void IncreaseLevel(int currentLevel)
    {
        CurrentLevelText.text = currentLevel.ToString();
    }

    void UnsubscribeFromEvents()
    {
        ExpLevelCounter.OnChangeExp -= ChangeAmountOfExperinece;
        ExpLevelCounter.OnIncreaseLevel -= IncreaseLevel;
        LocationLevelsSceneManager.OnEndLocationLevel -= UnsubscribeFromEvents;

    }
}
