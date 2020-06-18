using UnityEngine;
using UnityEngine.UI;

public class CrewMemberInformation : MonoBehaviour
{
    public CrewMemberInfo[] crewMemberIDData;
    int nbOfCrewMember;

    [SerializeField] Image img1;
    [SerializeField] Image img2;
    [SerializeField] Image img3;

    void Start()
    {
        nbOfCrewMember = GameObject.Find("Lvl 1").transform.childCount;
        crewMemberIDData = new CrewMemberInfo[nbOfCrewMember];
    }


}
