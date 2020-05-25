using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class IDView_State : MonoBehaviour
{
    CinemachineVirtualCamera IDCam;
    CinemachineVirtualCamera CamOnID;

    Text buttonTxt;
    Image buttonImage;

    Text screenDisplayedButtonTxt;
    Image screenDisplayedButtonImg;

    private void OnEnable()
    {
        IDCam = GameObject.Find("IDCam").GetComponent<CinemachineVirtualCamera>();
        CamOnID = GameObject.Find("screen_ID").GetComponent<CinemachineVirtualCamera>();

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

        if (IDCam.Priority < 1)
            IDCam.Priority = 1;

        if (CamOnID.Priority < 1)
            CamOnID.Priority = 1;
    }

    private void OnDisable()
    {
        CamOnID.Priority = 0;

        if (GameManager._GAME_STATE != GameManager.eGameState.HealthInformationView)
        {
            screenDisplayedButtonTxt.enabled = false;
            screenDisplayedButtonImg.enabled = false;
            GameManager._LAST_SCREEN_STATE = GameManager.eGameState.IDView;
        }
    }
}
