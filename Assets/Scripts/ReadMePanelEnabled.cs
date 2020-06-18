using UnityEngine;

public class ReadMePanelEnabled : MonoBehaviour
{
    [SerializeField] GameObject Francais;
    [SerializeField] GameObject English;
    [SerializeField] GameObject Fr_btn;
    [SerializeField] GameObject En_btn;

    private void OnEnable()
    {
        Francais.SetActive(false);
        English.SetActive(false);
        Fr_btn.SetActive(true);
        En_btn.SetActive(true);
    }
}
