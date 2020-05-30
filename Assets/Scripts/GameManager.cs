using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager _gmInstance;
    [HideInInspector] public static bool viewOnDesk = true;

    static public eGameState _GAME_STATE;
    static public eGameState _LAST_SCREEN_STATE = eGameState.IDView;

    Desk_State deskWithPatient_Script;
    MedicalDocView_State medicViewState_Script;
    ShipScreen_State shipScreenState_Script;
    IDView_State idViewState_Script;
    DeskWithoutPatient_State deskWithoutPatient_Script;

    int currentPatient = 0;

    [System.Flags]
    public enum eGameState
    {
        DeskWithoutPatient,
        DeskWithPatient,
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
        _GAME_STATE = eGameState.DeskWithoutPatient;

        deskWithoutPatient_Script = GetComponent<DeskWithoutPatient_State>();
        deskWithPatient_Script = GetComponent<Desk_State>();
        medicViewState_Script = GetComponent<MedicalDocView_State>();
        shipScreenState_Script = GetComponent<ShipScreen_State>();
        idViewState_Script = GetComponent<IDView_State>();
    }

    void Update()
    {
        switch (_GAME_STATE)
        {
            case eGameState.DeskWithoutPatient:
                deskWithoutPatient_Script.enabled = true;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                break;

            case eGameState.DeskWithPatient:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = true;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                break;
            case eGameState.HealthInformationView:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = true;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                break;

            case eGameState.IDView:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = true;
                shipScreenState_Script.enabled = false;
                break;

            case eGameState.ShipView:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = true;
                break;
        }

        Debug.Log(_GAME_STATE);
    }
    public void Switch_No_Patient_To_Patient()
    {
        _GAME_STATE = eGameState.DeskWithPatient;
    }

    public void Switch_Desk_RightScreenView()
    {
        if (_GAME_STATE == eGameState.IDView || _GAME_STATE == eGameState.HealthInformationView)
        {
            _GAME_STATE = eGameState.DeskWithPatient;
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
            _GAME_STATE = eGameState.DeskWithPatient;
        }
    }

    public void CallNewPatient()
    {
        GameObject patientParent = GameObject.Find("Crew members");
        patientParent.transform.GetChild(currentPatient).GetComponent<CrewMemberMovement>().enabled = true;
    }

    public void SendBackPatient()
    {
        GameObject patientParent = GameObject.Find("Crew members");
        patientParent.transform.GetChild(currentPatient).GetComponent<CrewMemberMovement>().enabled = true;
        currentPatient++;
    }

    static public void ActiveButton(GameObject button)
    {
        button.GetComponent<Image>().enabled = true;
        button.GetComponentInChildren<Text>().enabled = true;
    }

    static public void DeactiveButton(GameObject button)
    {
        button.GetComponent<Image>().enabled = false;
        button.GetComponentInChildren<Text>().enabled = false;
    }

    static public void ChangeButtonTxt(GameObject button, string txt)
    {
        button.GetComponentInChildren<Text>().text = txt;
    }
}
