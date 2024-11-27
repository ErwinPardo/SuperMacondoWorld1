using UnityEngine;
using UnityEngine.Playables;

public class NodeScript : MonoBehaviour
{
    public SFXAudioManager sfxAudioManager;
    public DirectorPlay directorController;  // Referencia al script DirectorController
    public MovimientoDirector MovimientoDirector;
    public int nodoId;  // Identificador �nico para cada nodo
    public NodoController nodoController;  // Referencia al script NodoController para verificar si el jugador est� en este nodo
    public ColliderActivator colliderActivator;
    
    

    public AudioClip clickSound;  // Assign the "Click" sound effect in the Inspector

    void OnMouseDown()
    {
        // Play the click sound effect
          // Play the "Click" sound at full volume
        // Si el jugador est� en este nodo, ejecutamos la acci�n.
        if (nodoController != null && nodoController.nodoActual == nodoId && MovimientoDirector.getIsMoving() == false)
        {
            if (directorController != null)
            {
                colliderActivator.index = nodoId;
                sfxAudioManager.PlaySFX(clickSound, 1.0f);
                directorController.ActivateAndPlayDirector();
                //Debug.Log("El jugador est� en el nodo " + nodoId + " y el timeline deber�a reproducirse.");
                
            }
        }
        // Si el jugador no est� en este nodo, lo movemos hacia �l.
        else if (nodoController != null && MovimientoDirector.getIsMoving() == false)
        {
            sfxAudioManager.PlaySFX(clickSound, 1.0f);
            nodoController.MoverJugador(nodoId); // Movemos el jugador al nodo seleccionado
        }
    }
}
