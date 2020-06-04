using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionScreenButtons : MonoBehaviour
{
    [SerializeField] GameObject panelToDisplay;
    [SerializeField] GameObject raycastBlocker;


    private void OnMouseDown()
    {
        raycastBlocker.SetActive(true);
        panelToDisplay.SetActive(true);
    }

}
