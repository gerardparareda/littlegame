using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance { get; set; }

    public List<string> dialogueLines;
    public string npcName;
    public GameObject dialoguePanel;
    public Image npcImage;

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

  
    void Awake()
    {
        continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        npcImage = dialoguePanel.transform.Find("Image").GetComponent<Image>();
        dialoguePanel.SetActive(false);

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        //does instance exists?
        if (Instance != null && Instance !=this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }
    
    public void AddNewDialogue (string[] lines, string npcName, Sprite npcPicture)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(); 
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        npcImage.sprite = npcPicture;
        CreateDialogue();
    }

    public void CreateDialogue ()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue() 
    {
        Debug.Log("entro al dialeg");
        if(dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }
    }
}
