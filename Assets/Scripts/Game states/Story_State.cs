using Cinemachine;
using UnityEngine;

public class Story_State : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.storyPanel.SetActive(true);
    }

    private void OnDisable()
    {
        if(GameManager.storyPanel) GameManager.storyPanel.SetActive(false);
        GameObject.Find("Main menu cam").GetComponent<CinemachineVirtualCamera>().Priority = 0;
    }
}
