using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationLevelGenerator : MonoBehaviour
{

    static int CurrentLocationLevel = 0;
    // Start is called before the first frame update

    public static void GenerateLocationLevel(LocationLevelSettings[] currentSettings,
        ConfigurationData.LocationLevelProgressionType locationLevelProgressionType, ConfigurationData.PickableResourcesGenerationStrategyType strategyType)
    {
        CurrentLocationLevel++;
        int numberInSettings;

        //Define strategy for define LocationLevel from level progression type
        if (locationLevelProgressionType == ConfigurationData.LocationLevelProgressionType.Consistently)
        {
            numberInSettings = DefineLocationNumberInConsistenlyType(currentSettings.Length);
        }
        else
        {
            numberInSettings = DefineLocationNumberInRandomType(currentSettings.Length);
        }

        LocationGenerator.instance.GenerateLocation(currentSettings[numberInSettings]);
        PickableResourcesGenerator.instance.GenerateResources(currentSettings[numberInSettings], strategyType);
    }


    static int DefineLocationNumberInConsistenlyType(int lengthOfSettings)
    {
        int numberInSettings;
        //If you current location level is higher than the maximum in the settings, you will go through the levels in a circle
        if (CurrentLocationLevel > lengthOfSettings)
        {
            numberInSettings = (CurrentLocationLevel-1) % lengthOfSettings;
        }
        else
        {
            numberInSettings = CurrentLocationLevel-1;
        }
        return numberInSettings;
    }

    static int DefineLocationNumberInRandomType(int lengthOfSettings)
    {
        int numberInSettings = Random.Range(0, lengthOfSettings);
        return numberInSettings;
    }

}
