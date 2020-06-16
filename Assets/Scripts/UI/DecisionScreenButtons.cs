using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionScreenButtons : MonoBehaviour
{
    [SerializeField] GameObject panelToDisplay;
    [SerializeField] GameObject raycastBlocker;


    private void OnMouseDown()
    {
        if(raycastBlocker) raycastBlocker.SetActive(true);

        if (panelToDisplay.activeInHierarchy)
        {
            panelToDisplay.SetActive(false);
        }
        else
        {
            panelToDisplay.SetActive(true);

        }
    }

}
