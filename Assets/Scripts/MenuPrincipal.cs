using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject[] panels;  // Array de paneles
    public int currentPanelIndex = 0;  // �ndice del panel actual
    public float speed = 5f;  // Velocidad de la animaci�n
    public RectTransform target1, target2;
    private Coroutine currentAnimation;  // Para almacenar la animaci�n en curso
    public Animator[] HandAnimator;


    public void ShowNextPanel()
    {
        if (currentPanelIndex < panels.Length - 1)  // Verifica si hay m�s paneles
        {
            // Si hay una animaci�n en curso, det�nla antes de iniciar la nueva
            if (currentAnimation != null)
            {
                StopCoroutine(currentAnimation);

            }
            
            if(currentPanelIndex > 0 && currentPanelIndex < HandAnimator.Length+1)
            {
                HandAnimator[currentPanelIndex-1].SetInteger("Panel", 0);
            }

            // Calcula la nueva posici�n objetivo para mover el panel actual hacia arriba
            Vector3 targetPosition = target2.position;  // Ajusta la altura si es necesario

            // Inicia una nueva animaci�n de movimiento
            currentAnimation = StartCoroutine(MovePanel(panels[currentPanelIndex], targetPosition));




            // Cambia al siguiente panel despu�s de iniciar el movimiento del actual
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
            // Si hay una animaci�n en curso, det�nla antes de iniciar la nueva
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

            // Calcula la nueva posici�n objetivo para mover el panel anterior hacia abajo
            Vector3 targetPosition = target1.position;  // Ajusta la altura si es necesario

            // Inicia una nueva animaci�n de movimiento
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
            // Mueve el panel hacia la posici�n objetivo de manera suave desde su posici�n actual
            panel.transform.position = Vector3.Lerp(panel.transform.position, targetPosition, Time.deltaTime * speed);
            yield return null;  // Espera un frame antes de continuar
        }

        // Ajusta la posici�n final al destino exacto
        panel.transform.position = targetPosition;

        // Finaliza la animaci�n
        currentAnimation = null;
    }
}