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
