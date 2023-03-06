using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Grid : MonoBehaviour
{
    //Dimension of the grid.
    [SerializeField]
    private int Width = 25;
    [SerializeField]
    private int Length = 25;
    [SerializeField]
    private float CellSize = 1f;

    //Object that will be ignore for playble area.
    [SerializeField]
    private LayerMask ObstacleLayer;

    //Each grid object.
    private S_Node[,] Grid;

    //Function launch at beginning at start.
    private void Start()
    {
        GenerateGrid();
    }

    //Create Grid and check passable zones.
    private void GenerateGrid()
    {
        Grid = new S_Node[Length, Width];
        CheckPassableTerrain();
    }

    //Check if the node where to go is passable or not.
    //Color in red if there is no obstacle.
    private void CheckPassableTerrain()
    {
        for (int y = 0; y < Width; y++)
        {
            for (int x = 0; x < Length; x++)
            {
                Vector3 wordlPosition = GetWorldPosition(x, y);
                bool passable = !Physics.CheckBox(wordlPosition, Vector3.one / 2 * CellSize, Quaternion.identity, ObstacleLayer);
                Grid[x, y] = new S_Node();
                Grid[x, y].SetPassable(passable);
            }
        }
    }

    //Function that draw a gizmos on the terrain (in debug mode).
    //Color.white when it is passable.
    //Color.red when it is not passable.
    private void OnDrawGizmos()
    {
        if (Grid == null) { return; }
        for (int y = 0; y < Width; y++)
        {
            for (int x = 0; x < Length; x++)
            {
                Vector3 pos = GetWorldPosition(x, y);
                Gizmos.color = Grid[x, y].GetPassable() ? Color.white : Color.red;
                Gizmos.DrawCube(pos, Vector3.one / 4);
            }
        }
    }

    /*
     * Function that returns the wolrd position of an element.
     *
     *@param x (int) : x position in the world.
     *@param y (int) : y position in the world.
     *@return (Vector3) : return a Vector3, the position of the object in the world.
    */
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(transform.position.x + (x * CellSize), 0f, transform.position.z + (y * CellSize));
    }
}
