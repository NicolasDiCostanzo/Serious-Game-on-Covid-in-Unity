using UnityEngine;
using UnityEngine.UI;

public class ScreenButton : MonoBehaviour
{
    Button button;
    Text buttonTxt;

    private void Start()
    {
        button = GetComponentInChildren<Button>();
        buttonTxt = button.GetComponentInChildren<Text>();
    }

    public void ChangeTxt()
    {

        if (GameManager._GAME_STATE == GameManager.eGameState.IDView)
        {
            GameManager._GAME_STATE = GameManager.eGameState.HealthInformationView;
        }
        else if (GameManager._GAME_STATE == GameManager.eGameState.HealthInformationView)
        {
            GameManager._GAME_STATE = GameManager.eGameState.IDView;
        }

    }

    private void Update()
    {
        Debug.Log(GameManager._GAME_STATE);

        if (GameManager._GAME_STATE != GameManager.eGameState.Desk)
        {
            transform.gameObject.GetComponent<Image>().enabled = true;
            buttonTxt.enabled = true;

            if (GameManager._GAME_STATE == GameManager.eGameState.IDView)
            {
                buttonTxt.text = "See medical information";
            }
            else if (GameManager._GAME_STATE == GameManager.eGameState.HealthInformationView)
            {
                buttonTxt.text = "Look at the ID";
            }
        }
        else
        {
            transform.gameObject.GetComponent<Image>().enabled = false;
            buttonTxt.enabled = false;
        }
    }
}
