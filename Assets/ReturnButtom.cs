using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class ButtonActionController : MonoBehaviour
{
    // Variables públicas para configuración
    public GameObject directorSalida;
    public double[] StopTimes; // Tiempo específico para reproducir el PlayableDirector
    public PlayableDirector[] directorPlays = null;
    public NodoController NodoController;

    // Variable que define el estado actual
    public string estado = "idl"; // Puede ser "idl", "nodo" o "descanso"

    

    // Método para manejar el botón
    public void OnButtonPressed()
    {
        Debug.Log(estado.ToLower());
        switch (estado.ToLower())
        {
            case "idl":
                CambiarEscena();
                break;

            case "nodo":
                ReproducirPlayableDirector();
                break;

            default:
                Debug.LogWarning("Estado no reconocido: " + estado);
                break;
        }
    }

    // Cambia la escena a la escena llamada "0"
    private void CambiarEscena()
    {
        directorSalida.SetActive(true);
    }



    // Reproduce el PlayableDirector en un tiempo específico
    private void ReproducirPlayableDirector()
    {
        if (directorPlays != null)
        {
            directorPlays[NodoController.nodoActual].Pause();
            directorPlays[NodoController.nodoActual].time = StopTimes[NodoController.nodoActual];
            directorPlays[NodoController.nodoActual].Play();
        }
        else
        {
            Debug.LogError("No se ha asignado un PlayableDirector para la acción 'descanso'.");
        }
    }


    public void setEstado(string NewState)
    {
        estado = NewState;
    }

}

