using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to a GameObject to rotate around the target position.
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
        // Spin the object around the world origin at 20 degrees/second.
        transform.RotateAround(target.transform.position, Vector3.up, 10 * Time.deltaTime * mult);
    }
}
