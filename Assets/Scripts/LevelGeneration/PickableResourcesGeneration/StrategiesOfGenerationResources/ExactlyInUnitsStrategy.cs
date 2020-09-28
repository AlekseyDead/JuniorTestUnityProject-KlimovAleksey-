using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExactlyInUnitsStrategy : StrategyOfGenerationResources
{

    List<Vector3> ArrayOfAllUnits;

    //Resources can spawn only in units
    protected override Vector3[] DefinitionPositionsOfResources(int numberOfResources)
    {

        Vector3[] positionsForSpawn = new Vector3[numberOfResources];

        int numberOfUnits = CurrentSettings.width * CurrentSettings.length;

        int width = CurrentSettings.width;
        int length = CurrentSettings.length;

        Vector3 playerPosition = PlayerMoving.PlayerPosition;


        if (ArrayOfAllUnits == null)
        {
            ArrayOfAllUnits = new List<Vector3>();


            float maxX = ((float)width / 2) - 0.5f;
            float minX = maxX * -1;

            float maxZ = ((float)length / 2) - 0.5f;
            float minZ = maxZ * -1;

            for (float i = minX; i < maxX+1; i++)
            {
                for (float j = minZ; j < maxZ+1; j++)
                {
                    Vector3 position = new Vector3(i, 1, j);

                    position = LocationGenerator.instance.SpawnPoint.TransformPoint(position);

                    if (position.x == playerPosition.x && position.z == playerPosition.z)
                    {

                    }
                    else
                    {
                        ArrayOfAllUnits.Add(position);
                    }
                }
            }
        }

        RandomChoosePositionsForSpawn(ref ArrayOfAllUnits, ref positionsForSpawn);

        return positionsForSpawn;
    }



    void RandomChoosePositionsForSpawn(ref List<Vector3> arrayOfAllUnits, ref Vector3[] positionsForSpawn)
    {
        for (int i = 0; i < positionsForSpawn.Length; i++)
        {
            int randNumber = Random.Range(0, arrayOfAllUnits.Count);
            positionsForSpawn[i] = arrayOfAllUnits[randNumber];
            arrayOfAllUnits.RemoveAt(randNumber);
        }
    }

}
