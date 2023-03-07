using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GridObject : MonoBehaviour
{
    [SerializeField]
    private S_Grid TargetGrid;

/////////////////////////////////////////

    private void Start()
    {
        Init();
    }

    //Function that initialize the grid object on the grid
    private void Init()
    {
        Vector2Int positionOnGrid = TargetGrid.GetGridPosition(transform.position);
        TargetGrid.PlaceObject(positionOnGrid, this);
    }
}
