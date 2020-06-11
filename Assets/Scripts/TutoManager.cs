using UnityEngine;

public class TutoManager : MonoBehaviour
{
    GameManager.eGameState currentGameState;

    [HideInInspector] public bool firstTimeInDeskWithoutPatientState = true;
    [HideInInspector] public bool firstTimeInDeskWithPatientState = true;
    [HideInInspector] public bool firstTimeInIDViewStateState = true;
    [HideInInspector] public bool firstTimeBeforeDecision = true;
    [HideInInspector] public bool firstDecision = true;

    [SerializeField] GameObject callNewPatientArrow;
    [SerializeField] GameObject patientInfoArrow;
    [SerializeField] GameObject switchBetweenPatientInfoArrow;
    [SerializeField] GameObject makeDecisionArrow;
    [SerializeField] GameObject decisionIndications;

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

    // Update is called once per frame
    void Update()
    {
        currentGameState = GameManager._GAME_STATE;

        if ((currentGameState == GameManager.eGameState.DeskWithoutPatient) && firstTimeInDeskWithoutPatientState)
        {
            callNewPatientArrow.SetActive(true);
        }
        else if ((currentGameState == GameManager.eGameState.DeskWithoutPatient) && firstTimeInDeskWithPatientState)
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
            firstDecision = false;
        }
    }
}
