using UnityEngine;

public class GameFinised_State : MonoBehaviour
{
    [SerializeField] GameObject winPanel = null;
    [SerializeField] GameObject losePanel = null;

    private void OnEnable()
    {
        GameObject.Find("crewCount").SetActive(false);
        GameObject.Find("levelCount").SetActive(false);

        if (GameManager.cure >= 100)
        {
            FindObjectOfType<SoundManager>().Play("Win");
            winPanel.SetActive(true);
        }
        else
        {
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
