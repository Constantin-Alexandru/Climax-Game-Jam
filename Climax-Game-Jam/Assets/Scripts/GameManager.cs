using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static bool ghostObj = false;
    public static GameObject handlerPref { get; private set; }

    [SerializeField] GameObject _handler;
    [SerializeField] GameObject _component;
    [SerializeField] GameObject _ghostObj;

    [SerializeField] Level[] _levels;

    [SerializeField] int level;

    public class OnRunResponseArgs : EventArgs
    {
        public string message;
    }

    public static event EventHandler<OnRunResponseArgs> onRunResponse;
    public static event EventHandler onNewLevel;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        handlerPref = _handler;
    }

    private void Start()
    {
        setLevel(0);
    }

    public void nextLevel()
    {
        level++;

        if (level >= _levels.Length)
            level = _levels.Length - 1;

        setLevel(level);

    }

    public void setLevel(int level)
    {
        this.level = level;

        ComponentsManager.Instance.deleteAllComponents();
        ComponentsManager.Instance.deleteAllConnections();
        onNewLevel?.Invoke(this, EventArgs.Empty);

        LevelHandler.Instance.LoadLevel(_levels[level]);

    }

    public void instantiateGhost(int componentID)
    {
        
        if (LevelHandler.Instance.getComponentsCount(componentID) > 0)
        {
            Component component = ComponentsManager.Instance.getComponent(componentID);
            Instantiate(_ghostObj, Vector3.zero, Quaternion.identity).GetComponent<ComponentHandler>().setComponent(component);
        }
    }

    public void subtractCount(int id)
    {
        LevelHandler.Instance.subtractCount(id);
    }

    private void Update()
    {
        
    }

    public void TestNetwork()
    {
        ComponentHandler hub = ComponentsManager.Instance.getHub();

        List<ComponentHandler> visitedHandlers = new List<ComponentHandler> { hub };

        int index = 0;
        int connections = 0;

        List<ComponentHandler> toVisitHandlers = new List<ComponentHandler> { hub };

        if(hub != null)
        {
            while (index < toVisitHandlers.Count)
            {

                List<ComponentHandler> links = toVisitHandlers[index].getLinks();

                connections += links.Count;

                visitedHandlers.Add(toVisitHandlers[index]);

                foreach (ComponentHandler link in links)
                {
                        if (!toVisitHandlers.Contains(link))
                            toVisitHandlers.Add(link);
                }

                index++;
            }
        }

        if(toVisitHandlers.Count == ComponentsManager.Instance.getComponents().Count)
        {
            if (connections / 2 <= _levels[level].maxConnections)
            {
                if (!LevelHandler.Instance.leftComponents())
                {
                    StartCoroutine(printResponse("CORRECT!"));
                }
                else
                {
                    StartCoroutine(printResponse("Not every component has been used" ));
                }
            }
            else
            {
                StartCoroutine(printResponse("The connections count surpassed the maximum number of connections allowed"));
            }
        }
        else
        {
            StartCoroutine(printResponse("The connections don't reach all devices"));
        }
    }

    public int getMaxConnections()
    {
        return _levels[level].maxConnections;
    }

    IEnumerator printResponse(string message)
    {
        onRunResponse?.Invoke(this, new OnRunResponseArgs { message = message });

        yield return new WaitForSeconds(2);

        onRunResponse?.Invoke(this, new OnRunResponseArgs { message = " " });

    }

    private void OnDestroy()
    {
        Instance = null;
    }

}

