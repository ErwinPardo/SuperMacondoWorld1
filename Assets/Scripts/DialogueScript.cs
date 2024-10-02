using UnityEngine;
using TMPro;
using System.Collections;

[System.Serializable]
public class DialogueLine
{
    public string text;   // Texto del diálogo
    public float timelinePoint;  // Punto en el Timeline (-1 si no hay animación)
}


public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;   // Texto del diálogo
    public DialogueLine[] lines;           // Arreglo de líneas de diálogo y puntos de Timeline
    public float textSpeed = 0.1f;         // Velocidad del texto
    public DirectorPlay directorController; // Referencia al controlador del Timeline
    public float FinalTime; 

    private int index;                     // Índice del diálogo actual
    private bool dialogueActive = false;   // Si el diálogo está activo

    private void Start()
    {
        gameObject.SetActive(false);
        dialogueText.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && dialogueActive)
        {
            if (dialogueText.text == lines[index].text)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index].text;
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        gameObject.SetActive(true);
        dialogueActive = true;
        StartCoroutine(WriteLine());

        // Controlar el timeline en base a la primera línea
        HandleTimelineForLine(index);
    }

    IEnumerator WriteLine()
    {
        foreach (char letter in lines[index].text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());

            // Controlar el timeline en base a la nueva línea
            HandleTimelineForLine(index);
        }
        else if (index == lines.Length -1)
        {
            gameObject.SetActive(false);
            dialogueActive = false;

            // Detener el Timeline cuando el diálogo termine
            dialogueText.text = string.Empty;
            directorController.PauseDirector();
            directorController.JumpToTime(FinalTime);
        }
    }

    public void SetDialogueState()
    {
        dialogueActive = true;
    }

    // Método para manejar el Timeline dependiendo del diálogo actual
    private void HandleTimelineForLine(int lineIndex)
    {
        if (lineIndex < lines.Length && dialogueActive==true)
        {
            float timelinePoint = lines[lineIndex].timelinePoint;

            if (timelinePoint >= 0)  // Reproducir desde el punto si no es -1 (que significa no animación)
            {
                directorController.JumpToTime(timelinePoint);
            }
            /*else
            {
                // No hacer nada si no hay animación para esta línea
                directorController.PauseDirector();
            }*/
        }
    }
}
