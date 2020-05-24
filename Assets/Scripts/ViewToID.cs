using Cinemachine;
using UnityEngine;

public class ViewToID : MonoBehaviour
{
    CinemachineVirtualCamera DeskCam;

    void Awake()
    {
        DeskCam = GameObject.Find("DeskCam").GetComponent<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        DeskCam.Priority *= -1;
        enabled = false;

        if (GameManager._GAME_STATE == GameManager.eGameState.Desk)
        {
            GameManager._GAME_STATE = GameManager._LAST_SCREEN_STATE;
        }
        else
        {
            GameManager._LAST_SCREEN_STATE = GameManager._GAME_STATE;
            GameManager._GAME_STATE = GameManager.eGameState.Desk;
        }
    }

    public void ChangeView()
    {
        enabled = true;
    }
}
