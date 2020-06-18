using UnityEngine;

public class QuitApp : MonoBehaviour
{
    private void OnMouseDown()
    {
        f_QuitApp();
    }

    public void f_QuitApp()
    {
        Application.Quit();
        Debug.Log("App quit");
    }
}
