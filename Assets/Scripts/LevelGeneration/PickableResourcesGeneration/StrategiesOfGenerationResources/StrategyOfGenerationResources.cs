using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StrategyOfGenerationResources 
{
    int SumResources;
    int NumberOfGold;
    int NumberOfCrystalls;
    protected LocationLevelSettings CurrentSettings;

    public virtual void StartGenerationResources(LocationLevelSettings currentSettings, 
        GameObject goldPrefab, GameObject crystallPrefab, Transform goldParentObject, Transform crystallParentObject)
    {
        CurrentSettings = currentSettings;
        DefinitionNumberOfResources(currentSettings);
        PickableResourcesGenerator.LaunchToInstantatingResources (crystallPrefab, DefinitionPositionsOfResources(NumberOfCrystalls), crystallParentObject);
        PickableResourcesGenerator.LaunchToInstantatingResources (goldPrefab, DefinitionPositionsOfResources(NumberOfGold), goldParentObject);
    }

    protected void DefinitionNumberOfResources(LocationLevelSettings currentSettings)
    {
        //Definition Real Max resources, needed if you configurate that maxResources more than maxCrystall+maxGold or vice versa
        int realMaxResources = currentSettings.maxGold + currentSettings.maxCrystalls;

        if (realMaxResources > currentSettings.maxResources)
        {
            realMaxResources = currentSettings.maxResources;
        }

        //Definition Of Numbers Of Resources In Level
        SumResources = Random.Range(currentSettings.minCrystalls + currentSettings.minGold, realMaxResources + 1);


        int realMaxNumberOfGold = currentSettings.maxGold;

        if (realMaxNumberOfGold>=SumResources)
        {
            realMaxNumberOfGold = SumResources - currentSettings.minCrystalls;
        }
        if ((SumResources - currentSettings.minGold)>currentSettings.maxCrystalls)
        {
            currentSettings.minGold = SumResources - currentSettings.maxCrystalls + currentSettings.minGold;
        }

        NumberOfGold = Random.Range(currentSettings.minGold, realMaxNumberOfGold+1);
        NumberOfCrystalls = SumResources - NumberOfGold;
        LocationLevelsSceneManager.NumberOfRemainingResources = SumResources;
    }



    protected virtual Vector3[] DefinitionPositionsOfResources(int numberOfResources)
    {
        Vector3[] positionsForSpawn = new Vector3[numberOfResources];
        return positionsForSpawn;
        
    }

}
