using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFPS : MonoBehaviour
{
    public int target = 60;
    public bool enabledLock = false;

    void Awake()
    {  
        if (enabledLock)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = target;
        } else
        {
            QualitySettings.vSyncCount = 2;
            Application.targetFrameRate = -1;
        }
    }

    void Update()
    {
        if (enabledLock)
        {
            QualitySettings.vSyncCount = 0;
            if (Application.targetFrameRate != target)
                Application.targetFrameRate = target;
        } else
        {
            QualitySettings.vSyncCount = 2;
            Application.targetFrameRate = -1;
        }
        
    }
}
