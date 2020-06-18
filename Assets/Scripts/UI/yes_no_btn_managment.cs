using UnityEngine;

public class yes_no_btn_managment : MonoBehaviour
{
    [SerializeField] private GameObject raycastBlocker = null;
    public void UndisplayPanel()
    {
        gameObject.SetActive(false);
        raycastBlocker.SetActive(false);
    }

    public void SendToDestination()
    {
        FindObjectOfType<SoundManager>().Play("Valider_choix");

        PatientManager.currentPatient_go.GetComponent<CrewMemberMovement>().SendBack();

        switch (transform.name)
        {
            case "Earth":
                GameManager.Earth.Add(PatientManager.currentPatient_go.GetComponent<MedicalInfoHolder>());
                break;

            case "Station":
                GameManager.Station.Add(PatientManager.currentPatient_go.GetComponent<MedicalInfoHolder>());
                break;

            case "Mission":
                GameManager.Mission.Add(PatientManager.currentPatient_go.GetComponent<MedicalInfoHolder>());
                break;
        }
    }
}
