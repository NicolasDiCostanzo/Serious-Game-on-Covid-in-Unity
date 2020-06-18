using UnityEngine;

public class ExtradiegeticButtonAppearance : MonoBehaviour
{
    Renderer texture;
    Color startColor;

    [SerializeField] Color mouseOnColor;
    [SerializeField] Color mouseDownColor;
    private void Start()
    {
        texture = GetComponent<Renderer>();
        startColor = texture.material.color;
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
        FindObjectOfType<SoundManager>().Play("Click_classique");
        texture.material.color = mouseDownColor;
    }

    private void OnMouseUp()
    {
        texture.material.color = startColor;
    }
}
