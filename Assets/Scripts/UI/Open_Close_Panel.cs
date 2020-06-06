using System.Collections;
using System.Collections.Generic;
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
            Debug.Log(panel.name);
        
    }
}
