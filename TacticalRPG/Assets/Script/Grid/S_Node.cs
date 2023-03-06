using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Node 
{
    private bool Passable;

    public bool GetPassable()
    {
        return Passable;
    }

    public void SetPassable(bool passable)
    {
        Passable = passable;
    }
}
