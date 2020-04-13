using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuestUI : MonoBehaviour
{
    public static QuestUI Instance { get; set; }

    public string description;
    public string title;
    public int progress;
    public GameObject questPanel;
    public GameObject questElement;

    Text descriptionText, titleText, progressText;
    int dialogueIndex;


    void Awake()
    {
        //titleText = questPanel.transform.Find("QuestUI").GetChild(0).GetComponent<Text>();
        //descriptionText = questPanel.transform.Find("QuestUI").GetChild(1).GetComponent<Text>();
        //progressText = questPanel.transform.Find("QuestUI").GetComponent<Text>();
        questPanel.SetActive(true);

        //does instance exists?
        if (Instance != null && Instance != this)
        {
            //Destroy(gameObject);
            Instance = this;
        }
        else
        {
            Instance = this;
        }
    }

    public void AddNewQuest(string title, string description)
    {
        GameObject questEl = Instantiate(questElement, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        
        Text titText = questEl.transform.Find("Title").GetComponent<Text>();
        titText.text = title;
        Text descText = questEl.transform.Find("Description").GetComponent<Text>();
        descText.text = description;

        questEl.transform.SetParent(questPanel.transform);
        /*this.title = title;
        this.description = description;*/
        //CreateQuest();
    }

    public void RemoveQuest (string title)
    {
        
        for (int i = 0; i < questPanel.transform.childCount; i++)
        {
            GameObject child = questPanel.transform.GetChild(i).gameObject;

            if (child.transform.Find("Title").GetComponent<Text>().text == title) 
            {
                Destroy(child);
                break;
            }
        }
    }
    public void CreateQuest()
    {
        //titleText.text = title;
        //descriptionText.text = description;
        //questPanel.SetActive(true);
    }

    /*public void ContinueDialogue()
    {
        Debug.Log("entro al dialeg");
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }*/
    
}

