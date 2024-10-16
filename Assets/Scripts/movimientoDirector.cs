using UnityEngine;
using UnityEngine.Playables;

public class MovimientoDirector : MonoBehaviour
{
    public PlayableDirector playableDirector;
    private bool isMoving = false;
    private float timeDest;

    private void OnEnable()
    {
        playableDirector.Play();
        playableDirector.Pause();
    }

    private void Update()
    {
        if (isMoving)
        {
            // Verificar si estamos yendo hacia adelante o hacia atrás
            if (playableDirector.time < timeDest)
            {
                // Movimiento hacia adelante
                playableDirector.time += Time.deltaTime;
            }
            else if (playableDirector.time > timeDest)
            {
                // Movimiento hacia atrás
                playableDirector.time -= Time.deltaTime;
            }

            // Pausar cuando llegue al destino
            if (Mathf.Abs((float)playableDirector.time - timeDest) <= 0.1f)
            {
                playableDirector.time = timeDest; // Asegurar que no sobrepase el destino
                playableDirector.Pause();
                isMoving = false; // Detener el movimiento
            }
        }
    }

    // Función para mover el jugador a través del timeline entre dos nodos
    public void MoverJugadorHacia(float tiempoOrigen, float tiempoDestino)
    {
        if (playableDirector != null)
        {
            // Establecer los tiempos de origen y destino
            timeDest = tiempoDestino;
            playableDirector.time = tiempoOrigen;

            if (tiempoOrigen != tiempoDestino)
            {
                isMoving = true; // Iniciar el movimiento
                playableDirector.Play(); // Reanudar el timeline
            }
        }
    }

    public bool getIsMoving() {
        return isMoving;
    }
}
