using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewMemberInformation : MonoBehaviour
{
   // [HideInInspector] public Array<CrewMemberID> crewMemberIDData = new List<CrewMemberID>(3);
    public CrewMemberID[] crewMemberIDData;
    int nbOfCrewMember;

    [SerializeField] Image img1;
    [SerializeField] Image img2;
    [SerializeField] Image img3;

    void Start()
    {
        nbOfCrewMember = GameObject.Find("Crew members").transform.childCount;
        crewMemberIDData = new CrewMemberID[nbOfCrewMember];

        GenData();
    }

    void GenData()
    {
        //crewMemberIDData[0].img = img1;

        for (int i = 0; i < nbOfCrewMember; i++)
        {
            crewMemberIDData[i] = new CrewMemberID(img1, "", "", "", "", "", 0, 0, "", "");
        }

        //crewMemberIDData[0].img =         img1;
        crewMemberIDData[0].first_name =    "ok c'est cool";
        crewMemberIDData[0].last_name =     "alley la";
        crewMemberIDData[0].sex =           "M";
        crewMemberIDData[0].birth_date =    "06/11/1994";
        crewMemberIDData[0].birth_place =   "Cabrespine";
        crewMemberIDData[0].weight =        70;
        crewMemberIDData[0].size =          180;

        crewMemberIDData[0].symptom1 =      "test symptome";
        crewMemberIDData[0].symptom2 =      "test symptome2";


        //crewMemberIDData[1].img =         img2;
        crewMemberIDData[1].first_name =    "bsalut";
        crewMemberIDData[1].last_name =     "bca va ?";
        crewMemberIDData[1].sex =           "F";
        crewMemberIDData[1].birth_date =    "07/11/1995";
        crewMemberIDData[1].birth_place =   "Babrespine";
        crewMemberIDData[1].weight =        72;
        crewMemberIDData[1].size =          182;

        crewMemberIDData[1].symptom1 =      "test symptome23456";
        crewMemberIDData[1].symptom2 =      "test symptome666";


        //crewMemberIDData[2].img =         img3;
        crewMemberIDData[2].first_name =    "csalut";
        crewMemberIDData[2].last_name =     "cca va ?";
        crewMemberIDData[2].sex =           "M";
        crewMemberIDData[2].birth_date =    "08/11/1956";
        crewMemberIDData[2].birth_place =   "Dabrespine";
        crewMemberIDData[2].weight =        73;
        crewMemberIDData[2].size =          183;
    }
}
