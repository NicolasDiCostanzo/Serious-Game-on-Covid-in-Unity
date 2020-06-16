using TMPro;
using UnityEngine;

public class DisplayPatientMedicalInfo : MonoBehaviour
{
    TextMeshProUGUI symptom1;
    TextMeshProUGUI symptom2;
    TextMeshProUGUI symptom3;
    TextMeshProUGUI symptom4;
    TextMeshProUGUI symptom5;
    TextMeshProUGUI symptom6;

    public CrewMemberInfo currentPatientInfo;

    // Update is called once per frame
    private void OnEnable()
    {
        symptom1 = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        symptom2 = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        symptom3 = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        //symptom4 = transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
        //symptom5 = transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();
        //symptom6 = transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateInfo()
    {
        currentPatientInfo = PatientManager.currentPatient_go.GetComponent<MedicalInfoHolder>().crewMemberInfo;

        symptom1.text = currentPatientInfo.symptom1.ToString();
        symptom2.text = currentPatientInfo.symptom2.ToString();
        symptom3.text = currentPatientInfo.symptom3.ToString();
        //symptom4.text = currentPatientInfo.symptom4.ToString();
        //symptom5.text = currentPatientInfo.symptom5.ToString();
        //symptom6.text = currentPatientInfo.symptom6.ToString();
    }
}
