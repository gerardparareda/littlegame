using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateHandler : MonoBehaviour
{

    public delegate void OnButtonClickDelegate();
    public static OnButtonClickDelegate buttonClickDelegate;

    public void OnButtonClick()
    {
        buttonClickDelegate();
    }

}
