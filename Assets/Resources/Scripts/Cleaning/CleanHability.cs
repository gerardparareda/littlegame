using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanHability : MonoBehaviour
{
    public int maxCleanedObjects;
    public int cleanedObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clean()
    {
        cleanedObjects++;
    }

    public void restoreHability()
    {
        cleanedObjects = 0;
    }

    public bool canClean()
    {
        return cleanedObjects < maxCleanedObjects;
    }
}
