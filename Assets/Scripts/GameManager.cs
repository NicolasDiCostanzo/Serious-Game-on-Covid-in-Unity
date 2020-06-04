using System.Collections.Generic;
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
    CrewMemberBehavior crewMember_Script;
    End_State endState_Script;
    Result_state resultState_Script;
    MainMenu_state mainMenuState_Script;

    static public List<CrewMemberBehavior> Earth = new List<CrewMemberBehavior>();
    static public List<CrewMemberBehavior> Station = new List<CrewMemberBehavior>();
    static public List<CrewMemberBehavior> Mission = new List<CrewMemberBehavior>();

    static public int currentPatient = 0;
    static public GameObject patientParent;

    static public GameObject endPanel;
    static public GameObject resultPanel;
    static public GameObject currentPatient_go;

    static public int currentLvl = 1;

    [System.Flags]
    public enum eGameState
    {
        DeskWithoutPatient,
        DeskWithPatient,
        IDView,
        HealthInformationView,
        ShipView,
        End,
        Result,
        MainMenu
    }

    public enum ePatientState
    {
        Covid,
        OtherDisease,
        Healthy
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
        _GAME_STATE = eGameState.DeskWithoutPatient;

        _gmInstance = this;

        deskWithoutPatient_Script = GetComponent<DeskWithoutPatient_State>();
        deskWithPatient_Script = GetComponent<Desk_State>();
        medicViewState_Script = GetComponent<MedicalDocView_State>();
        shipScreenState_Script = GetComponent<ShipScreen_State>();
        idViewState_Script = GetComponent<IDView_State>();
        endState_Script = GetComponent<End_State>();
        resultState_Script = GetComponent<Result_state>();
        mainMenuState_Script = GetComponent<MainMenu_state>();

        crewMember_Script = GameObject.Find("crew member 1").GetComponent<CrewMemberBehavior>();

        endPanel = GameObject.Find("End panel");
        endPanel.SetActive(false);

        resultPanel = GameObject.Find("ResultPanel");
        resultPanel.SetActive(false);
    }

    void Update()
    {
        //Debug.Log(_GAME_STATE);

        switch (_GAME_STATE)
        {
            case eGameState.DeskWithoutPatient:
                deskWithoutPatient_Script.enabled = true;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                endState_Script.enabled = false;
                resultState_Script.enabled = false;
                mainMenuState_Script.enabled = false;
                break;

            case eGameState.DeskWithPatient:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = true;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                endState_Script.enabled = false;
                resultState_Script.enabled = false;
                mainMenuState_Script.enabled = false;
                break;
            case eGameState.HealthInformationView:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = true;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                endState_Script.enabled = false;
                resultState_Script.enabled = false;
                mainMenuState_Script.enabled = false;
                break;

            case eGameState.IDView:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = true;
                shipScreenState_Script.enabled = false;
                endState_Script.enabled = false;
                resultState_Script.enabled = false;
                mainMenuState_Script.enabled = false;
                break;

            case eGameState.ShipView:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = true;
                endState_Script.enabled = false;
                resultState_Script.enabled = false;
                mainMenuState_Script.enabled = false;
                break;

            case eGameState.End:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                endState_Script.enabled = true;
                resultState_Script.enabled = false;
                break;

            case eGameState.Result:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                endState_Script.enabled = false;
                resultState_Script.enabled = true;
                mainMenuState_Script.enabled = false;
                break;

            case eGameState.MainMenu:
                deskWithoutPatient_Script.enabled = false;
                deskWithPatient_Script.enabled = false;
                medicViewState_Script.enabled = false;
                idViewState_Script.enabled = false;
                shipScreenState_Script.enabled = false;
                endState_Script.enabled = false;
                resultState_Script.enabled = false;
                mainMenuState_Script.enabled = true;
                break;
        }

        // Debug.Log(_GAME_STATE);
    }
    
    public static void StartGame()
    {
        _GAME_STATE = eGameState.DeskWithoutPatient;
    }

    public void Switch_No_Patient_To_Patient()
    {
        _GAME_STATE = eGameState.DeskWithPatient;
    }

    public void Switch_State_After_Patient_State()
    {
        patientParent = GameObject.Find("Lvl " + currentLvl.ToString());

        //Debug.Log(currentPatient + "/" + patientParent.transform.childCount);
        if (currentPatient + 1 < patientParent.transform.childCount)
        {
            _GAME_STATE = eGameState.DeskWithoutPatient;
        }
        else
        {
            _GAME_STATE = eGameState.End;
        }

        currentPatient_go.GetComponent<CrewMemberBehavior>().SendBack();
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

    public void Result_State()
    {
        _GAME_STATE = eGameState.Result;
    }

    public void CallNewPatient()
    {
        patientParent = GameObject.Find("Lvl " + currentLvl.ToString());
        if (currentPatient < patientParent.transform.childCount)
        {
            currentPatient_go = patientParent.transform.GetChild(currentPatient).gameObject;
            currentPatient_go.GetComponent<CrewMemberBehavior>().enabled = true;
            Debug.Log(currentPatient_go.name);
        }
        else
        {
            _GAME_STATE = eGameState.End;
        }
    }

    public void SendBackPatient()
    {
        currentPatient_go.GetComponent<CrewMemberBehavior>().SendBack();
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
