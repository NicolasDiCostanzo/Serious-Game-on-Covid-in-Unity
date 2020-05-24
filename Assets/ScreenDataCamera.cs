using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenDataCamera : MonoBehaviour
{
    CinemachineVirtualCamera IDCam;

    private void Start()
    {
        IDCam = GameObject.Find("screen_ID").GetComponent<CinemachineVirtualCamera>();
    }
    // Update is called once per frame
    public void UpdateScreenData()
    {
        if(GameManager._GAME_STATE == GameManager.eGameState.IDView)
        {
            IDCam.Priority = 1;
        }
        else if(GameManager._GAME_STATE == GameManager.eGameState.HealthInformationView)
        {
            IDCam.Priority = -1;
        }

        Debug.Log(IDCam.Priority);

    }
}
