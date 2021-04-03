using System;
using UnityEngine;

[Serializable]
public class MapPosition
{
    public int x;
    public int z;
    public Vector3 worldPosition;

    public MapPosition()
    {
    }

    public MapPosition(int x, int z, Vector3 worldPosition)
    {
        this.x = x;
        this.z = z;
        this.worldPosition = worldPosition;
    }

    public bool EqualPos(MapPosition other)
    {
        return x == other.x && z == other.z;
    }
}