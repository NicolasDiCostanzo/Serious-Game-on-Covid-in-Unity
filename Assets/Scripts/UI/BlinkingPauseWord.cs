using TMPro;
using UnityEngine;

public class BlinkingPauseWord : MonoBehaviour
{
    [SerializeField] float blinking_frq;
    float blinking_frq_saved;
    TextMeshProUGUI pauseWord;
    private void Start()
    {
        pauseWord = GetComponent<TextMeshProUGUI>();
        blinking_frq_saved = blinking_frq;
    }
    // Update is called once per frame
    void Update()
    {
        if (blinking_frq <= 0)
        {
            if (pauseWord.enabled)
                pauseWord.enabled = false;
            else
                pauseWord.enabled = true;

            blinking_frq = blinking_frq_saved;
        }

        blinking_frq -= Time.deltaTime;
    }
}
