using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private GameObject Target = null;

    private Vector3 TargetPosition;

    void Start()
    {
        if (Target == null)
        {
            Target = Camera.main.gameObject;
        }
    }

    private void LateUpdate()
    {
        if (TargetPosition != Target.transform.position)
        {
            TargetPosition = Target.transform.position;
            transform.LookAt(TargetPosition);
        }
    }
}
