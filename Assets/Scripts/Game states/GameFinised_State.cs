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
        if (GameManager.cure >= 100)
        {
            Debug.Log("winner");
            FindObjectOfType<SoundManager>().Play("Win");
            winPanel.SetActive(true);
        }
        else
        {
            Debug.Log("loser");
            FindObjectOfType<SoundManager>().Play("Lose");
            losePanel.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (winPanel)
        {
            if (winPanel.activeInHierarchy) winPanel.SetActive(false);
        }

        if (losePanel)
        {
            if (losePanel.activeInHierarchy) losePanel.SetActive(false);
        }
    }
}
