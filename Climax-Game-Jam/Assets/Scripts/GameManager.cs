using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static bool ghostObj = false;
    public static GameObject handlerPref { get; private set; }

    [SerializeField] GameObject _handler;
    [SerializeField] GameObject _component;
    [SerializeField] GameObject _ghostObj;
    [SerializeField] GameObject _connectionsContainer;

    [SerializeField] LevelHandler _levelHandler;
    [SerializeField] Level[] _levels;

    [SerializeField] int level;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        handlerPref = _handler;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        setLevel(0);
    }

    public void setLevel(int level)
    {
        this.level = level;
        _levelHandler.LoadLevel(_levels[level]);

    }

    public void instantiateGhost(int componentID)
    {
        
        //if (_levelHandler.getComponentsCount(componentID) > 0)
        //{
            Component component = ComponentsManager.Instance.getComponent(componentID);
            Instantiate(_ghostObj, Vector3.zero, Quaternion.identity).GetComponent<ComponentHandler>().setComponent(component);
        //}
    }

    public void subtractCount(int id)
    {
        _levelHandler.subtractCount(id);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
                instantiateGhost(0);    
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
                instantiateGhost(1);    
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
                instantiateGhost(2);
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
                instantiateGhost(3);
        }

    }
}
