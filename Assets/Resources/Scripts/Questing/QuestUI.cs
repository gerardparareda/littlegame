using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public static QuestUI Instance { get; set; }

    public string description;
    public string title;
    public int progress;
    public GameObject questPanel;


    Text descriptionText, titleText, progressText;
    int dialogueIndex;


    void Awake()
    {
        titleText = questPanel.transform.Find("Title").GetComponent<Text>();
        descriptionText = questPanel.transform.Find("Description").GetComponent<Text>();
        progressText = questPanel.transform.Find("Progress").GetComponent<Text>();
        questPanel.SetActive(false);

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
        this.title = title;
        this.description = description;
        CreateQuest();
    }

    public void CreateQuest()
    {
        titleText.text = title;
        descriptionText.text = description;
        questPanel.SetActive(true);
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

