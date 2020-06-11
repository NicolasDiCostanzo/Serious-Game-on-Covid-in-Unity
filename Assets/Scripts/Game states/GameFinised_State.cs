using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinised_State : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    private void OnEnable()
    {
        Debug.Log("in game finished state");
        if(GameManager.cure >= 100)
        {
            Debug.Log("winner");
            winPanel.SetActive(true);
        }
        else
        {
            Debug.Log("loser");
            losePanel.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (winPanel.activeInHierarchy) winPanel.SetActive(false);
        if (losePanel.activeInHierarchy) losePanel.SetActive(false);
    }
}
