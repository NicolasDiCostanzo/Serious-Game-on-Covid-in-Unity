using UnityEngine;
using UnityEngine.UI;


public class CrewMemberID
{
    public Image img;

    public string first_name;
    public string last_name;

    [Tooltip("true = homme, false = femme")]
    public string sex;

    public string birth_date;
    public string birth_place;

    public int size;
    public int weight;

    public CrewMemberID(Image _img, string _first_name, string _last_name, string _sex, string _birth_date, string _birth_place, int _size, int _weight)
    {
        _img = img;
        _first_name = first_name;
        _last_name = last_name;
        _sex = sex;
        _birth_date = birth_date;
        _birth_place = birth_place;
        _size = size;
        _weight = weight;
    }

}

