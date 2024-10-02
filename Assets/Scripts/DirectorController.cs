using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class DirectorController : MonoBehaviour
{
    public PlayableDirector director;
    private bool isPaused = false;
    private double loopStartTime = 0.0;
    private double loopEndTime = 5.0;
    private bool isLooping = false;
    public bool loopCanStart = false;

    private List<double> loopStartTimes = new List<double>(); // Lista para almacenar los tiempos de inicio de los loops

    void Start()
    {
        director.Play();
    }


    void Update()
    {
        // Si está en modo bucle y el director está reproduciendo
        if (isLooping && director.state == PlayState.Playing)
        {
            // Comprobar si se debe reiniciar el loop
            if (director.time >= loopEndTime)
            {
                director.time = loopStartTime;  // Reinicia la timeline al inicio del bucle
                director.Evaluate();             // Evalúa para evitar un salto brusco
            }
        }
    }

    // Método que pausa la timeline
    public void PauseTimeline()
    {
        if (director.state == PlayState.Playing)
        {
            director.Evaluate(); // Mantiene el estado actual de los objetos al pausar
            director.Pause();
            isPaused = true;
        }
    }

    // Método que reanuda la timeline fuera del bucle
    public void ContinueTimeline()
    {
        if (isPaused || isLooping)
        {
            isPaused = false;
            isLooping = false;  // Salir del modo bucle
            loopCanStart = false; // Resetea la posibilidad de iniciar el bucle
            director.Resume();  // Continuar la cinemática normalmente
        }
    }

    // Método para comprobar si la timeline está pausada
    public bool IsPaused()
    {
        return isPaused;
    }

    // Método para iniciar el bucle en un fragmento específico
    public void StartLoop()
    {
        if (loopCanStart)
        {
            loopStartTimes.Add(loopStartTime); // Guarda el tiempo de inicio actual en la lista
            isLooping = true;
            director.time = loopStartTime;
            director.Play();
        }
    }

    // Método para detener el bucle y continuar la cinemática
    public void StopLoop()
    {
        isLooping = false;
        loopCanStart = false; // Desactiva la posibilidad de reiniciar el bucle
    }

    // Método para permitir iniciar el bucle
    public void AllowLoopStart()
    {
        loopCanStart = true;
    }

    // Método para almacenar el tiempo de inicio del bucle usando el tiempo actual del director
    public void SetLoopStart()
    {
        loopStartTime = director.time;  // Captura el tiempo actual de la timeline
        Debug.Log("Loop start time set at: " + loopStartTime);
        AllowLoopStart(); // Permite iniciar el bucle después de establecer el inicio
    }

    // Método para almacenar el tiempo de fin del bucle usando el tiempo actual del director
    public void SetLoopEnd()
    {
        loopEndTime = director.time;  // Captura el tiempo actual
        Debug.Log("Loop end time set at: " + loopEndTime);
    }

    public void SetSpeed(float speed)
    {
        director.playableGraph.GetRootPlayable(0).SetSpeed(speed);
    }

    public void RewindToPreviousTutorial()
    {
        double previousLoopStart = -1;

        // Busca el loopStartTime más reciente que sea menor que el tiempo actual
        foreach (var time in loopStartTimes)
        {
            if (time < director.time)
            {
                previousLoopStart = time;
            }
        }

        // Si hay un loopStartTime anterior válido, retrocede el director al mismo
        if (previousLoopStart != -1)
        {
            director.time = previousLoopStart;
            director.Evaluate();
        }
    }


    public double GetCurrentTime()
    {
        return director.time;  // Retorna el tiempo actual del Timeline
    }

}