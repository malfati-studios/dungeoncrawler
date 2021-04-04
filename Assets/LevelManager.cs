using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<MapPosition> enemyPositions;
    [SerializeField] private List<Tuple<MapPosition, Enemy>> aliveEnemies;

    private WorldGrid _grid;

    public bool IsValidPosition(MapPosition newPos)
    {
        return _grid.CanMove(newPos);
    }
    
    public bool IsThereEnemy(MapPosition newPos)
    {
        return enemyPositions.Find(enemyPos => enemyPos.EqualPos(newPos)) != null;
    }

    private void Start()
    {
        _grid = transform.GetChild(0).GetComponent<WorldGrid>();
        aliveEnemies = new List<Tuple<MapPosition, Enemy>>();
        foreach (var enemyPosition in enemyPositions)
        {
           Enemy enemy = Instantiate(enemyPrefab, enemyPosition.worldPosition, Quaternion.identity).GetComponent<Enemy>();
           aliveEnemies.Add(new Tuple<MapPosition, Enemy>(enemyPosition, enemy));
        }
    }

    public int GetCellSize()
    {
        return (int) _grid.cellSize;
    }

    public void EngageInCombat(MapPosition pos)
    {
        GameManager.instance.StartBattle(aliveEnemies.Find(tuple => tuple.Item1.x == pos.x && tuple.Item1.z == pos.z).Item2);
    }
}