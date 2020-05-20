using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Desectable : MonoBehaviour, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{

    private bool mouseIsOver = false;

    public void GetFocus()
    {
        gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void TakeFocus()
    {
        gameObject.SetActive(false);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        if (!mouseIsOver)
            gameObject.SetActive(!gameObject.activeSelf);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseIsOver = true;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseIsOver = false;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
