using TMPro;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    TextMeshProUGUI text;
    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        text.text = GameManager.currentLvl.ToString() + " / " + GameManager.totalLvl + " crews";
    }
}
