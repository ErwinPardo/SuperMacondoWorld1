using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public DirectorController directorController;  // Asignar el DirectorController desde el inspector
    private Renderer buttonRenderer;                // Para modificar el color del bot�n
    private Color originalColor;                    // Color original del bot�n
    public float SpeedVelocity = 1.0f;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>(); // Obtiene el Renderer del bot�n
        originalColor = buttonRenderer.material.color; // Guarda el color original
    }

    // Detectar cuando se pulsa el bot�n
    void OnMouseDown()
    {
        // Cambiar el color del bot�n al ser presionado
        buttonRenderer.material.color = originalColor * 0.5f; // Oscurece el color

        if (directorController.loopCanStart == true)
        {
            // Detener el bucle al presionar el bot�n
            directorController.StopLoop();

            // Acelera el timeline al presionar el bot�n
            directorController.SetSpeed(SpeedVelocity); // Establecer velocidad de 2x (ajusta seg�n sea necesario)
        }

        // Comprobar si el director est� pausado
        if (directorController.IsPaused())
        {
            // Si est� pausado, reanudar la timeline
            directorController.ContinueTimeline();
        }
    }

    void OnMouseUp()
    {
        // Restaurar el color original al soltar el bot�n
        buttonRenderer.material.color = originalColor;
    }
}