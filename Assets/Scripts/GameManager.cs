using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager _gmInstance;
    [HideInInspector] public static bool viewOnDesk = true;

    static public eGameState _GAME_STATE;
    static public eGameState _LAST_SCREEN_STATE = eGameState.IDView;



    static public List<MedicalInfoHolder> Earth = new List<MedicalInfoHolder>();
    static public List<MedicalInfoHolder> Station = new List<MedicalInfoHolder>();
    static public List<MedicalInfoHolder> Mission = new List<MedicalInfoHolder>();

    static public GameObject patientParent;

    static public GameObject endPanel;
    static public GameObject resultPanel;
    static public GameObject storyPanel;
    static public bool tutoHasBeenShown = false;

    static public int currentLvl = 1;//niveau actuel
    static public int totalLvl;//nombre de niveaux au total
    static public int cure;

    [System.Flags]
    public enum eGameState
    {
        MainMenu,
        Story,
        DeskWithoutPatient,
        DeskWithPatient,
        IDView,
        HealthInformationView,
        DecisionView,
        End,
        Result,
        GameFinished
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

        storyPanel = GameObject.Find("StoryPanel");
        storyPanel.SetActive(false);

        totalLvl = GameObject.Find("Levels").transform.childCount;
    }

    void Update()
    {
        //Debug.Log(_GAME_STATE);
        switch (_GAME_STATE)
        {
            case eGameState.MainMenu:
                ActivateOneGameState("MainMenu_state");
                break;

            case eGameState.Story:
                ActivateOneGameState("Story_State");
                break;

            case eGameState.DeskWithoutPatient:
                ActivateOneGameState("DeskWithoutPatient_State");
                break;

            case eGameState.DeskWithPatient:
                ActivateOneGameState("Desk_State");
                break;

            case eGameState.IDView:
                ActivateOneGameState("IDView_State");
                break;

            case eGameState.HealthInformationView:
                ActivateOneGameState("MedicalDocView_State");
                break;

            case eGameState.DecisionView:
                ActivateOneGameState("ShipScreen_State");
                break;

            case eGameState.End:
                ActivateOneGameState("End_State");
                break;

            case eGameState.Result:
                ActivateOneGameState("Result_state");
                break;
            case eGameState.GameFinished:
                ActivateOneGameState("GameFinised_State");
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

            states[0].enabled = true; //states[0] correspond au Game Manager qui doit être tout le temps actif
        }
    }

    public void StartGame()
    {
        _GAME_STATE = eGameState.DeskWithoutPatient;
    }

    public void Switch_No_Patient_To_Patient()
    {
        _GAME_STATE = eGameState.DeskWithPatient;
    }

    public static void StoryState()
    {
        _GAME_STATE = eGameState.Story;
    }

    public void DetermineNewStateAfterPatient()
    {
        if (PatientManager.currentPatient < PatientManager.patientParent.transform.childCount)
        {
            _GAME_STATE = eGameState.DeskWithoutPatient;
        }
        else
        {
            Debug.Log("in");
            _GAME_STATE = eGameState.End;
        }
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
        if (_GAME_STATE != eGameState.DecisionView)
        {
            _GAME_STATE = eGameState.DecisionView;
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
