using UnityEngine;

public class Open_Close_Panel : MonoBehaviour
{
    [SerializeField] private GameObject panel = null;
    [SerializeField] private bool helpBtn = false;


    public void OpenPanel()
    {
        if (helpBtn && !panel.activeInHierarchy) FindObjectOfType<SoundManager>().Play("Aide");
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
