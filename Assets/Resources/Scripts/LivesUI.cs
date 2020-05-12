using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUI : MonoBehaviour
{

    public static LivesUI Instance { get; set; }

    public GameObject heartPanel;
    public GameObject heart;
    // Start is called before the first frame update

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void AddHeart()
    {
        GameObject cor = Instantiate(heart, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        cor.transform.SetParent(heartPanel.transform);
        /*this.title = title;
        this.description = description;*/
        //CreateQuest();
    }

    public void RemoveHeart()
    {
        GameObject child = heartPanel.transform.GetChild(0).gameObject;
        Destroy(child);

    }
    // Update is called once per frame
   
}
