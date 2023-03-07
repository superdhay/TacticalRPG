using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Node 
{
    private bool Passable;
    private S_GridObject GridObject;

/////////////////////////////////////////

    public bool GetPassable()
    {
        return Passable;
    }

    public void SetPassable(bool passable)
    {
        Passable = passable;
    }

    public S_GridObject GetGridObject()
    {
        return GridObject;
    }

    public void SetGridObject(S_GridObject gridObject)
    {
        GridObject = gridObject;
    }
}
