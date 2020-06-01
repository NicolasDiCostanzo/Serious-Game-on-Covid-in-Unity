using TMPro;
using UnityEngine;

public class ProgressBarManager : MonoBehaviour
{
    [Tooltip("Int")]
    public int prctToAddToResearch;
    [SerializeField] TextMeshProUGUI txtToUpdate;
    bool active;
    bool stopAnim;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    cureProgression();
        //}

        if (GameManager._GAME_STATE == GameManager.eGameState.Result && !active) GetComponent<Animator>().enabled = true;
        Debug.Log(active);

        if (active)
        {
            if (transform.GetChild(0).localScale.y < ((float)prctToAddToResearch / 100))
            {
                if (transform.GetChild(0).localScale.y >= 1)
                {
                    transform.GetChild(0).localScale = new Vector3(transform.GetChild(0).localScale.x, 1, transform.GetChild(0).localScale.z);
                }
                else
                {
                    transform.GetChild(0).localScale = new Vector3(transform.GetChild(0).localScale.x, transform.GetChild(0).localScale.y + Time.deltaTime / 5, transform.GetChild(0).localScale.z); ;
                }

                txtToUpdate.text = Mathf.Round(transform.GetChild(0).localScale.y * 100).ToString() + "%";
            }
            else
            {
                GameManager.ActiveButton(GameObject.Find("res_Button"));
            }
        }
    }

    public void cureProgression()
    {
        active = true;
        GetComponent<Animator>().enabled = false;
    }
}
