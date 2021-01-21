using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{

    [SerializeField] private Mob mob;
    private Pathfinding pathfinding;
    // Start is called before the first frame update
    private void Start()
    {
        pathfinding = new Pathfinding(10, 10);
        // grid = new Grid<bool>(20, 20, 10f, new Vector3(-100, -50), (Grid<bool> g, int x, int y) => false);
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            Grid<PathNode> grid = pathfinding.GetGrid();

            grid.GetXY(touchPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            // Debug.Log("Path From 0,0 to " + x + "," + y);
            // Debug.Log(path.Count);

            // mob.SetTargetPosition(touchPosition);

            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.Log(path[i].ToString());
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * grid.GetCellSize() + Vector3.one * grid.GetCellSize() * .5f + grid.GetOriginPosition(), new Vector3(path[i+1].x, path[i+1].y) * grid.GetCellSize() + Vector3.one * grid.GetCellSize() * .5f + grid.GetOriginPosition(), Color.red, 5f);
                }
            }
            // grid.SetGridObject(touchPosition, true); 
        }
    }
}
