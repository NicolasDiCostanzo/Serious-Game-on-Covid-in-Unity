using UnityEngine;

public class Open_Close_Panel : MonoBehaviour
{
    [SerializeField] GameObject panel;

    public void OpenPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
