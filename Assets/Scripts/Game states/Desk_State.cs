using Cinemachine;
using UnityEngine;

public class Desk_State : MonoBehaviour
{
    GameObject buttonRightScreen;
    GameObject buttonLeftScreen;

    CinemachineVirtualCamera DeskCam;

    private void OnEnable()
    {
        buttonRightScreen = GameObject.Find("button_crewMember_screen_view");
        buttonLeftScreen = GameObject.Find("button_to_ship_screen");
        DeskCam = GameObject.Find("DeskViewCam").GetComponent<CinemachineVirtualCamera>();

        if (DeskCam.Priority < 1) DeskCam.Priority = 1;

        GameManager.ActiveButton(buttonLeftScreen);
        GameManager.ActiveButton(buttonRightScreen);

        GameManager.ChangeButtonTxt(buttonRightScreen, "Look at crew member's information");
        GameManager.ChangeButtonTxt(buttonLeftScreen, "Make a decision");
    }

    private void OnDisable()
    {
        DeskCam.Priority = 0;
        if (GameManager._GAME_STATE == GameManager.eGameState.DecisionView) GameManager.ChangeButtonTxt(buttonRightScreen, "Look at crew member's information");
    }
}
