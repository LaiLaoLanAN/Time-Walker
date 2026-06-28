using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLayer : MonoBehaviour
{
    public BackGround background;
     public float XMoveRate = 0;
     public float YMoveRate = 0;

    private RectTransform RT;
    [HideInInspector] public Vector2 originPos;
    public float XItMoveSpeed;
    public float YItMoveSpeed;

    public int SortingOrder;
    void Start()
    {
        RT= GetComponent<RectTransform>();
        originPos = RT.anchoredPosition;
        LayerXRepeater layerXRepeater = GetComponent<LayerXRepeater>();
        if (layerXRepeater != null)
        {
            layerXRepeater.SortingOrder = SortingOrder;
        }
    }
    public void UpdatePos(Vector2 MCPosDelta,float elapedTime)
    {
        RT.anchoredPosition = originPos - new Vector2(MCPosDelta.x * XMoveRate, MCPosDelta.y * YMoveRate)+new Vector2(XItMoveSpeed*elapedTime,YItMoveSpeed*elapedTime);
    }
}
