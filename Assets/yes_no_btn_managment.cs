using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yes_no_btn_managment : MonoBehaviour
{
    [SerializeField] GameObject raycastBlocker;
    public void UndisplayPanel()
    {
        gameObject.SetActive(false);
        raycastBlocker.SetActive(false);
    }
}
