using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LayerXRepeater : MonoBehaviour
{
    [Header("随机")]
    const int RandomRepeatMaxNum = 100;

    public float XRepeatOffset;

    public GameObject RepeatedLayerPre;

    [HideInInspector]public int SortingOrder;
    [Range(0f, 1f)] public float LayerAlpha;
    void Start()
    {
        for(int i = 0; i < RandomRepeatMaxNum; i++)
        {
            GameObject clone = Instantiate(RepeatedLayerPre, transform);
            clone.GetComponent<RectTransform>().anchoredPosition = new Vector2(i * 2560, 0);
        }
    }
}
