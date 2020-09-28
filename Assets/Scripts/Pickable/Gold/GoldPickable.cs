using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickable : Pickable
{

    public static int GoldValue=1;
    public override void ToPick()
    {
        GoldCounter.ToChangeAmountOfGold(GoldValue);
        EndThisObject();
    }


}
