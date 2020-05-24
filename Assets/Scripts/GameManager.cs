using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _gmInstance;
    [HideInInspector] public static bool viewOnDesk = true;

    static public eGameState _GAME_STATE = eGameState.Desk;
    static public eGameState _LAST_SCREEN_STATE = eGameState.IDView;

    [System.Flags]
    public enum eGameState
    {
        Desk,
        IDView,
        HealthInformationView
    }



    public static GameManager GmInstance
    {
        get
        {
            if (_gmInstance == null)
                Debug.LogError("Game Manager instance is null");

            return _gmInstance;
        }
    }

    void Awake()
    {
        _gmInstance = this;
    }

    void Update()
    {
        //Debug.Log(_GAME_STATE);
    }
}
