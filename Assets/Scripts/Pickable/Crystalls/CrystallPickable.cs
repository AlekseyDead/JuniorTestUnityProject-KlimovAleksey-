using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystallPickable : Pickable
{

    public static int ExpCrystallValue = 100;
    public override void ToPick()
    {
        ExpLevelCounter.ToChangeAmountOfExp(ExpCrystallValue);
        EndThisObject();
    }

   


}
