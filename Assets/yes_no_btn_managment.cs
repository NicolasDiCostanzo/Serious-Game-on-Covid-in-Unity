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
        GameObject crewToAdd = GameObject.Find("Crew members").transform.GetChild(GameManager.currentPatient - 1).gameObject;
        Debug.Log(crewToAdd.name);

        switch (transform.name)
        {
            case "Earth":
                GameManager.Earth.Add(crewToAdd.GetComponent<CrewMemberMovement>());
                break;
            case "Station":
                GameManager.Station.Add(crewToAdd.GetComponent<CrewMemberMovement>());
                break;
            case "Mission":
                GameManager.Mission.Add(crewToAdd.GetComponent<CrewMemberMovement>());
                break;
        }
    }
}
