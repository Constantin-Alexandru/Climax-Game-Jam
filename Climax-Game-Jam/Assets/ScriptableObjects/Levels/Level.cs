using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Assets/Level", order = 0)]
public class Level : ScriptableObject
{
    public int maxConnections;

    public int[] componentsCount = new int[4];

    public int startConnections;
}
