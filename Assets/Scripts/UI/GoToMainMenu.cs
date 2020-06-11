using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToMainMenu : MonoBehaviour
{
    public void f_GoToMainMenu()
    {
        GameManager._GAME_STATE = GameManager.eGameState.MainMenu;
        transform.parent.gameObject.SetActive(false);
    }
}
