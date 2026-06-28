using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform CameraTransform;
    private Vector2 MCOriginPos;
    [HideInInspector]public List<BGLayer> layers=new List<BGLayer>();
    private float StartTime;
    // Start is called before the first frame update
    void Start()
    {
        MCOriginPos = CameraTransform.position;
        StartTime = Time.time;
        foreach(Transform child in transform)
        {
            BGLayer layer = child.GetComponent<BGLayer>();
            if (layer != null)
            {
                layers.Add(layer);
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 MCdelta = (Vector2)CameraTransform.position - MCOriginPos;
        MCdelta = Camera.main.ScreenToWorldPoint(MCdelta) - Camera.main.ScreenToWorldPoint(Vector2.zero);
        foreach (var layer in layers)
        {
            layer.UpdatePos(MCdelta, Time.time - StartTime);
        }
    }
}
