using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject[] panels;  // Array de paneles
    public int currentPanelIndex = 0;  // Índice del panel actual
    public float speed = 5f;  // Velocidad de la animación
    public RectTransform target1, target2;
    private Coroutine currentAnimation;  // Para almacenar la animación en curso
    public Animator[] HandAnimator;


    public void ShowNextPanel()
    {
        if (currentPanelIndex < panels.Length - 1)  // Verifica si hay más paneles
        {
            // Si hay una animación en curso, deténla antes de iniciar la nueva
            if (currentAnimation != null)
            {
                StopCoroutine(currentAnimation);

            }
            
            if(currentPanelIndex > 0 && currentPanelIndex < HandAnimator.Length+1)
            {
                HandAnimator[currentPanelIndex-1].SetInteger("Panel", 0);
            }

            // Calcula la nueva posición objetivo para mover el panel actual hacia arriba
            Vector3 targetPosition = target2.position;  // Ajusta la altura si es necesario

            // Inicia una nueva animación de movimiento
            currentAnimation = StartCoroutine(MovePanel(panels[currentPanelIndex], targetPosition));




            // Cambia al siguiente panel después de iniciar el movimiento del actual
            currentPanelIndex++;


            if (currentPanelIndex < HandAnimator.Length + 1)
            {
                HandAnimator[currentPanelIndex - 1].SetInteger("Panel", currentPanelIndex);
            }

        }
    }

    public void ShowPreviousPanel()
    {
        if (currentPanelIndex > 0)  // Verifica si no estamos en el primer panel
        {
            // Si hay una animación en curso, deténla antes de iniciar la nueva
            if (currentAnimation != null)
            {
                StopCoroutine(currentAnimation);
            }

            if (currentPanelIndex < HandAnimator.Length+1)
            {
                HandAnimator[currentPanelIndex - 1].SetInteger("Panel", 0);
            }

            // Cambia al panel anterior antes de iniciar el movimiento
            currentPanelIndex--;

            // Calcula la nueva posición objetivo para mover el panel anterior hacia abajo
            Vector3 targetPosition = target1.position;  // Ajusta la altura si es necesario

            // Inicia una nueva animación de movimiento
            currentAnimation = StartCoroutine(MovePanel(panels[currentPanelIndex], targetPosition));
            if(currentPanelIndex > 0 && currentPanelIndex < HandAnimator.Length+1)
            {
                HandAnimator[currentPanelIndex-1].SetInteger("Panel", currentPanelIndex);
            }
        }
    }

    private System.Collections.IEnumerator MovePanel(GameObject panel, Vector3 targetPosition)
    {
        while (Vector3.Distance(panel.transform.position, targetPosition) > 0.1f)
        {
            // Mueve el panel hacia la posición objetivo de manera suave desde su posición actual
            panel.transform.position = Vector3.Lerp(panel.transform.position, targetPosition, Time.deltaTime * speed);
            yield return null;  // Espera un frame antes de continuar
        }

        // Ajusta la posición final al destino exacto
        panel.transform.position = targetPosition;

        // Finaliza la animación
        currentAnimation = null;
    }
}