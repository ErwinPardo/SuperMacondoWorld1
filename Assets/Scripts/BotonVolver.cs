/* UnityEngine;

public class ButtonController2 : MonoBehaviour
{
    public DirectorController directorController;
    private Renderer buttonRenderer;
    private Color originalColor;
    public float SpeedVelocity = 1.0f;
    public double[] timeSegments; // Los tiempos que definas manualmente
    private int currentSegmentIndex = 0;
    private int targetSegmentIndex = 0; // Índice actual que es actualizado por el signal

    void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
        originalColor = buttonRenderer.material.color;

        // Ordenar los segmentos de tiempo
        System.Array.Sort(timeSegments);
    }

    void Update()
    {
        // Verificar si la velocidad es negativa y el tiempo actual es mayor que el tiempo objetivo
        if (directorController.GetSpeed() < 0 && directorController.GetCurrentTime() > timeSegments[targetSegmentIndex])
        {
            // Retroceder hasta el tiempo del segmento objetivo
            directorController.SetTime(timeSegments[targetSegmentIndex]);

            // Si el tiempo actual es menor o igual al objetivo, restablecer la velocidad
            if (directorController.GetCurrentTime() <= timeSegments[targetSegmentIndex])
            {
                directorController.SetSpeed(1.0f); // Restablece la velocidad a 1
            }
        }
    }

    void OnMouseDown()
    {
        // Cambiar color al presionar
        buttonRenderer.material.color = originalColor * 0.5f;

        // Detener el bucle si está activo
        if (directorController.loopCanStart)
        {
            directorController.StopLoop();
            directorController.SetSpeed(SpeedVelocity);
        }

        // Si el director está pausado, continuar la timeline
        if (directorController.IsPaused())
        {
            directorController.ContinueTimeline();
        }

        // Ajustar el timeline solo si la velocidad es negativa
        if (directorController.GetSpeed() < 0)
        {
            AdjustTimelineSegment();
        }
    }

    void OnMouseUp()
    {
        // Restaurar el color original al soltar el botón
        buttonRenderer.material.color = originalColor;
    }

    // Llamado por los signals para actualizar la posición del array
    public void UpdateSegmentIndex(int newIndex)
    {
        if (newIndex >= 0 && newIndex < timeSegments.Length)
        {
            targetSegmentIndex = newIndex; // Actualizar el segmento objetivo
        }
    }

    // Ajusta el timeline solo cuando la velocidad es negativa
    void AdjustTimelineSegment()
    {
        double currentTime = directorController.GetCurrentTime();

        // Si la velocidad es negativa y el tiempo actual es mayor al tiempo del segmento objetivo

        if (targetSegmentIndex > 0 && currentTime > timeSegments[targetSegmentIndex])
        {
            // Retroceder al tiempo del segmento objetivo
            directorController.SetTime(timeSegments[targetSegmentIndex]);
        }

        // Mantener la velocidad configurada
        directorController.SetSpeed(SpeedVelocity);
    }
}
*/