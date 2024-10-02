using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public DirectorPlay directorController;  // Referencia al script DirectorController
    public int nodoId;  // Identificador �nico para cada nodo
    public NodoController nodoController;  // Referencia al script NodoController para verificar si el jugador est� en este nodo
    public ColliderActivator colliderActivator;

    void OnMouseDown()
    {
        // Si el jugador est� en este nodo, ejecutamos la acci�n.
        if (nodoController != null && nodoController.nodoActual == nodoId)
        {
            if (directorController != null)
            {
                directorController.ActivateAndPlayDirector();
                //Debug.Log("El jugador est� en el nodo " + nodoId + " y el timeline deber�a reproducirse.");
                colliderActivator.AddCount(nodoId);
            }
        }
        // Si el jugador no est� en este nodo, lo movemos hacia �l.
        else if (nodoController != null)
        {
           
            nodoController.MoverJugador(nodoId); // Movemos el jugador al nodo seleccionado
        }
    }
}
