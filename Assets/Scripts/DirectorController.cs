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
        // Si est� en modo bucle y el director est� reproduciendo
        if (isLooping && director.state == PlayState.Playing)
        {
            // Comprobar si se debe reiniciar el loop
            if (director.time >= loopEndTime)
            {
                director.time = loopStartTime;  // Reinicia la timeline al inicio del bucle
                director.Evaluate();             // Eval�a para evitar un salto brusco
            }
        }
    }

    // M�todo que pausa la timeline
    public void PauseTimeline()
    {
        if (director.state == PlayState.Playing)
        {
            director.Evaluate(); // Mantiene el estado actual de los objetos al pausar
            director.Pause();
            isPaused = true;
        }
    }

    // M�todo que reanuda la timeline fuera del bucle
    public void ContinueTimeline()
    {
        if (isPaused || isLooping)
        {
            isPaused = false;
            isLooping = false;  // Salir del modo bucle
            loopCanStart = false; // Resetea la posibilidad de iniciar el bucle
            director.Resume();  // Continuar la cinem�tica normalmente
        }
    }

    // M�todo para comprobar si la timeline est� pausada
    public bool IsPaused()
    {
        return isPaused;
    }

    // M�todo para iniciar el bucle en un fragmento espec�fico
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

    // M�todo para detener el bucle y continuar la cinem�tica
    public void StopLoop()
    {
        isLooping = false;
        loopCanStart = false; // Desactiva la posibilidad de reiniciar el bucle
    }

    // M�todo para permitir iniciar el bucle
    public void AllowLoopStart()
    {
        loopCanStart = true;
    }

    // M�todo para almacenar el tiempo de inicio del bucle usando el tiempo actual del director
    public void SetLoopStart()
    {
        loopStartTime = director.time;  // Captura el tiempo actual de la timeline
        Debug.Log("Loop start time set at: " + loopStartTime);
        AllowLoopStart(); // Permite iniciar el bucle despu�s de establecer el inicio
    }

    // M�todo para almacenar el tiempo de fin del bucle usando el tiempo actual del director
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

        // Busca el loopStartTime m�s reciente que sea menor que el tiempo actual
        foreach (var time in loopStartTimes)
        {
            if (time < director.time)
            {
                previousLoopStart = time;
            }
        }

        // Si hay un loopStartTime anterior v�lido, retrocede el director al mismo
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