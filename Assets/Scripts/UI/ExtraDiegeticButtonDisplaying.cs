using UnityEngine;

public class ExtraDiegeticButtonDisplaying : MonoBehaviour
{
    [SerializeField] GameObject panelToDisplay;
    [SerializeField] GameObject raycastBlocker;


    private void OnMouseDown()
    {
        if (raycastBlocker) raycastBlocker.SetActive(true);

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
