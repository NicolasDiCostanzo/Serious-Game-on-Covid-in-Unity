using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result_changeTxt : MonoBehaviour
{
    [SerializeField] Text txt;
    Result_state result_Script;
    bool panel1 = true;

    public void ChangeTxt()
    {
        if (panel1)
        {
            result_Script = GameObject.Find("Game Manager").GetComponent<Result_state>();

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

            //GameManager.DeactiveButton(gameObject);
            GameObject.Find("Cure progression").GetComponent<ProgressBarManager>().enabled = false;
            GameObject.Find("Cure progression").GetComponent<Animator>().enabled = true;

            panel1 = false;
        }
        else
        {
            GameManager._GAME_STATE = GameManager.eGameState.DeskWithoutPatient;
        }


    }
}
