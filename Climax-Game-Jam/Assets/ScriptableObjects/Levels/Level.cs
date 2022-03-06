using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Assets/Level", order = 0)]
public class Level : ScriptableObject
{
    public int maxConnections;

    public int[] componentsCount = new int[4];

    public int startConnections;

    [Serializable]
    public class PlacedComponent
    {
        public Vector3 position;
        public int componentId;
    }

    public PlacedComponent[] placedComponents;
}
