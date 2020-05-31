using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yes_no_btn_managment : MonoBehaviour
{
    [SerializeField] GameObject raycastBlocker;
    public void UndisplayPanel()
    {
        gameObject.SetActive(false);
        raycastBlocker.SetActive(false);
    }

    public void SendToDestination()
    {
        GameObject patientParent = GameObject.Find("Crew members");

        if (GameManager.currentPatient < patientParent.transform.childCount)
            GameManager.currentPatient++;

        switch (transform.name)
        {
            case "Earth":
                GameManager.Earth.Add(GameManager.currentPatient_go.GetComponent<CrewMemberMovement>());
                break;
            case "Station":
                GameManager.Station.Add(GameManager.currentPatient_go.GetComponent<CrewMemberMovement>());
                break;
            case "Mission":
                GameManager.Mission.Add(GameManager.currentPatient_go.GetComponent<CrewMemberMovement>());
                break;
        }
    }
}
