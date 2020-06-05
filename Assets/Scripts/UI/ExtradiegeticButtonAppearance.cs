using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtradiegeticButtonAppearance : MonoBehaviour
{
    Renderer texture;
    Color startColor;
    TutoManager tuto_script;

    [SerializeField] Color mouseOnColor;
    [SerializeField] Color mouseDownColor;
    private void Start()
    {
        texture = GetComponent<Renderer>();
        startColor = texture.material.color;
        tuto_script = GameObject.Find("Tuto Manager").GetComponent<TutoManager>();
    }
    private void OnMouseEnter()
    {
        texture.material.color = mouseOnColor;
    }

    private void OnMouseExit()
    {
        texture.material.color = startColor;
    }

    private void OnMouseDown()
    {
        texture.material.color = mouseDownColor;
    }

    private void OnMouseUp()
    {
        texture.material.color = startColor;
    }
}
