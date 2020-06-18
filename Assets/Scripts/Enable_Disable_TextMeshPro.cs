using UnityEngine;

public class Enable_Disable_TextMeshPro : MonoBehaviour
{
    [SerializeField] GameObject TMPToEnableOrDisable;
    public void EnableTMPro()
    {
        TMPToEnableOrDisable.SetActive(true);
    }

    public void DisableTMPro()
    {
        TMPToEnableOrDisable.SetActive(false);
    }
}
