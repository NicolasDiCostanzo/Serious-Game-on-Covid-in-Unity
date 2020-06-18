using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] bool sensHoraire;
    int mult = 1;

    private void Start()
    {
        if (!sensHoraire) mult = -1;
    }

    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 10 * Time.deltaTime * mult);
    }
}
