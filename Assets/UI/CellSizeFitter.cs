using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellSizeFitter : MonoBehaviour
{

    GridLayoutGroup grid;
    public float ratio;
    float value;

    void Start()
    {
        ratio = 20;
        grid = GetComponent<GridLayoutGroup>();
        grid.cellSize.Set(10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        value = (gameObject.GetComponent<RectTransform>().sizeDelta.x / gameObject.GetComponent<RectTransform>().sizeDelta.y) * ratio;
        //grid.cellSize.Set(value, value);
    }
}
