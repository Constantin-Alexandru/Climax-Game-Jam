using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineHandler : MonoBehaviour
{
    public static LineHandler UnfinishedLink { get; private set; }

    [SerializeField] LineRenderer _lineRenderer;

    ComponentHandler _end1 = null, _end2 = null;

    

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        UnfinishedLink = this;
    }

    private void Update()
    {
        if(_end1 != null && _end2 == null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector3[] pos = { _end1.transform.position, mousePos};

            _lineRenderer.SetPositions(pos);
        }

        if(Input.GetMouseButtonUp(1) && _end2 == null)
        {
            Destroy(gameObject);
        }
    }

    public void Add(ComponentHandler handler)
    {
       
        if(_end1 == null)
        {
            _end1 = handler;
        }
        else {
            if(_end1.isCompatible(handler))
            {
                UnfinishedLink = null;
                _end2 = handler;

                Vector3[] pos = { _end1.transform.position, _end2.transform.position };

                _lineRenderer.SetPositions(pos);
                _end1.addLink(_end2);
                _end2.addLink(_end1);
                Destroy(this);
            }
            else Destroy(gameObject);
        }
    }

    
}
