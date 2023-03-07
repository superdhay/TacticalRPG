using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Character : MonoBehaviour
{
    [SerializeField]
    private string Name = "Nameless";

/////////////////////////////////////////

    public string GetName()
    {
        return Name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}
