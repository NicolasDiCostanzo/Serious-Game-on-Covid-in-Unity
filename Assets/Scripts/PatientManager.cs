using UnityEngine;

public class PatientManager : MonoBehaviour
{
    static public int currentPatient = 0;
    static public GameObject patientParent;
    static public GameObject currentPatient_go;

    [SerializeField] GameObject id_GO;
    DisplayPatientInfoOnID displayInfo_Script;

    [SerializeField] GameObject medicInfo_GO;
    DisplayPatientMedicalInfo displayMedicalInfo_Script;

    private void Start()
    {
        displayInfo_Script = id_GO.GetComponent<DisplayPatientInfoOnID>();
        displayMedicalInfo_Script = medicInfo_GO.GetComponent<DisplayPatientMedicalInfo>();
    }

    private void Update()
    {
        patientParent = GameObject.Find("Lvl " + GameManager.currentLvl.ToString());
        currentPatient_go = patientParent.transform.GetChild(currentPatient).gameObject;

        if (GameManager._GAME_STATE == GameManager.eGameState.End) currentPatient = 0;
        //Debug.Log(currentPatient_go.name);
        //Debug.Log(currentPatient_go.GetComponent<MedicalInfoHolder>().crewMemberInfo.first_name);
    }
    public void SendBackPatient()
    {
        currentPatient_go.GetComponent<CrewMemberMovement>().SendBack();
    }

    public void CallNewPatient()
    {
        patientParent = GameObject.Find("Lvl " + GameManager.currentLvl.ToString());

        if (currentPatient < patientParent.transform.childCount)
        {
            currentPatient_go = patientParent.transform.GetChild(currentPatient).gameObject;
            currentPatient_go.GetComponent<CrewMemberMovement>().enabled = true;
            currentPatient++;
            UpdateIDInfo();
            UpdateMedicalInfo();
        }
        else
        {
            GameManager._GAME_STATE = GameManager.eGameState.End;
        }
    }

    void UpdateIDInfo()
    {
        if (!displayInfo_Script.enabled) displayInfo_Script.enabled = true;
        displayInfo_Script.currentPatientInfo = currentPatient_go.GetComponent<MedicalInfoHolder>().crewMemberInfo;
        displayInfo_Script.UpdateInfo();
    }

    void UpdateMedicalInfo()
    {
        if (!displayMedicalInfo_Script.enabled) displayMedicalInfo_Script.enabled = true;
        displayMedicalInfo_Script.currentPatientInfo = currentPatient_go.GetComponent<MedicalInfoHolder>().crewMemberInfo;
        displayMedicalInfo_Script.UpdateInfo();
    }
}
