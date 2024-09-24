using UnityEngine;
using TMPro;
using System.ComponentModel;
using System.Collections;
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class DialogueScript : MonoBehaviour 
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float textSpeed = 0.1f;
    int index;
    bool dialogueActive = false;
    public DirectorController directorController;


    private void Start()
    {
        dialogueText.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogueActive == true)
        {
            if(dialogueText.text == lines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        }
    }

    public void startDialogue()
    {
        index= 0;

        StartCoroutine(WriteLine());
    }


    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
            dialogueActive = false;
            directorController.StopLoop();
        }
    }

    public void SetDialogueState()
    {
        dialogueActive= true;
    }

}
