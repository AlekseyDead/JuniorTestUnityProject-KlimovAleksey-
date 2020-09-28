using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRandomStrategy : StrategyOfGenerationResources
{

    //Resources can spawn absolutely randomly in Location level, even in each other
    protected override Vector3[] DefinitionPositionsOfResources(int numberOfResources)
    {
        int width = CurrentSettings.width;
        int length = CurrentSettings.length;
        Vector3[] positionsForSpawn = new Vector3[numberOfResources];

        for (int i = 0; i < numberOfResources; i++)
        {
            float maxX = ((float)width / 2) - 0.5f;
            float minX = maxX * -1;

            float maxZ = ((float)length / 2) - 0.5f;
            float minZ = maxZ * -1;
            
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            float y = 1;

            positionsForSpawn[i] = LocationGenerator.instance.SpawnPoint.TransformPoint(new Vector3(x, y, z));
        }
        return positionsForSpawn;
    }






}
