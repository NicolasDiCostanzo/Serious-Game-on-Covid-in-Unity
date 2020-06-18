using UnityEngine;

public class Open_Close_Panel : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] bool helpBtn;


    public void OpenPanel()
    {
        if (helpBtn && !panel.activeInHierarchy) FindObjectOfType<SoundManager>().Play("Aide");
        panel.SetActive(true);
        Debug.Log("open");
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
