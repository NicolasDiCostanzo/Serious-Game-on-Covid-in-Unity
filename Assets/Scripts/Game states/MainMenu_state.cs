using Cinemachine;
using UnityEngine;

public class MainMenu_state : MonoBehaviour
{
    CinemachineVirtualCamera camOnMainMenu;

    private void OnEnable()
    {
        camOnMainMenu = GameObject.Find("Main menu cam").GetComponent<CinemachineVirtualCamera>();
        camOnMainMenu.Priority = 1;
        GameManager.DeactiveButton(GameObject.Find("button_crewMember_screen_view"));
        GameManager.DeactiveButton(GameObject.Find("button_to_ship_screen"));
        GameManager.DeactiveButton(GameObject.Find("callPatientButton"));
        GameManager.storyPanel.SetActive(false);

        GameManager.currentLvl = 1;
    }

    private void OnDisable()
    {
        if (GameManager._GAME_STATE != GameManager.eGameState.Story) camOnMainMenu.Priority = 0;
    }
}
