using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckerForPickable : MonoBehaviour
{
    Pickable PickableInRadiusOfChecker;

    public SphereCollider VisualizationOfCheckerSphere;

    public Button ButtonToPick;

    private void Awake()
    {
        ButtonToPick.interactable = false;
    }
    void Update()
    {
        CheckingAroundSphere();
    }

    void CheckingAroundSphere()
    {
        Collider[] cols = Physics.OverlapSphere(transform.TransformPoint(VisualizationOfCheckerSphere.center), VisualizationOfCheckerSphere.radius);
        foreach (var col in cols)
        {
            if (col.gameObject.TryGetComponent<Pickable>(out PickableInRadiusOfChecker))
            {
                ButtonToPick.interactable = true;
                break;
            }
            else
            {
                if (ButtonToPick.interactable)
                {
                    ButtonToPick.interactable = false;
                }
            }
        }
    }

    public void TakePickable()
    {
        PickableInRadiusOfChecker.ToPick();
    }


}
