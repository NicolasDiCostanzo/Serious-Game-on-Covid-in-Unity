using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarManager : MonoBehaviour
{
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space)) cureProgression(.1f);
    //}

    public void cureProgression(float v)
    {
        if (transform.localScale.y + v >= 1)
        {
            transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z); ;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + v, transform.localScale.z); ;
        }
    }
}
