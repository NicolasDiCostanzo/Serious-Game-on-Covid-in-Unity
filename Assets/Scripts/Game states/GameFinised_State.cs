using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinised_State : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;

    GameObject currentCrewDisplayer_txt;
    GameObject currentLevelDisplayer_txt;
    
    private void OnEnable()
    {
        GameObject.Find("crewCount").SetActive(false);
        GameObject.Find("levelCount").SetActive(false);

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
        if (winPanel.activeInHierarchy && winPanel) winPanel.SetActive(false);
        if (losePanel.activeInHierarchy && losePanel) losePanel.SetActive(false);
    }
}
