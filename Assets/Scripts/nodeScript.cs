using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public SFXAudioManager sfxAudioManager;
    public DirectorPlay directorController;  // Referencia al script DirectorController
    public int nodoId;  // Identificador �nico para cada nodo
    public NodoController nodoController;  // Referencia al script NodoController para verificar si el jugador est� en este nodo
    public ColliderActivator colliderActivator;

    public AudioClip clickSound;  // Assign the "Click" sound effect in the Inspector

    void OnMouseDown()
    {
        // Play the click sound effect
        sfxAudioManager.PlaySFX(clickSound, 1.0f);  // Play the "Click" sound at full volume
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
