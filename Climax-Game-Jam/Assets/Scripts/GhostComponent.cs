using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostComponent : MonoBehaviour
{
    int id;

    private void Start()
    {
        GameManager.ghostObj = true;

        ComponentHandler componentHandler = gameObject.GetComponent<ComponentHandler>();
        id = componentHandler.getComponentId();

        ComponentsManager.Instance.removeComponent(componentHandler);

    }

    private void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;

        transform.position = pos;

        if (Input.GetMouseButtonUp(0))
        {
            List<ComponentHandler> compList = ComponentsManager.Instance.getComponents();

            for (int i = 0; i < compList.Count; i++)
            {
                if (compList[i].isInside(pos))
                    return;
            }
            ComponentsManager.Instance.InstantiateComponent(id, pos);
            GameManager.Instance.subtractCount(id);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.ghostObj=false;
    }
}
