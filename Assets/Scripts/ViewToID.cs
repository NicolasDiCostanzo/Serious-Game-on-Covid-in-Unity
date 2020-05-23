using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

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
    }
}
