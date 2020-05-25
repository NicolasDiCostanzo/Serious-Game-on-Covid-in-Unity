using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Desk_State : MonoBehaviour
{
    Text buttonRightScreenTxt;
    Text buttonLeftScreenTxt;

    CinemachineVirtualCamera DeskCam;

    private void OnEnable()
    {
        buttonRightScreenTxt = GameObject.Find("button_crewMember_screen_view").GetComponentInChildren<Text>();
        buttonLeftScreenTxt = GameObject.Find("button_to_ship_screen").GetComponentInChildren<Text>();
        DeskCam = GameObject.Find("DeskCam").GetComponent<CinemachineVirtualCamera>();

        DeskCam.Priority = 1;
        buttonRightScreenTxt.text = "Look at crew member's information";
        buttonLeftScreenTxt.text = "Make a decision";
    }

    private void OnDisable()
    {
        DeskCam.Priority = 0;
        if(GameManager._GAME_STATE == GameManager.eGameState.ShipView) buttonRightScreenTxt.text = "Look at crew member's information";
    }
}
