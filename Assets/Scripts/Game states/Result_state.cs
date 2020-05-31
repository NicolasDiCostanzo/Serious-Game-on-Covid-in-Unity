using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result_state : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.resultPanel.SetActive(true);

    }

    private void OnDisable()
    {
        GameManager.resultPanel.SetActive(false);
    }
}
