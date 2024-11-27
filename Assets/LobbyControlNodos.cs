using UnityEngine;
using UnityEngine.Playables;
using System.Collections.Generic;

public class LobbyControlNodos : MonoBehaviour
{
    public PlayableDirector playableDirector;  // Director que controlar� las animaciones
    public int nodoActual = 1;  // Nodo donde est� actualmente el jugador (Empieza en Nodo 1)
    public MovimientoDirector movimientoDirector;  // Referencia al script MovimientoDirector para controlar el timeline

    // Lista din�mica de tiempos para cada nodo, asignable desde el inspector de Unity
    public float[] tiempos;

    // Esta funci�n ser� llamada cuando se haga clic en un nodo
    public void MoverJugador(int nodoDestino)
    {
        if (tiempos[nodoActual] == tiempos[nodoDestino])
        {
            EjecutarAccionEnNodo(nodoDestino);  // Si el jugador ya est� en el nodo
        }
        else
        {
            if (nodoDestino < tiempos.Length && nodoDestino > -1)
            {

                movimientoDirector.MoverJugadorHacia(tiempos[nodoActual], tiempos[nodoDestino]);


                nodoActual = nodoDestino;  // Actualiza la posici�n del jugador al nodo destino
            }


        }
    }



    private void EjecutarAccionEnNodo(int nodo)
    {
        // Debug.Log("Jugador ya est� en el nodo " + nodo + ". Ejecutando acci�n.");
    }
}