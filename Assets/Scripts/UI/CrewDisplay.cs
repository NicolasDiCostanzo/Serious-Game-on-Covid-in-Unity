using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrewDisplay : MonoBehaviour
{
    TextMeshProUGUI text;

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = (PatientManager.currentPatient).ToString() + " / " + PatientManager.patientParent.transform.childCount + " patients";
    }
}
