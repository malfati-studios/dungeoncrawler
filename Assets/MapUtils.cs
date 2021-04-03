using UnityEngine;

namespace DefaultNamespace
{
    public static class MapUtils
    {
        public static Vector3 CalculateWorldPosition(int x, int z, int cellSize)
        {
            int lbx = x * cellSize;
            int rbx = x * cellSize + cellSize;
            
            int lbz = z * cellSize;
            int rbz = z * cellSize + cellSize;
            
            return new Vector3((lbx + rbx) / 2,0, (lbz + rbz) / 2);
        }
    }
}