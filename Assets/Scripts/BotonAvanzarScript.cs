using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public DirectorController directorController;  // Asignar el DirectorController desde el inspector
    private Renderer buttonRenderer;                // Para modificar el color del botón
    private Color originalColor;                    // Color original del botón
    public float SpeedVelocity = 1.0f;

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>(); // Obtiene el Renderer del botón
        originalColor = buttonRenderer.material.color; // Guarda el color original
    }

    // Detectar cuando se pulsa el botón
    void OnMouseDown()
    {
        // Cambiar el color del botón al ser presionado
        buttonRenderer.material.color = originalColor * 0.5f; // Oscurece el color

        if (directorController.loopCanStart == true)
        {
            // Detener el bucle al presionar el botón
            directorController.StopLoop();

            // Acelera el timeline al presionar el botón
            directorController.SetSpeed(SpeedVelocity); // Establecer velocidad de 2x (ajusta según sea necesario)
        }

        // Comprobar si el director está pausado
        if (directorController.IsPaused())
        {
            // Si está pausado, reanudar la timeline
            directorController.ContinueTimeline();
        }
    }

    void OnMouseUp()
    {
        // Restaurar el color original al soltar el botón
        buttonRenderer.material.color = originalColor;
    }
}