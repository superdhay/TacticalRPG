using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GridControl : MonoBehaviour
{
    [SerializeField]
    private S_Grid TargetGrid;
    [SerializeField]
    private LayerMask TerrainLayer;

/////////////////////////////////////////

    //Function that will be called on each tick of the game.
    private void Update()
    {
        LaunchRay();
    }

    //Function that will cast a ray to select an object.
    public void LaunchRay()
    {
        //Cast only if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //Create ray.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Cast ray.
            if (Physics.Raycast(ray, out hit, float.MaxValue, TerrainLayer))
            {
                //Set the hit point of the ray.
                Vector2Int gridPosition = TargetGrid.GetGridPosition(hit.point);
                S_GridObject gridObject = TargetGrid.GetPlaceObject(gridPosition);

                //Verify if the hit object is null.
                if (gridObject == null)
                {
                    Debug.Log("x=" + gridPosition.x + " y=" + gridPosition.y + " is empty");
                }
                else
                {
                    Debug.Log("x=" + gridPosition.x + " y=" + gridPosition.y + gridObject.GetComponent<S_Character>().GetName());
                }
            }
        }
    }
}
