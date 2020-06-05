using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_State : MonoBehaviour
{
    GameObject storyPanel;

    private void Start()
    {
        storyPanel = GameObject.Find("StoryPanel");
    }
    private void OnEnable()
    {
        storyPanel.SetActive(true);
    }

    private void OnDisable()
    {
        storyPanel.SetActive(true);
    }
}
