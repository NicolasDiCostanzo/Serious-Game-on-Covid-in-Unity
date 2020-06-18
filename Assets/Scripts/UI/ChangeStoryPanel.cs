using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStoryPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;
    public void ButtonFct()
    {
        if (text1.IsActive())
            SwitchPanel();
        else
            GameManager.StartGame();
    }

    void SwitchPanel()
    {
        text1.enabled = false;
        text2.enabled = true;

        GameObject.Find("Button_Story").GetComponentInChildren<Text>().text = "Start game";
    }
}
