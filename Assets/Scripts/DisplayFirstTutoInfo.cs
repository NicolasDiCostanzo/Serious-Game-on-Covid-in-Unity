using UnityEngine;

public class DisplayFirstTutoInfo : MonoBehaviour
{
    [SerializeField] GameObject crewArrow;
    [SerializeField] GameObject levelArrow;
    [SerializeField] GameObject callNewPatientArrow;
    [SerializeField] GameObject callNewPatientButton;

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
           //callPatientButton = GameObject.Find("callPatientButton");

            GameManager.ActiveButton(GameObject.Find("callPatientButton"));
            callNewPatientArrow.SetActive(true);
        }
    }
}
