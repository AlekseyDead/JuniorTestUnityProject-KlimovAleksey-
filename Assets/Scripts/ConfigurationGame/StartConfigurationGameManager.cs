using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartConfigurationGameManager : MonoBehaviour
{


    public bool IsDownloadConfigFromJsonFile = true;
    // Start is called before the first frame update
    void Start()
    {
        StartToConfiguratingLevel();
    }


    public ConfigurationData DefaultConfiguration;
    void StartToConfiguratingLevel()
    {

        if (IsDownloadConfigFromJsonFile)
        {
            DownloadConfigFromJSON();
        }
        else
        {
            SaveConfigAsJSON(DefaultConfiguration);
        }
        ConfiguratingLocationLevel(DefaultConfiguration);

    }


    void DownloadConfigFromJSON()
    {
        string JSON = File.ReadAllText(Application.dataPath + "/ConfigurationsOfGame/JSON/DefaultConfiguration.json");
        JsonUtility.FromJsonOverwrite(JSON, DefaultConfiguration);
    }

    void SaveConfigAsJSON(ConfigurationData configurationData)
    {
        string JSON = JsonUtility.ToJson(configurationData);
        File.WriteAllText(Application.dataPath + "/ConfigurationsOfGame/JSON/DefaultConfiguration.json", JSON);
    }


    void ConfiguratingLocationLevel(ConfigurationData configurationData)
    {
        LocationLevelGenerator.GenerateLocationLevel(configurationData.locationLevelSettings,
            configurationData.locationLevelProgressionType, configurationData.spawnResourcesStrategy);

        ExpLevelCounter.InitializeThis(configurationData.requiredForLevelExperience, configurationData.changingExpCoeff);

        CrystallPickable.ExpCrystallValue = configurationData.crystallValue;

        GoldPickable.GoldValue = configurationData.goldValue;

        PlayerMoving.InitializeThis(configurationData.speed, configurationData.angularSpeed);
    }

}
