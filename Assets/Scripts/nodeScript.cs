using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public DirectorPlay directorController;  // Referencia al script DirectorController
    public int nodoId;  // Identificador único para cada nodo
    public NodoController nodoController;  // Referencia al script NodoController para verificar si el jugador está en este nodo
    public ColliderActivator colliderActivator;

    void OnMouseDown()
    {
        // Si el jugador está en este nodo, ejecutamos la acción.
        if (nodoController != null && nodoController.nodoActual == nodoId)
        {
            if (directorController != null)
            {
                directorController.ActivateAndPlayDirector();
                //Debug.Log("El jugador está en el nodo " + nodoId + " y el timeline debería reproducirse.");
                colliderActivator.AddCount(nodoId);
            }
        }
        // Si el jugador no está en este nodo, lo movemos hacia él.
        else if (nodoController != null)
        {
           
            nodoController.MoverJugador(nodoId); // Movemos el jugador al nodo seleccionado
        }
    }
}
