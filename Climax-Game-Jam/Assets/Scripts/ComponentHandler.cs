using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentHandler : MonoBehaviour
{
    [SerializeField] Component _component;
    [SerializeField] Transform _connectionsContainer;

    SpriteRenderer _spriteRenderer;

    List<ComponentHandler> _links = new List<ComponentHandler>();

    private void Start()
    {
        ComponentsManager.Instance.addComponent(this);
       _spriteRenderer = GetComponent<SpriteRenderer>();
       _spriteRenderer.sprite = _component.sprite;
    }

    public int getComponentId()
    {
        return _component.id;
    }

    public void setComponent(Component component)
    {
        _component = component;
    }

    private void OnMouseUp()
    {
        if (GameManager.ghostObj == true)
            return;

        if (_component.maxLinks == _links.Count)
            return;

        if (LineHandler.UnfinishedLink == null)
        {
            Instantiate(GameManager.handlerPref, transform.position, Quaternion.identity, _connectionsContainer).GetComponent<LineHandler>().Add(this);
        }
        else LineHandler.UnfinishedLink.Add(this);
    }

    public bool isCompatible(ComponentHandler handler)
    {
        if (_component.possibleLinks.Contains(handler.getType()) && !_links.Contains(handler))
            return true;
        return false;
    }

    public void addLink(ComponentHandler component)
    {
        _links.Add(component);
    }

    public string getType()
    {
        return _component.type;
    }

    public bool isInside(Vector3 pos)
    {
        Vector3 currentPos = transform.position;


        if (Mathf.Abs(Vector3.Distance(currentPos, pos)) <= 1.5)
        {
            return true;
        }

        return false;
    }
}

