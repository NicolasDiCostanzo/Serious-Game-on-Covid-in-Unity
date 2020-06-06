using UnityEngine;

public class Result_state : MonoBehaviour
{
    [HideInInspector] public int toEarth_Covid;
    [HideInInspector] public int toEarth_Disease;
    [HideInInspector] public int toEarth_Healthy;
    [HideInInspector] public int toStation_Covid;
    [HideInInspector] public int toStation_Disease;
    [HideInInspector] public int toStation_Healthy;
    [HideInInspector] public int toMission_Covid;
    [HideInInspector] public int toMission_Disease;
    [HideInInspector] public int toMission_Healthy;
    [HideInInspector] public int toMission_Total;

    [SerializeField]  GameObject ButtonToOpenResultDetails;

    ProgressBarManager progressBar_Script;
    private void OnEnable()
    {
        GameManager.resultPanel.SetActive(true);
        GameObject.Find("Cure progression").GetComponent<ProgressBarManager>().enabled = true;
        progressBar_Script = GameObject.Find("Cure progression").GetComponent<ProgressBarManager>();
        ResultCalculation();

        if (!ButtonToOpenResultDetails.activeInHierarchy) ButtonToOpenResultDetails.SetActive(true);
    }
    private void OnDisable()
    {
        GameObject.Find("Cure progression").GetComponent<ProgressBarManager>().enabled = false;
        GameManager.resultPanel.SetActive(false);

        if (ButtonToOpenResultDetails.activeInHierarchy) ButtonToOpenResultDetails.SetActive(false);


        /*result_Script.*/
        toEarth_Covid = 0;
        /*result_Script.*/
        toEarth_Disease = 0;
        /*result_Script.*/
        toEarth_Healthy = 0;
        /*result_Script.*/
        toStation_Covid = 0;
        /*result_Script.*/
        toStation_Disease = 0;
        /*result_Script.*/
        toStation_Healthy = 0;
        /*result_Script.*/
        toMission_Covid = 0;
        /*result_Script.*/
        toMission_Disease = 0;
        /*result_Script.*/
        toMission_Healthy = 0;
        /*result_Script.*/
        toMission_Total = 0;
    }

    void ResultCalculation()
    {
        int cureProgress = 0;

        foreach (CrewMemberBehavior patient in GameManager.Earth)
        {
            if (patient.patientState.ToString() == "Covid")
            {
                toEarth_Covid++;
            }
            else if (patient.patientState.ToString() == "OtherDisease")
            {
                toEarth_Disease++;
            }
            else
            {
                toEarth_Healthy++;
            }
        }

        foreach (CrewMemberBehavior patient in GameManager.Station)
        {
            if (patient.patientState.ToString() == "Covid")
            {
                toStation_Covid++;
            }
            else if (patient.patientState.ToString() == "OtherDisease")
            {
                toStation_Disease++;
            }
            else
            {
                toStation_Healthy++;
            }
        }

        foreach (CrewMemberBehavior patient in GameManager.Mission)
        {
            if (patient.patientState.ToString() == "Covid")
            {
                toMission_Covid++;
            }
            else if (patient.patientState.ToString() == "OtherDisease")
            {
                toMission_Disease++;
            }
            else
            {
                toMission_Healthy++;
            }
            toMission_Total++;
        }

        if (toMission_Healthy > 0)
        {
            if (toMission_Disease > 0)
            {
                cureProgress += toMission_Total * 7;
            }
            else
            {
                cureProgress = toMission_Healthy * 20;
            }
        }

        if (toMission_Covid > 0) //s'il y a un infecté envoyé en mission, alors la mission est annulée et ne fait pas avancer la recherche du remède
        {
            cureProgress = 0;
        }

        progressBar_Script.prctToAddToResearch = cureProgress;
        //Debug.Log(toEarth_Covid + " " + toEarth_Disease + " " + toEarth_Healthy + " " + toStation_Covid + " " + toStation_Disease + " " + toStation_Healthy + " " + toMission_Covid + " " + toMission_Disease + " " + toMission_Healthy);
        //Debug.Log(cureProgress);
    }


}
