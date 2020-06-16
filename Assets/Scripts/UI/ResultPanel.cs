using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ResultPanel : MonoBehaviour
{
    [SerializeField] Text txt;
    [SerializeField] GameObject mistakesPanel;
    [SerializeField] GameObject symptomHelp_btn;

    Result_state result_Script;
    int panelIndex = 0;
    ProgressBarManager progressBarManager_Script;
    string memoriseFirstText;

    //string[] GreenSymptoms = { "1", "3" }; //Symptomes de maladies non-contagieuses
    //string[] BlueSymptoms = { "2", "6" };  //Symptomes communs au Covid-19 ET à des maladies contagieuses autres
    //string[] RedSymptoms = { "4", "5" };   //Symptomes spécifiques au Covid-19

    public void ChangeTxt()
    {
        GameObject cureProgression_go = GameObject.Find("Cure progression");

        progressBarManager_Script = cureProgression_go.GetComponent<ProgressBarManager>();

        if (panelIndex == 0)
        {
            result_Script = GameObject.Find("Game Manager").GetComponent<Result_state>();

            memoriseFirstText = txt.text;//on mémorise le texte du premier panel pour le réafficher quand on se retrouve dans cet état plus tard dans le jeu

            progressBarManager_Script.active = false;

            txt.resizeTextForBestFit = true;

            txt.text = "We've heard back from the mission :\n\nYou sent "
                + result_Script.toMission_Covid + " people with Covid-19 and "
                + result_Script.toMission_Disease
                + " people with a communicable disease on this mission.\n" +

                "\nYou sent back " + result_Script.toEarth_Disease + " people with Covid-19 and "
                + result_Script.toEarth_Healthy + " to Earth."

                + "\nYou left aboard the station "
                + result_Script.toStation_Covid + " people with Covid-19 and "
                + result_Script.toStation_Healthy + " with a non-communicable disease.";

            cureProgression_go.GetComponent<ProgressBarManager>().enabled = false;
            cureProgression_go.GetComponent<Animator>().enabled = true;

            panelIndex++;
        }
        else if (panelIndex == 1)
        {
            if (!Result_state.mistake)
            {
                CloseThisState();
            }
            else
            {
                mistakesPanel.SetActive(true);
                symptomHelp_btn.SetActive(true);
                AllMissedPlacedMembers();
                panelIndex++;
            }
        }
        else if (panelIndex == 2)
        {
            CloseThisState();
        }
    }

    void CloseThisState()
    {
        Reinitialize();

        if (GameManager.currentLvl <= GameManager.totalLvl && GameManager.cure < 100)
        {
            GameManager._GAME_STATE = GameManager.eGameState.DeskWithoutPatient;
        }
        else
        {
            GameManager._GAME_STATE = GameManager.eGameState.GameFinished;
        }
    }

    void Reinitialize()
    {
        foreach (Transform child in mistakesPanel.transform)
        {
            Destroy(child.gameObject);
        }

        txt.text = memoriseFirstText;

        GameManager.Earth.Clear();
        GameManager.Station.Clear();
        GameManager.Mission.Clear();
        GameManager.DeactiveButton(GameObject.Find("res_Button"));
        mistakesPanel.SetActive(false);
        panelIndex = 0;
    }
    void AllMissedPlacedMembers()
    {
        foreach (MedicalInfoHolder member in GameManager.Earth)
        {
            if (member.patientAffliction.ToString() != "Covid")
            {
                CreateTextZone(member, "Earth");
            }
        }

        foreach (MedicalInfoHolder member in GameManager.Station)
        {
            if (member.patientAffliction.ToString() != "OtherCommunicableDisease")
            {
                CreateTextZone(member,"station");
            }
        }

        foreach (MedicalInfoHolder member in GameManager.Mission)
        {
            if (member.patientAffliction.ToString() != "NonCommunicableDisease")
            {
                CreateTextZone(member, "mission");
            }
        }
    }

    void CreateTextZone(MedicalInfoHolder member, string destination)
    {
        GameObject go = new GameObject("patientInfo");
        go.transform.parent = mistakesPanel.transform;
        TextMeshProUGUI description = go.AddComponent<TextMeshProUGUI>();
        description.autoSizeTextContainer = true;
        description.text = FormateMistakesDisplaying(member, destination);
        description.fontSize = 25;
    }
    string FormateMistakesDisplaying(MedicalInfoHolder member, string place)
    {
        string strToReturn = "";
        CrewMemberInfo memberInfo = member.crewMemberInfo;
        strToReturn += memberInfo.first_name.ToString() + " " + memberInfo.last_name.ToString() + " was on " + place + " but his state was:\n\n<b>" + member.patientAffliction +
            "</b>.\n\n\nHis symptoms were:\n\n";

        //if (memberInfo.symptom1 != "")
        //{
        //    strToReturn += DisplaySymptoms(memberInfo.symptom1);
        //}

        //if (memberInfo.symptom2 != "")
        //{
        //    strToReturn += DisplaySymptoms(memberInfo.symptom2);
        //}

        //if (memberInfo.symptom3 != "")
        //{
        //    strToReturn += DisplaySymptoms(memberInfo.symptom3);
        //}

        //if (memberInfo.symptom4 != "")
        //{
        //    strToReturn += DisplaySymptoms(memberInfo.symptom4);
        //}

        //if (memberInfo.symptom5 != "")
        //{
        //    strToReturn += DisplaySymptoms(memberInfo.symptom5);
        //}

        //if (memberInfo.symptom6 != "")
        //{
        //    strToReturn += DisplaySymptoms(memberInfo.symptom6);
        //}

        if (memberInfo.symptom1 != "")
        {
            strToReturn += "-" + memberInfo.symptom1 + "\n";
        }

        if (memberInfo.symptom2 != "")
        {
            strToReturn += "-" + memberInfo.symptom2 + "\n";
        }

        if (memberInfo.symptom3 != "")
        {
            strToReturn += "-" + memberInfo.symptom3 + "\n";
        }



        for (int i = 0; i < mistakesPanel.transform.childCount; i++)
        {
            string mistakesPanelTxt = mistakesPanel.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text;
            if (mistakesPanelTxt == "") mistakesPanel.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = txt.text;
        }

        return strToReturn;
    }

    //string DisplaySymptoms(string symptom)
    //{
    //    string strToReturn = "";

    //    for (int i = 0; i < GreenSymptoms.Length; i++)
    //    //{
    //    //    if (symptom == GreenSymptoms[i])
    //    //    {
    //    //        strToReturn += "<color=green>" + symptom + "</color>\n";
    //    //        break;
    //    //    }
    //    //}

    //    //for (int i = 0; i < BlueSymptoms.Length; i++)
    //    //{
    //    //    if (symptom == BlueSymptoms[i])
    //    //    {
    //    //        strToReturn += "<color=blue>" + symptom + "</color>\n";
    //    //        break;
    //    //    }
    //    //}

    //    //for (int i = 0; i < RedSymptoms.Length; i++)
    //    //{
    //    //    if (symptom == RedSymptoms[i])
    //    //    {
    //    //        strToReturn += "<color=red>" + symptom + "</color>\n";
    //    //        break;
    //    //    }
    //    //}

    //    //for (int i = 0; i < length; i++)
    //    //{

    //    //}

    //    return strToReturn;
    //}
}
