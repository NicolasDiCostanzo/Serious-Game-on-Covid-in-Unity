using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeViewButtonTxt : MonoBehaviour
{
    Text buttonTxt;
    public void ChangeTxt()
    {
        buttonTxt = GetComponentInChildren<Text>();

        if (GameManager._GAME_STATE == GameManager.eGameState.Desk)
        {
            buttonTxt.text = "Look at crew member's information";
        }
        else if (GameManager._GAME_STATE == GameManager.eGameState.HealthInformationView || GameManager._GAME_STATE == GameManager.eGameState.IDView)
        {
            buttonTxt.text = "Go back to desk";
        }
    }
}
