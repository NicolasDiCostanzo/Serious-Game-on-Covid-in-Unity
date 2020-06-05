using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Story_State : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.storyPanel.SetActive(true);
    }

    private void OnDisable()
    {
        GameManager.storyPanel.SetActive(false);
        GameObject.Find("Main menu cam").GetComponent<CinemachineVirtualCamera>().Priority = 0;
    }
}
