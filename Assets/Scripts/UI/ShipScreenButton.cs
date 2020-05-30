using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipScreenButton : MonoBehaviour
{
    Renderer texture;
    Color startColor;
    [SerializeField] GameObject panelToDisplay;
    private void Start()
    {
        texture = GetComponent<Renderer>();
        startColor = texture.material.color;
    }
    private void OnMouseEnter()
    {
        texture.material.color = Color.grey;
    }

    private void OnMouseExit()
    {
        texture.material.color = startColor;
    }

    [SerializeField] GameObject raycastBlocker;

    private void OnMouseDown()
    {
        raycastBlocker.SetActive(true);
        texture.material.color = Color.black;
        panelToDisplay.SetActive(true);
    }

    private void OnMouseUp()
    {
        texture.material.color = startColor;
    }
}
