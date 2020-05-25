using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MedicalDocView_State : MonoBehaviour
{
    CinemachineVirtualCamera IDCam;
    CinemachineVirtualCamera CamMedicInfo;

    Text deskViewButtonTxt;

    Text screenDisplayedButtonTxt;
    Image screenDisplayedButtonImg;

    private void OnEnable()
    {
        IDCam = GameObject.Find("IDCam").GetComponent<CinemachineVirtualCamera>();
        CamMedicInfo = GameObject.Find("screen_medical_inf").GetComponent<CinemachineVirtualCamera>();

        deskViewButtonTxt = GameObject.Find("button_crewMember_screen_view").GetComponentInChildren<Text>();
        screenDisplayedButtonTxt = GameObject.Find("button_change_screen").GetComponentInChildren<Text>();
        screenDisplayedButtonImg = GameObject.Find("button_change_screen").GetComponentInChildren<Image>();

        screenDisplayedButtonTxt.enabled = true;
        screenDisplayedButtonImg.enabled = true;

        deskViewButtonTxt.text = "Go back to desk";
        screenDisplayedButtonTxt.text = "Check crew member's ID";

        if (IDCam.Priority < 1)
            IDCam.Priority = 1;

        if (CamMedicInfo.Priority < 1)
            CamMedicInfo.Priority = 1;
    }

    private void OnDisable()
    {
        CamMedicInfo.Priority = 0;

        if (GameManager._GAME_STATE != GameManager.eGameState.IDView)
        {
            screenDisplayedButtonTxt.enabled = false;
            screenDisplayedButtonImg.enabled = false;
            GameManager._LAST_SCREEN_STATE = GameManager.eGameState.HealthInformationView;
        }
    }
}
