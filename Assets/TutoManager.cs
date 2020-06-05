using UnityEngine;

public class TutoManager : MonoBehaviour
{
    GameManager.eGameState currentGameState;

    [HideInInspector] public bool firstTimeInDeskWithoutPatientState = true;
    [HideInInspector] public bool firstTimeInDeskWithPatientState = true;
    [HideInInspector] public bool firstTimeInIDViewStateState = true;

    [SerializeField] GameObject callNewPatientArrow;
    [SerializeField] GameObject patientInfoArrow;
    [SerializeField] GameObject switchBetweenPatientInfoArrow;

    private void Start()
    {
        callNewPatientArrow.SetActive(false);
        patientInfoArrow.SetActive(false);
        switchBetweenPatientInfoArrow.SetActive(false);

        firstTimeInDeskWithoutPatientState = true;
        firstTimeInDeskWithPatientState = true;
        firstTimeInIDViewStateState = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentGameState = GameManager._GAME_STATE;
        Debug.Log(currentGameState + "" + firstTimeInIDViewStateState);

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

    }

    public void DeactiveCallNewPatientArrow()
    {
        callNewPatientArrow.SetActive(false);
        firstTimeInDeskWithoutPatientState = false;
    }

    public void DeactivePatientInfoArrow()
    {
        patientInfoArrow.SetActive(false);
        firstTimeInDeskWithPatientState = false;
    }

    public void DeactiveSwitchBetweenPatientInfoArrow()
    {
        switchBetweenPatientInfoArrow.SetActive(false);
        firstTimeInIDViewStateState = false;
        Debug.Log(firstTimeInIDViewStateState);
    }
}
