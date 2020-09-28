using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableResourcesGenerator : MonoBehaviour
{

    public GameObject GoldPrefab;
    public GameObject CrystallPrefab;

    public Transform GoldParentObject;
    public Transform CrystallParentObject;

    public static PickableResourcesGenerator instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

    }


    public void GenerateResources(LocationLevelSettings currentSettings, ConfigurationData.PickableResourcesGenerationStrategyType strategyType)
    {

        StrategyOfGenerationResources CurrentStrategy;
        if (strategyType == ConfigurationData.PickableResourcesGenerationStrategyType.ExactlyInUnits)
        {
            CurrentStrategy = new ExactlyInUnitsStrategy();
        }
        else
        {
            CurrentStrategy = new FullRandomStrategy();
        }
        CurrentStrategy.StartGenerationResources(currentSettings, GoldPrefab, CrystallPrefab, GoldParentObject, CrystallParentObject);
    }

    public static void LaunchToInstantatingResources(GameObject spawnObject, Vector3[] spawnPoints, Transform parentObject)
    {

            foreach (var spawnPoint in spawnPoints)
            {
                Instantiate(spawnObject, spawnPoint, Quaternion.identity, parentObject);
            }
        
    }



}
