using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result_changeTxt : MonoBehaviour
{
    [SerializeField] Text txt;
    public void ChangeTxt()
    {
        txt.resizeTextForBestFit = true;
        txt.text = "We've heard back from the mission :\n\nYou sent "
            + /*var qui stockes les Covid en mission*/"x" + " people with Covid-19 and "
            + "y"/*var qui stockes les malades en mission*/
            + " people with another disease on this mission.\n" +
            "You sent " + /*var qui stockes les malades pas Covid sur terre*/"x" + " people with Covid-19 and "
            + "y\n"/*var qui stockes les healthy sur terre*/
            + "You left aboard the station "
            + /*var qui stockes les Covid a bord de la station*/"x" + " people with Covid-19 and "
            + "y"/*var qui stockes les healthy a bord de la station*/ + " healthy people.";

        GameManager.DeactiveButton(gameObject);
        GameObject.Find("Cure progression").GetComponent<ProgressBarManager>().enabled = false;
        GameObject.Find("Cure progression").GetComponent<Animator>().enabled = true;

    }
}
