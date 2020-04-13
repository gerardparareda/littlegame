using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfActiveQuest = 0;

    #region Singleton
    public static QuestCounter instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory instance! Error");
            return;
        }
        instance = this;
    }
    #endregion
}
