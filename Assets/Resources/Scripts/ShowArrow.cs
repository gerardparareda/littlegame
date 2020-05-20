using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowArrow : Selectable
{
    // Start is called before the first frame update
    public GameObject arrow;


    void Start()
    {
        //arrow = transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.IsHighlighted())
        {
            //arrow.text = "fsdfs";
            Debug.Log("Highlighted");
            arrow.active = true;
        }
        else
        {
            arrow.active = false;
        }
    }
}
