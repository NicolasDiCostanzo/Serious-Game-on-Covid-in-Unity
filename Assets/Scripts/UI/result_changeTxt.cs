using UnityEngine;
using UnityEngine.UI;

public class result_changeTxt : MonoBehaviour
{
    [SerializeField] Text txt;
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

            panelIndex = 2;
        }
        else if(panelIndex == 1)
        {
            txt.text = memoriseFirstText;

            cureProgression_go.GetComponent<ProgressBarManager>().active = false;
            cureProgression_go.GetComponent<Animator>().enabled = false;
        }
        else if(panelIndex == 2)
        {
            panelIndex = 3;
            Debug.Log("3e panel");
        } 
        else if(panelIndex == 3)
        {
            GameManager._GAME_STATE = GameManager.eGameState.DeskWithoutPatient;

        }
    }
}
