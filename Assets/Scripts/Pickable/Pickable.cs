using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pickable : MonoBehaviour
{
    public virtual void ToPick()
    {

    }

    public GameObject ParentGO;
    protected void EndThisObject()
    {
        LocationLevelsSceneManager.ResourceTaked();
        Destroy(ParentGO);
    }

}
