using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class ShipScreen_State : MonoBehaviour
{
    CinemachineVirtualCamera ShipScreenCam;
    Text buttonLeftScreenTxt;
    Text buttonRightScreenTxt;
    private void OnEnable()
    {
        ShipScreenCam =         GameObject.Find("ShipScreenCam").GetComponent<CinemachineVirtualCamera>();
        buttonLeftScreenTxt =   GameObject.Find("button_to_ship_screen").GetComponentInChildren<Text>();
        buttonRightScreenTxt =  GameObject.Find("button_crewMember_screen_view").GetComponentInChildren<Text>();
        buttonLeftScreenTxt.text =  "Go back to desk";
        buttonRightScreenTxt.text = "Look at crew member's information";
        ShipScreenCam.Priority = 1;
    }

    private void OnDisable()
    {
        ShipScreenCam.Priority = 0;
        if(buttonLeftScreenTxt) buttonLeftScreenTxt.text = "Make a decision";
    }
}
