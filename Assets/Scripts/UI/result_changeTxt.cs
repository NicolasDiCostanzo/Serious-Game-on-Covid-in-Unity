using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result_changeTxt : MonoBehaviour
{
    [SerializeField] Text txt;
    Result_state result_Script;
    bool panel1 = true;//le panel1 correspond au premier texte de cet état, celui qui annonce la progression de la mission
    ProgressBarManager progressBarManager_Script;
    string memoriseFirstText;

    public void ChangeTxt()
    {
        GameObject cureProgression_go =  GameObject.Find("Cure progression");

        progressBarManager_Script = cureProgression_go.GetComponent<ProgressBarManager>();

        if (panel1)
        {
            result_Script = GameObject.Find("Game Manager").GetComponent<Result_state>();

            memoriseFirstText = txt.text;//on mémorise le texte du panel1 pour le réafficher quand on rappelle cet état

            progressBarManager_Script.active = false;

            txt.resizeTextForBestFit = true;

            txt.text = "We've heard back from the mission :\n\nYou sent "
                + result_Script.toMission_Covid + " people with Covid-19 and "
                + result_Script.toMission_Disease
                + " people with another disease on this mission.\n" +

                "\nYou sent back " + result_Script.toEarth_Disease + " people with Covid-19 and "
                + result_Script.toEarth_Healthy + " to Earth."

                + "\nYou left aboard the station "
                + result_Script.toStation_Covid + " people with Covid-19 and "
                + result_Script.toStation_Healthy + " healthy people.";

            cureProgression_go.GetComponent<ProgressBarManager>().enabled = false;
            cureProgression_go.GetComponent<Animator>().enabled = true;

            panel1 = false;
        }
        else
        {
            GameManager._GAME_STATE = GameManager.eGameState.DeskWithoutPatient;
            txt.text = memoriseFirstText;

            cureProgression_go.GetComponent<ProgressBarManager>().active = false;
            cureProgression_go.GetComponent<Animator>().enabled = false;
            panel1 = true;
        } 
    }
}
