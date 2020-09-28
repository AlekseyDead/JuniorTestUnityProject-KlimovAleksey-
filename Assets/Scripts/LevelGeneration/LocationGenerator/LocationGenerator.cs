using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[Serializable]
public struct LocationLevelSettings
{
    public int length;
    public int width;

    public int maxGold;
    public int minGold;

    public int maxCrystalls;
    public int minCrystalls;

    //Max resources in sum in level (Crystalls+Gold now). 
    public int maxResources;
}

public class LocationGenerator : MonoBehaviour
{
    public static LocationGenerator instance;


    public Transform SpawnPoint;
    public GameObject LocationPrefab;

    public static GameObject GeneratedLocation;

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

    public GameObject GenerateLocation(LocationLevelSettings currentSettings)
    {
        GeneratedLocation = Instantiate(LocationPrefab, SpawnPoint.position, SpawnPoint.rotation, SpawnPoint);
        GeneratedLocation.transform.localScale = new Vector3(currentSettings.width, 1, currentSettings.length);
        return GeneratedLocation;
    }
}
