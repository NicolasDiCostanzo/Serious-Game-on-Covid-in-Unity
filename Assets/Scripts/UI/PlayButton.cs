using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!GameManager.tutoHasBeenShown)
        {
            GameManager.StoryState();
        }
        else
        {
            GameManager._GAME_STATE = GameManager.eGameState.DeskWithoutPatient;
        }
    }
}
