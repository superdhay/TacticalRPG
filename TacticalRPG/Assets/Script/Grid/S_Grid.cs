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

/////////////////////////////////////////

    //Function launch at beginning at start.
    private void Awake()
    {
        GenerateGrid();
    }

    //Create Grid and check passable zones.
    private void GenerateGrid()
    {
        Grid = new S_Node[Length, Width];
        for(int y = 0; y<Width; y++)
        {
            for (int x = 0; x < Length; x++)
            {
                Grid[x, y] = new S_Node();
            }
        }
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
     *Function that returns the wolrd position of an element.
     *
     *@param x (int) : x position in the world.
     *@param y (int) : y position in the world.
     *
     *@return (Vector3) : return a Vector3, the position of the object in the world.
    */
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(transform.position.x + (x * CellSize), 0f, transform.position.z + (y * CellSize));
    }

    /*
     *Function that returns the wolrd position of The grid.
     *
     *@param worldPosition (Vector3) : the position of the grid in the world.
     *
     *@return (Vector2Int) : return the grid position in the world.
    */
    public Vector2Int GetGridPosition(Vector3 worldPosition)
    {
        worldPosition -= transform.position;
        Vector2Int positionOnGrid = new Vector2Int((int)(worldPosition.x / CellSize), (int)(worldPosition.z / CellSize));
        return positionOnGrid;
    }

    /*
     *Function that set a character on the grid.
     *
     *@param positionOnGrid (Vector2Int) : the position of the object on the grid.
     *@param gridObject (S_GridObject) : the grid object we want to place on the grid.
    */
    public void PlaceObject(Vector2Int positionOnGrid, S_GridObject gridObject)
    {
        //Check if the position is out of the grid
        if (CheckBoundry(positionOnGrid))
        {
            Grid[positionOnGrid.x, positionOnGrid.y].SetGridObject(gridObject);
        }
        else
        {
            Debug.Log("Out boundry");
        }
    }

    /*
     *Function returns an bject placed on the grid.
     *
     *@param gridPosition (Vector2Int) : the position of the grid.
     *
     *@return (S_GridObject) : returns the selected object if not null.
    */
    public S_GridObject GetPlaceObject(Vector2Int gridPosition)
    {
        //Check if the selected position is out of the grid.
        if (CheckBoundry(gridPosition))
        {
            S_GridObject gridObject = Grid[gridPosition.x, gridPosition.y].GetGridObject();
            return gridObject;
        }
        return null;
    }

    /*
     *Function returns that check if the selected position is out of the grid.
     *
     *@param positionOnGrid (Vector2Int) : the selected position of the grid.
     *
     *@return (bool) : returns if it is out of the grid or not.
    */
    public bool CheckBoundry(Vector2Int positionOnGrid)
    {
        if(positionOnGrid.x < 0 || positionOnGrid.x >= Length)
        {
            return false;
        }
        if (positionOnGrid.y < 0 || positionOnGrid.x >= Width)
        {
            return false;
        }
        return true;
    }
}
