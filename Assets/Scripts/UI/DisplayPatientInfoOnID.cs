using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPatientInfoOnID : MonoBehaviour
{
    Image img;

    TextMeshProUGUI firstName;
    TextMeshProUGUI lastName;
    TextMeshProUGUI sex;
    TextMeshProUGUI birth_date;

    TextMeshProUGUI size;
    TextMeshProUGUI weight;

    public CrewMemberInfo currentPatientInfo;

    // Update is called once per frame
    private void OnEnable()
    {
        img = transform.GetChild(0).gameObject.GetComponent<Image>();

        firstName = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        lastName = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        sex = transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
        birth_date = transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();

        size = transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();
        weight = transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateInfo()
    {
        currentPatientInfo = PatientManager.currentPatient_go.GetComponent<MedicalInfoHolder>().crewMemberInfo;

        firstName.text = currentPatientInfo.first_name.ToString();
        lastName.text = currentPatientInfo.last_name.ToString();

        sex.text = currentPatientInfo.sex.ToString();
        birth_date.text = currentPatientInfo.birth_date.ToString();

        size.text = currentPatientInfo.size.ToString();
        weight.text = currentPatientInfo.weight.ToString();
    }
}
