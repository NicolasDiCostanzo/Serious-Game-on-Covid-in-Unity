using Cinemachine;
using UnityEngine;

public class DeskWithoutPatient_State : MonoBehaviour
{
    [SerializeField] private GameObject callPatientButton = null;
    private GameObject buttonRightScreen = null;
    private GameObject buttonLeftScreen = null;

    private CinemachineVirtualCamera DeskCam = null;

    [SerializeField] private GameObject currentCrewDisplayer_txt = null;
    [SerializeField] private GameObject currentLevelDisplayer_txt = null;

    [SerializeField] private GameObject okButton = null;
    [SerializeField] private GameObject crewArrow = null;

    private bool firstTimeInThisState = true;

    private void OnEnable()
    {
        buttonRightScreen = GameObject.Find("button_crewMember_screen_view");
        buttonLeftScreen = GameObject.Find("button_to_ship_screen");
        DeskCam = GameObject.Find("DeskViewCam").GetComponent<CinemachineVirtualCamera>();

        if (!firstTimeInThisState) GameManager.ActiveButton(callPatientButton);

        if (DeskCam.Priority < 1) DeskCam.Priority = 1;

        GameManager.DeactiveButton(buttonRightScreen);
        GameManager.DeactiveButton(buttonLeftScreen);


        if (!currentCrewDisplayer_txt.activeInHierarchy && firstTimeInThisState) currentCrewDisplayer_txt.SetActive(true);
        if (!currentLevelDisplayer_txt.activeInHierarchy && firstTimeInThisState) currentLevelDisplayer_txt.SetActive(true);

        if (firstTimeInThisState)
        {
            okButton.SetActive(true);
            crewArrow.SetActive(true);
            firstTimeInThisState = false;
        }
    }

    private void OnDisable()
    {
        DeskCam.Priority = 0;
        if(callPatientButton) GameManager.DeactiveButton(callPatientButton);
    }
}
