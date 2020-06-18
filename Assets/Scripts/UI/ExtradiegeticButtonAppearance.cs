using UnityEngine;

public class ExtradiegeticButtonAppearance : MonoBehaviour
{
    private Renderer texture;
    private Color startColor;

    [SerializeField] private Color mouseOnColor = Color.black;
    [SerializeField] private Color mouseDownColor = Color.black;
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
