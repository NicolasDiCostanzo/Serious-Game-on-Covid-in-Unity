using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBetweenCrewMemberInformation : MonoBehaviour
{
    List<GameObject> IDInformation = new List<GameObject>();
    int nbOfInformation;
    // Start is called before the first frame update
    void Start()
    {
        GameObject ID = GameObject.Find("ID");
        nbOfInformation = ID.transform.childCount;

        for (int i = 0; i < nbOfInformation; i++)
        {
            IDInformation.Add(ID.transform.GetChild(i).gameObject);
        }


    }

    // Update is called once per frame
    void Update()
    {
        IDInformation[2].GetComponent<TextMeshProUGUI>().text = "salut";

    }
}
