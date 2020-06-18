using UnityEngine;

public class DisplayFirstTutoInfo : MonoBehaviour
{
    [SerializeField] private GameObject crewArrow = null;
    [SerializeField] private GameObject levelArrow = null;
    [SerializeField] private GameObject callNewPatientArrow = null;
    //[SerializeField] private GameObject callNewPatientButton = null;

    public void DisplayArrowInfo()
    {
        if (crewArrow.activeInHierarchy)
        {
            crewArrow.SetActive(false);
            levelArrow.SetActive(true);
        }
        else if (levelArrow.activeInHierarchy)
        {
            levelArrow.SetActive(false);
            gameObject.SetActive(false);

            GameManager.ActiveButton(GameObject.Find("callPatientButton"));
            callNewPatientArrow.SetActive(true);
        }
    }
}
