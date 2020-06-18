using TMPro;
using UnityEngine;

public class ProgressBarManager : MonoBehaviour
{
    public int prctToAddToResearch;
    [SerializeField] TextMeshProUGUI txtToUpdate;

    bool animIsOver;

    public bool active;//variable qui permet d'activer le centrage et le grossissement de la barre de progression du remède

    private void Update()
    {
        if (GameManager._GAME_STATE == GameManager.eGameState.Result && !active)
        {
            GetComponent<Animator>().enabled = true;
            FindObjectOfType<SoundManager>().Play("Ebulition");
        }

        if (active)
        {
            if (transform.GetChild(0).localScale.y < ((float)prctToAddToResearch / 100))
            {
                if (transform.GetChild(0).localScale.y >= 1)
                {
                    transform.GetChild(0).localScale = new Vector3(transform.GetChild(0).localScale.x, 1, transform.GetChild(0).localScale.z);
                    animIsOver = true;
                }
                else
                {
                    transform.GetChild(0).localScale = new Vector3(transform.GetChild(0).localScale.x, transform.GetChild(0).localScale.y + Time.deltaTime / 5, transform.GetChild(0).localScale.z); ;
                }

                txtToUpdate.text = Mathf.Round(transform.GetChild(0).localScale.y * 100).ToString() + "%";
            }
            else //quand l'animation qui augmente la progression du remède est terminée...
            {
                animIsOver = true;
            }

            if (animIsOver)
            {
                GameManager.ActiveButton(GameObject.Find("res_Button"));
            }
            else
            {
                GameManager.DeactiveButton(GameObject.Find("res_Button"));
            }

        }
    }

    public void cureProgression()
    {
        active = true;
        GetComponent<Animator>().enabled = false;
    }

    public void DeactiveAnim()
    {
        GetComponent<Animator>().enabled = false;
        active = false;
    }
}
