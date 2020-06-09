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

    public bool mistake;

    [SerializeField] GameObject ButtonToOpenResultDetails;

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

        toEarth_Covid = 0;
        toEarth_Disease = 0;
        toEarth_Healthy = 0;
        toStation_Covid = 0;
        toStation_Disease = 0;
        toStation_Healthy = 0;
        toMission_Covid = 0;
        toMission_Disease = 0;
        toMission_Healthy = 0;
        toMission_Total = 0;
    }

    void ResultCalculation()
    {
        int cureProgress = 0;

        foreach (MedicalInfoHolder patient in GameManager.Earth)
        {
            if (patient.patientAffliction.ToString() == "Covid")
            {
                toEarth_Covid++;
            }
            else if (patient.patientAffliction.ToString() == "OtherDisease")
            {
                toEarth_Disease++;
                if (!mistake) mistake = true;
            }
            else
            {
                toEarth_Healthy++;
                if (!mistake) mistake = true;
            }
        }

        foreach (MedicalInfoHolder patient in GameManager.Station)
        {
            if (patient.patientAffliction.ToString() == "Covid")
            {
                toStation_Covid++;
                if (!mistake) mistake = true;
            }
            else if (patient.patientAffliction.ToString() == "OtherDisease")
            {
                toStation_Disease++;
            }
            else
            {
                toStation_Healthy++;
                if (!mistake) mistake = true;
            }
        }

        foreach (MedicalInfoHolder patient in GameManager.Mission)
        {
            if (patient.patientAffliction.ToString() == "Covid")
            {
                toMission_Covid++;
                if (!mistake) mistake = true;
            }
            else if (patient.patientAffliction.ToString() == "OtherDisease")
            {
                toMission_Disease++;
                if (!mistake) mistake = true;
            }
            else
            {
                toMission_Healthy++;
            }
            toMission_Total++;
        }

        if (toMission_Total > 0)
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

        if (toMission_Covid > 0) //s'il y a un seul infecté par le Covid-19 envoyé en mission, alors la mission est annulée et ne fait pas avancer la recherche du remède
        {
            cureProgress = 0;
        }

        progressBar_Script.prctToAddToResearch = cureProgress;
        //Debug.Log(toEarth_Covid + " " + toEarth_Disease + " " + toEarth_Healthy + " " + toStation_Covid + " " + toStation_Disease + " " + toStation_Healthy + " " + toMission_Covid + " " + toMission_Disease + " " + toMission_Healthy);
        //Debug.Log(cureProgress);
    }


}
