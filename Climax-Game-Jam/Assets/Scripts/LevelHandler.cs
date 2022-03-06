using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instance { get; private set; }

    private Level currentLevel;

    private int currentConnections;

    private int[] componentsCount = new int[4];

    public static event EventHandler<OnCountChangeArgs> onCountChange;
   
    public class OnCountChangeArgs: EventArgs
    {
        public int id;
        public int count;
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(this);
    }

    public void LoadLevel(Level level)
    {
        currentLevel = level;

        currentConnections = level.startConnections;

        for(int i = 0; i < level.componentsCount.Length; i++)
        {
            updateCount(i, level.componentsCount[i]);
        }

        for (int i = 0; i < level.placedComponents.Length; i++)
        {
            int componentID = level.placedComponents[i].componentId;
            Vector3 pos = level.placedComponents[i].position;

            ComponentsManager.Instance.InstantiateComponent(componentID, pos);
        }
    }

    public void updateCount(int id, int count)
    {
        componentsCount[id] = count;
        onCountChange?.Invoke(this, new OnCountChangeArgs { id = id, count = count }) ;
    }

    public void subtractCount(int id)
    {
        updateCount(id, componentsCount[id] - 1);
    }

    public int getComponentsCount(int id)
    {
        return componentsCount[id];
    }

    public bool leftComponents()
    {
        for(int i = 0; i < componentsCount.Length; i++)
            if(componentsCount[i] != 0)
            {
                return true;
            }

        return false;
    }

}
