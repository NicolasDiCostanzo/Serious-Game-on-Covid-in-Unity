using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class DeskWithoutPatient_State : MonoBehaviour
{
    GameObject callPatientButton;
    GameObject buttonRightScreen;
    GameObject buttonLeftScreen;

    CinemachineVirtualCamera DeskCam;

    private void OnEnable()
    {
        callPatientButton = GameObject.Find("callPatientButton");
        buttonRightScreen = GameObject.Find("button_crewMember_screen_view");
        buttonLeftScreen = GameObject.Find("button_to_ship_screen");
        DeskCam = GameObject.Find("DeskViewCam").GetComponent<CinemachineVirtualCamera>();

        if (DeskCam.Priority < 1) DeskCam.Priority = 1;

        GameManager.ActiveButton(callPatientButton);
        GameManager.DeactiveButton(buttonRightScreen);
        GameManager.DeactiveButton(buttonLeftScreen);
    }

    private void OnDisable()
    {
        DeskCam.Priority = 0;
        if (GameManager._GAME_STATE != GameManager.eGameState.DeskWithPatient) DeskCam.Priority = 0;

        GameManager.DeactiveButton(callPatientButton);
    }
}
