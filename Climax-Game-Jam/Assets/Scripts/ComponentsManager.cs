using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    [SerializeField] List<Component> components = new List<Component>();


    [SerializeField] ComponentHandler componentPref;

    List<ComponentHandler> componentHandlers = new List<ComponentHandler>();

    public static ComponentsManager Instance { get; private set; }

    public void addComponent(ComponentHandler componentHandler)
    {
        componentHandlers.Add(componentHandler);
    }

    public void removeComponent(ComponentHandler componentHandler)
    {
        componentHandlers.Remove(componentHandler);

    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public void InstantiateComponent(int id, Vector2 pos)
    {
        ComponentHandler handler = Instantiate(componentPref, pos, Quaternion.identity);

        handler.setComponent(components[id]);
    }

    public Component getComponent(int id)
    {
        return components[id];
    }
    public List<ComponentHandler> getComponents()
    {
        return componentHandlers;
    }
}