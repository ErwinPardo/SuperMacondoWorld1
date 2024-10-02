using UnityEngine;
using UnityEngine.Playables;

public class DirectorPlay : MonoBehaviour
{
    public PlayableDirector secondDirector;  // Referencia al segundo PlayableDirector
    private bool isPaused = false;  // Estado para saber si está en pausa o no

    private void Start()
    {
        secondDirector.gameObject.SetActive(false);  // Desactivar el objeto al inicio
    }

    // Método para activar y reproducir el segundo PlayableDirector
    public void ActivateAndPlayDirector()
    {
        if (secondDirector != null)
        {
            secondDirector.gameObject.SetActive(true);  // Activar el objeto del director

            if (!isPaused)
            {
                secondDirector.time = 0;
                //Debug.Log("Reproduciendo el segundo Timeline desde el principio.");
            }
            else
            {
                //Debug.Log("Reanudando el segundo Timeline desde donde se pausó.");
            }

            secondDirector.Play();
            isPaused = false;
        }
        else
        {
            //Debug.LogWarning("El segundo PlayableDirector no está asignado.");
        }
    }

    // Método para pausar el PlayableDirector (esto será llamado por el Signal)
    public void PauseDirector()
    {
        if (secondDirector != null && secondDirector.state == PlayState.Playing)
        {
            secondDirector.Pause();
            isPaused = true;
            //Debug.Log("Timeline pausado por Signal.");
        }
    }

    // Método para saltar a un punto específico en el Timeline
    public void JumpToTime(float time)
    {
        if (secondDirector != null)
        {
            secondDirector.time = time;
            secondDirector.Play();
            isPaused = false;
            //Debug.Log("Saltando al tiempo: " + time + " en el segundo Timeline.");
        }
    }
}
