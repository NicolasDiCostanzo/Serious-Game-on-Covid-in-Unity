using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainMenu_state : MonoBehaviour
{
    CinemachineVirtualCamera camOnMainMenu;
    // Start is called before the first frame update

    private void OnEnable()
    {
        camOnMainMenu = GameObject.Find("Main menu cam").GetComponent<CinemachineVirtualCamera>();
        camOnMainMenu.Priority = 1;
        GameManager.DeactiveButton(GameObject.Find("button_crewMember_screen_view"));
        GameManager.DeactiveButton(GameObject.Find("button_to_ship_screen"));
        GameManager.DeactiveButton(GameObject.Find("callPatientButton"));

    }

    private void OnDisable()
    {
        camOnMainMenu.Priority = 0;
    }
}
