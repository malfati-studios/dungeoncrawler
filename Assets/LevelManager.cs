using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<MapPosition> enemyPositions;

    private WorldGrid grid;
    private MapPosition playerPosInGrid;

    public bool IsValidPosition(MapPosition newPos)
    {
        return grid.CanMove(newPos);
    }
    
    public bool IsThereInteractive(MapPosition newPos)
    {
        return enemyPositions.Find(enemyPos => enemyPos.EqualPos(newPos)) != null;
    }

    private void Start()
    {
        grid = transform.GetChild(0).GetComponent<WorldGrid>();
        playerPosInGrid = grid.GetStartingPosition();
        foreach (var enemyPosition in enemyPositions)
        {
            Instantiate(enemyPrefab, enemyPosition.worldPosition, Quaternion.identity);
        }
    }

    public int GetCellSize()
    {
        return (int) grid.cellSize;
    }
}