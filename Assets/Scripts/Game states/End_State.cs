using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class End_State : MonoBehaviour
{
    CinemachineVirtualCamera DeskCam;
    private void OnEnable()
    {
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
