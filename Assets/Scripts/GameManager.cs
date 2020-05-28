using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _gmInstance;
    [HideInInspector] public static bool viewOnDesk = true;

    static public eGameState _GAME_STATE = eGameState.Desk;
    static public eGameState _LAST_SCREEN_STATE = eGameState.IDView;

    Desk_State deskState_Script;
    MedicalDocView_State medicViewState_Script;
    ShipScreen_State shipScreenState_Script;
    IDView_State idViewState_Script;

    [System.Flags]
    public enum eGameState
    {
        Desk,
        IDView,
        HealthInformationView,
        ShipView
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
        _GAME_STATE = eGameState.Desk;

        deskState_Script = GetComponent<Desk_State>();
        medicViewState_Script = GetComponent<MedicalDocView_State>();
        shipScreenState_Script = GetComponent<ShipScreen_State>();
        idViewState_Script = GetComponent<IDView_State>();
    }

    void Update()
    {
        switch (_GAME_STATE)
        {
            case eGameState.Desk:
                deskState_Script.enabled = true;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                break;
            case eGameState.HealthInformationView:
                deskState_Script.enabled = false;
                medicViewState_Script.enabled = true;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                break;

            case eGameState.IDView:
                deskState_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = true;
                shipScreenState_Script.enabled = false;
                break;

            case eGameState.ShipView:
                deskState_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = true;
                break;
        }

        Debug.Log(_GAME_STATE);
    }

    public void Switch_Desk_RightScreenView()
    {
        if (_GAME_STATE == eGameState.IDView || _GAME_STATE == eGameState.HealthInformationView)
        {
            _GAME_STATE = eGameState.Desk;
        }
        else
        {
            _GAME_STATE = _LAST_SCREEN_STATE;
        }
    }

    public void Switch_ID_HealthInfo()
    {
        if (_GAME_STATE == eGameState.IDView)
        {
            _GAME_STATE = eGameState.HealthInformationView;
        }
        else
        {
            _GAME_STATE = eGameState.IDView;
        }
    }

    public void ShipView_State()
    {
        if (_GAME_STATE != eGameState.ShipView)
        {
            _GAME_STATE = eGameState.ShipView;
        }
        else
        {
            _GAME_STATE = eGameState.Desk;
        }
    }
}
