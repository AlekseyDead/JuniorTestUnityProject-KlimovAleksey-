using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ConfigurationData", menuName = "ScriptableObjects/ConfigurationData", order = 1)]
public class ConfigurationData : ScriptableObject
{
    //Influence to positions of resources
    public enum PickableResourcesGenerationStrategyType
    {
        ExactlyInUnits,
        FullRandom
    }
    public enum LocationLevelProgressionType
    {
        Consistently,
        Random
    }


    [Header("Generation Settings")]
    public LocationLevelSettings[] locationLevelSettings;
    
    public PickableResourcesGenerationStrategyType spawnResourcesStrategy;


    [Header("Progression Settings")]
    public LocationLevelProgressionType locationLevelProgressionType;

    [Header("Resources Settings")]
    public int goldValue;
    public int crystallValue;

    [Header("Level Experience Settings")]
    public int requiredForLevelExperience;
    public float changingExpCoeff;

    [Header("Player Character Settings")]

    public float speed;
    public float angularSpeed;


}
