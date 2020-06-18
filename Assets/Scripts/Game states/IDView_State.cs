using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class IDView_State : MonoBehaviour
{
    CinemachineVirtualCamera rightScreenCam;
    CinemachineVirtualCamera ID_Cam;

    Text buttonTxt;
    Image buttonImage;

    Text screenDisplayedButtonTxt;
    Image screenDisplayedButtonImg;

    private void OnEnable()
    {
        rightScreenCam = GameObject.Find("RightScreenCam").GetComponent<CinemachineVirtualCamera>();
        ID_Cam = GameObject.Find("ID_Cam").GetComponent<CinemachineVirtualCamera>();

        buttonImage = GameObject.Find("button_crewMember_screen_view").GetComponent<Image>();
        buttonTxt = GameObject.Find("button_crewMember_screen_view").GetComponentInChildren<Text>();

        screenDisplayedButtonTxt = GameObject.Find("button_change_screen").GetComponentInChildren<Text>();
        screenDisplayedButtonImg = GameObject.Find("button_change_screen").GetComponentInChildren<Image>();

        screenDisplayedButtonTxt.enabled = true;
        screenDisplayedButtonImg.enabled = true;


        buttonImage.enabled = true;
        buttonTxt.enabled = true;
        buttonTxt.text = "Go back to desk";

        screenDisplayedButtonTxt.text = "Check crew member's health information";

        rightScreenCam.Priority = 1;

        ID_Cam.Priority = 1;
    }

    private void OnDisable()
    {
        ID_Cam.Priority = 0;

        if (GameManager._GAME_STATE != GameManager.eGameState.HealthInformationView)
        {
            rightScreenCam.Priority = 0;
            if (screenDisplayedButtonTxt) screenDisplayedButtonTxt.enabled = false;
            if (screenDisplayedButtonImg) screenDisplayedButtonImg.enabled = false;
            GameManager._LAST_SCREEN_STATE = GameManager.eGameState.IDView;
        }
    }
}
