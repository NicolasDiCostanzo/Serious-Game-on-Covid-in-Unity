using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ResultPanel : MonoBehaviour
{
    [SerializeField] Text txt;
    [SerializeField] GameObject mistakesPanel;
    [SerializeField] GameObject symptomHelp_btn;

    Result_state result_Script;
    int panelIndex = 0;
    ProgressBarManager progressBarManager_Script;
    string memoriseFirstText;

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
        foreach (Transform child in mistakesPanel.transform.GetChild(0))
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
                CreateTextZone(member, "station");
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
        go.transform.parent = mistakesPanel.transform.GetChild(0);
        TextMeshProUGUI description = go.AddComponent<TextMeshProUGUI>();
        description.text = FormateMistakesDisplaying(member, destination);
        description.fontSize = 20.5f;
    }
    string FormateMistakesDisplaying(MedicalInfoHolder member, string place)
    {
        string strToReturn = "";
        CrewMemberInfo memberInfo = member.crewMemberInfo;
        strToReturn += memberInfo.first_name.ToString() + " " + memberInfo.last_name.ToString() + " was on " + place + " but his state was:\n\n<b>" + member.patientAffliction +
            "</b>.\n\n\nHis symptoms were:\n\n";

        if (memberInfo.symptom1 != "")
            strToReturn += "-" + memberInfo.symptom1 + "\n";


        if (memberInfo.symptom2 != "")
            strToReturn += "-" + memberInfo.symptom2 + "\n";


        if (memberInfo.symptom3 != "")
            strToReturn += "-" + memberInfo.symptom3 + "\n";

        for (int i = 0; i < mistakesPanel.transform.childCount; i++)
        {
            Debug.Log(mistakesPanel.transform.GetChild(0).transform.GetChild(i).name);
            string mistakesPanelTxt = mistakesPanel.transform.GetChild(0).name;

            if (mistakesPanelTxt == "")
                mistakesPanel.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text = txt.text;
        }

        return strToReturn;
    }
}
