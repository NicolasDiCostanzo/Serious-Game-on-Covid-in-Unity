using UnityEngine;

public class DeactiveGOWhen : MonoBehaviour
{

    void Update()
    {
        if (GameManager._GAME_STATE != GameManager.eGameState.DecisionView) gameObject.SetActive(false);
    }
}
