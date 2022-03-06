using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    [SerializeField] List<Component> components = new List<Component>();

    [SerializeField] ComponentHandler componentPref;


    public class OnConnectionAddedArgs : EventArgs
    {
        public int currentConnections;
        public int maxConnections;
    }

    public static event EventHandler<OnConnectionAddedArgs> onConnectionAdded;

    List<ComponentHandler> componentHandlers = new List<ComponentHandler>();
    List<LineHandler> connections = new List<LineHandler>();

    public static ComponentsManager Instance { get; private set; }

    private void Start()
    {
        updateGraphics();

        GameManager.onNewLevel += GameManager_onNewLevel;
    }

    private void GameManager_onNewLevel(object sender, EventArgs e)
    {
        updateGraphics();
    }

    private void updateGraphics()
    {
        onConnectionAdded?.Invoke(this, new OnConnectionAddedArgs { currentConnections = connections.Count, maxConnections = GameManager.Instance.getMaxConnections() });
    }

    public void addConnection(LineHandler connection)
    {
        connections.Add(connection);
        onConnectionAdded?.Invoke(this, new OnConnectionAddedArgs { currentConnections = connections.Count, maxConnections = GameManager.Instance.getMaxConnections()});
    }
    public void removeConnection(LineHandler connection)
    {
        connections.Remove(connection);
    }
    public void deleteConnection(LineHandler connection)
    {
        removeConnection(connection);
        Destroy(connection.gameObject);
    }

    public void deleteAllConnections()
    {
        while (connections.Count > 0)
        {
            deleteConnection(connections[0]);
        }
    }

    public void addComponent(ComponentHandler componentHandler)
    {
        componentHandlers.Add(componentHandler);
    }

    public void removeComponent(ComponentHandler componentHandler)
    {
        componentHandlers.Remove(componentHandler);
    }

    public void deleteComponent(ComponentHandler componentHandler)
    {
        removeComponent(componentHandler);
        Destroy(componentHandler.gameObject);
    }

    public void deleteAllComponents()
    {
        while (componentHandlers.Count > 0)
        {
            deleteComponent(componentHandlers[0]);
        }
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

    public void InstantiateComponent(int id, Vector3 pos)
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

    public ComponentHandler getHub()
    {
        foreach (ComponentHandler handler in componentHandlers)
            if (handler.getType() == "Hub")
                return handler;
        return null;
    }

    private void OnDestroy()
    {
        GameManager.onNewLevel -= GameManager_onNewLevel;
    }
}