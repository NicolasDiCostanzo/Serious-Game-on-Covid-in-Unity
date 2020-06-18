using UnityEngine;

public class TutoManager : MonoBehaviour
{
    GameManager.eGameState currentGameState;

    [HideInInspector] public bool firstTimeInDeskWithoutPatientState = true;
    [HideInInspector] public bool firstTimeInDeskWithPatientState = true;
    [HideInInspector] public bool firstTimeInIDViewStateState = true;
    [HideInInspector] public bool firstTimeBeforeDecision = true;
    [HideInInspector] public bool firstDecision = true;

    [SerializeField] private GameObject callNewPatientArrow = null;
    [SerializeField] private GameObject patientInfoArrow = null;
    [SerializeField] private GameObject switchBetweenPatientInfoArrow = null;
    [SerializeField] private GameObject makeDecisionArrow = null;
    [SerializeField] private GameObject decisionIndications = null;
    [SerializeField] private GameObject crewMemberDisplayArrow = null;
    [SerializeField] private GameObject levelDisplayArrow = null;
    //[SerializeField] private GameObject OK_button = null;

    private void Start()
    {
        callNewPatientArrow.SetActive(false);
        patientInfoArrow.SetActive(false);
        switchBetweenPatientInfoArrow.SetActive(false);
        makeDecisionArrow.SetActive(false);
        decisionIndications.SetActive(false);

        firstTimeInDeskWithoutPatientState = true;
        firstTimeInDeskWithPatientState = true;
        firstTimeInIDViewStateState = true;
        firstTimeBeforeDecision = true;
        firstDecision = true;
    }

    void Update()
    {
        currentGameState = GameManager._GAME_STATE;

        if ((currentGameState == GameManager.eGameState.DeskWithPatient) && firstTimeInDeskWithPatientState)
        {
            patientInfoArrow.SetActive(true);
        }
        else if ((currentGameState == GameManager.eGameState.IDView) && (firstTimeInIDViewStateState))
        {
            switchBetweenPatientInfoArrow.SetActive(true);
        }
        else if ((currentGameState == GameManager.eGameState.IDView || currentGameState == GameManager.eGameState.HealthInformationView) && firstTimeBeforeDecision)
        {
            makeDecisionArrow.SetActive(true);
        }
        else if ((currentGameState == GameManager.eGameState.DecisionView) && (firstDecision))
        {
            decisionIndications.SetActive(true);
            firstDecision = false;
        }

        if (crewMemberDisplayArrow.activeInHierarchy && levelDisplayArrow.activeInHierarchy && (GameManager._GAME_STATE == GameManager.eGameState.IDView || GameManager._GAME_STATE == GameManager.eGameState.DecisionView))
        {
            crewMemberDisplayArrow.SetActive(false);
            levelDisplayArrow.SetActive(false);
        }
    }

    public void DeactiveCallNewPatientArrow()
    {
        if (callNewPatientArrow.activeInHierarchy) callNewPatientArrow.SetActive(false);
        firstTimeInDeskWithoutPatientState = false;
    }

    public void DeactivePatientInfoArrow()
    {
        if (patientInfoArrow.activeInHierarchy) patientInfoArrow.SetActive(false);
        firstTimeInDeskWithPatientState = false;
    }

    public void DeactiveSwitchBetweenPatientInfoArrow()
    {
        if (switchBetweenPatientInfoArrow.activeInHierarchy) switchBetweenPatientInfoArrow.SetActive(false);
        firstTimeInIDViewStateState = false;
    }

    public void DeactiveDecisionArrow()
    {
        if (makeDecisionArrow.activeInHierarchy)
        {
            makeDecisionArrow.SetActive(false);
            firstTimeBeforeDecision = false;
        }
    }

    public void DeactiveDecisionIndications()
    {
        if (decisionIndications.activeInHierarchy)
        {
            decisionIndications.SetActive(false);
        }
    }
}
