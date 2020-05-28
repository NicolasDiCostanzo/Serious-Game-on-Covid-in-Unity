using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwitchBetweenCrewMemberInformation : MonoBehaviour
{
    List<GameObject> IDInformation = new List<GameObject>();
    CrewMemberInformation crewMemberDataScript;
    int nbOfInformation;
    int currentCM; //Numéro du membre d'équipage actuellement traîté


    void Start()
    {
        GameObject ID = GameObject.Find("ID");
        nbOfInformation = ID.transform.childCount;
        crewMemberDataScript = GetComponent<CrewMemberInformation>();
        currentCM = 0;

        for (int i = 0; i < nbOfInformation; i++)
        {
            IDInformation.Add(ID.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) currentCM++;
        //IDInformation[0].GetComponent<TextMeshProUGUI>().text = crewMemberDataScript.crewMemberIDData[currentCM].first_name;
        IDInformation[1].GetComponent<TextMeshProUGUI>().text = crewMemberDataScript.crewMemberIDData[currentCM].first_name;
        IDInformation[2].GetComponent<TextMeshProUGUI>().text = crewMemberDataScript.crewMemberIDData[currentCM].last_name;
        IDInformation[3].GetComponent<TextMeshProUGUI>().text = crewMemberDataScript.crewMemberIDData[currentCM].sex;
        IDInformation[4].GetComponent<TextMeshProUGUI>().text = crewMemberDataScript.crewMemberIDData[currentCM].birth_date;
        IDInformation[5].GetComponent<TextMeshProUGUI>().text = crewMemberDataScript.crewMemberIDData[currentCM].birth_place;
        IDInformation[6].GetComponent<TextMeshProUGUI>().text = crewMemberDataScript.crewMemberIDData[currentCM].weight.ToString();
        IDInformation[7].GetComponent<TextMeshProUGUI>().text = crewMemberDataScript.crewMemberIDData[currentCM].size.ToString();
    }
}
