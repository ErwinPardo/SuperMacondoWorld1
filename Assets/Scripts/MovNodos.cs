using UnityEngine;
using UnityEngine.Playables;
using System.Collections.Generic;

public class NodoController : MonoBehaviour
{
    public PlayableDirector playableDirector;  // Director que controlará las animaciones
    public int nodoActual = 1;  // Nodo donde está actualmente el jugador (Empieza en Nodo 1)
    public MovimientoDirector movimientoDirector;  // Referencia al script MovimientoDirector para controlar el timeline

    // Lista dinámica de tiempos para cada nodo, asignable desde el inspector de Unity
    public float[] tiempos;

    // Esta función será llamada cuando se haga clic en un nodo
    public void MoverJugador(int nodoDestino)
    {
        if (tiempos[nodoActual] == tiempos[nodoDestino])
        {
            EjecutarAccionEnNodo(nodoDestino);  // Si el jugador ya está en el nodo
        }
        else
        {
            if (nodoDestino < tiempos.Length && nodoDestino>-1)
            {

                movimientoDirector.MoverJugadorHacia(tiempos[nodoActual], tiempos[nodoDestino]);
                

                nodoActual = nodoDestino;  // Actualiza la posición del jugador al nodo destino
            }

            
        }
    }

    

    private void EjecutarAccionEnNodo(int nodo)
    {
       // Debug.Log("Jugador ya está en el nodo " + nodo + ". Ejecutando acción.");
    }
}
