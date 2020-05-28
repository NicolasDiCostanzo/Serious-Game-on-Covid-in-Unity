using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MedicalDocView_State : MonoBehaviour
{
    CinemachineVirtualCamera rightScreenCam;
    CinemachineVirtualCamera medicalInfoCam;

    Text deskViewButtonTxt;

    Text screenDisplayedButtonTxt;
    Image screenDisplayedButtonImg;

    private void OnEnable()
    {
        rightScreenCam = GameObject.Find("RightScreenCam").GetComponent<CinemachineVirtualCamera>();
        medicalInfoCam = GameObject.Find("Medical_Info_Cam").GetComponent<CinemachineVirtualCamera>();

        deskViewButtonTxt = GameObject.Find("button_crewMember_screen_view").GetComponentInChildren<Text>();
        screenDisplayedButtonTxt = GameObject.Find("button_change_screen").GetComponentInChildren<Text>();
        screenDisplayedButtonImg = GameObject.Find("button_change_screen").GetComponentInChildren<Image>();

        screenDisplayedButtonTxt.enabled = true;
        screenDisplayedButtonImg.enabled = true;

        deskViewButtonTxt.text = "Go back to desk";
        screenDisplayedButtonTxt.text = "Check crew member's ID";

        rightScreenCam.Priority = 1;

        medicalInfoCam.Priority = 1;
    }

    private void OnDisable()
    {
        medicalInfoCam.Priority = 0;

        if (GameManager._GAME_STATE != GameManager.eGameState.IDView)
        {
            rightScreenCam.Priority = 0;
            screenDisplayedButtonTxt.enabled = false;
            screenDisplayedButtonImg.enabled = false;
            GameManager._LAST_SCREEN_STATE = GameManager.eGameState.HealthInformationView;
        }
    }
}
