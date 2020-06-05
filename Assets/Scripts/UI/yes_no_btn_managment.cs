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
        if (GameManager.currentPatient < GameManager.patientParent.transform.childCount)
        {
            Debug.Log("avant :" + GameManager.currentPatient);

            GameManager.currentPatient++;
            Debug.Log("currentpatient increase");
            Debug.Log("après :" + GameManager.currentPatient);
        }

        switch (transform.name)
        {
            case "Earth":
                GameManager.Earth.Add(GameManager.currentPatient_go.GetComponent<CrewMemberBehavior>());
                break;
            case "Station":
                GameManager.Station.Add(GameManager.currentPatient_go.GetComponent<CrewMemberBehavior>());
                break;
            case "Mission":
                GameManager.Mission.Add(GameManager.currentPatient_go.GetComponent<CrewMemberBehavior>());
                break;
        }
    }
}
