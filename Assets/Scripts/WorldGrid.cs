using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    public static WorldGrid instance;
    [SerializeField] private List<MapPosition> validMapPositions;
    private GridXZ<GridObject> grid;
    public int gridWidth;
    public int gridHeight;
    public float cellSize;

    void Start()
    {
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, transform.position,
            (g, i, arg3) => new GridObject(g, i, arg3));
        instance = this;
        foreach (var mapPosition in validMapPositions)
        {
            mapPosition.worldPosition = MapUtils.CalculateWorldPosition(mapPosition.x, mapPosition.z, (int) cellSize);
        }
    }

    public MapPosition GetStartingPosition()
    {
        return new MapPosition(0, 0, new Vector3(cellSize / 2, 1.20f, cellSize / 2));
    }

    public class GridObject
    {
        private int x;
        private int z;

        public GridObject(GridXZ<GridObject> gridXz, int i, int arg3)
        {
            this.x = i;
            this.z = arg3;
        }

        public override string ToString()
        {
            return x + ", " + z;
        }
    }


    public bool CanMove(MapPosition newPos)
    {
        if (newPos.x < 0 || newPos.z < 0 || newPos.x > grid.GetWidth() || newPos.z > grid.GetHeight())
        {
            return false;
        }

        return validMapPositions.Find(position => position.EqualPos(newPos)) != null;
    }
}