using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager _gmInstance;
    [HideInInspector] public static bool viewOnDesk = true;

    static public eGameState _GAME_STATE;
    static public eGameState _LAST_SCREEN_STATE = eGameState.IDView;



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
        MainMenu,
        Story,
        DeskWithoutPatient,
        DeskWithPatient,
        IDView,
        HealthInformationView,
        ShipView,
        End,
        Result,
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
        _GAME_STATE = eGameState.MainMenu;

        _gmInstance = this;

        endPanel = GameObject.Find("End panel");
        endPanel.SetActive(false);

        resultPanel = GameObject.Find("ResultPanel");
        resultPanel.SetActive(false);
    }

    void Update()
    {

        // Debug.Log(_GAME_STATE);

        switch (_GAME_STATE)
        {
            case eGameState.DeskWithoutPatient:
                ActivateOneGameState("DeskWithoutPatient_State");
                break;

            case eGameState.DeskWithPatient:
                ActivateOneGameState("Desk_State");
                break;

            case eGameState.HealthInformationView:
                ActivateOneGameState("MedicalDocView_State");
                break;

            case eGameState.IDView:
                ActivateOneGameState("IDView_State");
                break;

            case eGameState.ShipView:
                ActivateOneGameState("ShipScreen_State");
                break;

            case eGameState.End:
                ActivateOneGameState("End_State");
                break;

            case eGameState.Result:
                ActivateOneGameState("Result_state");
                break;

            case eGameState.MainMenu:
                ActivateOneGameState("MainMenu_state");
                break;
        }
    }

    void ActivateOneGameState(string scriptNameToLetActive)
    {
        MonoBehaviour[] states = GetComponents<MonoBehaviour>();

        foreach (MonoBehaviour states_script in states)
        {
            string scriptName = states_script.GetType().Name;

            if (string.Compare(scriptName, scriptNameToLetActive) != 0)
            {
                states_script.enabled = false;
            }
            else
            {
                states_script.enabled = true;
            }

            states[0].enabled = true;//Correspond au Game Manager qui doit être tout le temps actif
        }
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
