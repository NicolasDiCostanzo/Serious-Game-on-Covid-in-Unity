using UnityEngine;

public class QuitApp : MonoBehaviour
{
    public void f_QuitApp()
    {
        Application.Quit();
        Debug.Log("App quit");
    }
}
