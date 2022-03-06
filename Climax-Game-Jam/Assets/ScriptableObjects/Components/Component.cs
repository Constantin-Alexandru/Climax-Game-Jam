using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Component", menuName = "Assets/Component", order = 0)]
public class Component : ScriptableObject
{
    public string type;

    public int id;

    public Sprite sprite;

    public int maxLinks;

    public List<string> possibleLinks;
}
