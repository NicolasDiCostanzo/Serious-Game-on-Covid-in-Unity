using TMPro;
using UnityEngine;

public class CrewDisplay : MonoBehaviour
{
    TextMeshProUGUI text;

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(text) text.text = (PatientManager.currentPatient).ToString() + " / " + PatientManager.patientParent.transform.childCount + " patients";
    }
}
