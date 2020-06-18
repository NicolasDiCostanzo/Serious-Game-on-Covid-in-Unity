using Cinemachine;
using UnityEngine;


public class End_State : MonoBehaviour
{
    CinemachineVirtualCamera DeskCam;
    private void OnEnable()
    {
        FindObjectOfType<SoundManager>().Play("Vaisseau");

        GameManager.currentLvl++;
        PatientManager.currentPatient = 0;

        GameManager.endPanel.SetActive(true);

        DeskCam = GameObject.Find("DeskViewCam").GetComponent<CinemachineVirtualCamera>();

        if (DeskCam.Priority < 1) DeskCam.Priority = 1;

        GameManager.DeactiveButton(GameObject.Find("button_to_ship_screen"));
        GameManager.DeactiveButton(GameObject.Find("button_crewMember_screen_view"));
    }

    private void OnDisable()
    {
        GameManager.endPanel.SetActive(false);
    }
}
