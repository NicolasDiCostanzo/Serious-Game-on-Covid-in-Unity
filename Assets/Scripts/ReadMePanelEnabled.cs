using UnityEngine;

public class ReadMePanelEnabled : MonoBehaviour
{
    [SerializeField] GameObject Francais = null;
    [SerializeField] GameObject English = null;
    [SerializeField] GameObject Fr_btn = null;
    [SerializeField] GameObject En_btn = null;

    private void OnEnable()
    {
        Francais.SetActive(false);
        English.SetActive(false);
        Fr_btn.SetActive(true);
        En_btn.SetActive(true);
    }
}
