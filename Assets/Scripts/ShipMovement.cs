using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Vector3 destination1;
    //Vector3 destination2;

    float speed;

    void Start()
    {
        destination1 = GameObject.Find("ShipsArrivalPoint1").transform.position;
        //destination2 = GameObject.Find("ShipsArrivalPoint2").transform.position;

        speed = Random.Range(50, 200);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, destination1.z), speed * Time.deltaTime);
    }
}
