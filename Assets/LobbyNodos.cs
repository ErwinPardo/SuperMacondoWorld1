using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using static Unity.Collections.AllocatorManager;

public class LobbyNodos : MonoBehaviour
{
    public SFXAudioManager sfxAudioManager;
    public GameObject DirectorSalida;
    public MovimientoDirector MovimientoDirector;
    public int nodoId;  // Identificador �nico para cada nodo
    public LobbyControlNodos LobbyControlNodos;  // Referencia al script NodoController para verificar si el jugador est� en este nodo
    public ColliderActivator colliderActivator;

    public AudioClip clickSound;  // Assign the "Click" sound effect in the Inspector

    void OnMouseDown()
    {
        // Play the click sound effect

        // Si el jugador est� en este nodo, ejecutamos la acci�n.
        if (LobbyControlNodos != null && LobbyControlNodos.nodoActual == nodoId && MovimientoDirector.getIsMoving() == false)
        {
            sfxAudioManager.PlaySFX(clickSound, 1.0f);  // Play the "Click" sound at full volume
            DirectorSalida.SetActive(true);
            Invoke(nameof(ChangeScence), 2f);
        }
        // Si el jugador no est� en este nodo, lo movemos hacia �l.
        else if (LobbyControlNodos != null && MovimientoDirector.getIsMoving() == false)
        {
            sfxAudioManager.PlaySFX(clickSound, 1.0f);  // Play the "Click" sound at full volume
            LobbyControlNodos.MoverJugador(nodoId); // Movemos el jugador al nodo seleccionado
        }
    }

    public void ChangeScence()
    {
        SceneManager.LoadScene(nodoId.ToString());
    }
}