using UnityEngine;

public class ExtraDiegeticButtonDisplaying : MonoBehaviour
{
    [SerializeField] private GameObject panelToDisplay  = null;
    [SerializeField] private GameObject raycastBlocker = null;


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
