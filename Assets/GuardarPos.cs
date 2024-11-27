using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public LobbyControlNodos ControlNodos; // Referencia al script LobbyControlNodos
    public PlayableDirector timeline; // Asigna el timeline desde el inspector o por código
    private string saveTimeKey = "TimelinePosition"; // Clave para guardar la posición del timeline
    private string saveNodeKey = "CurrentNode";      // Clave para guardar el nodo actual

    void Start()
    {
        // Al iniciar, verifica si hay una posición guardada
        if (PlayerPrefs.HasKey(saveTimeKey) && PlayerPrefs.HasKey(saveNodeKey))
        {
            Invoke(nameof(CargarTime), 0.1f);
        }
    }

    public void SaveTimelinePosition()
    {
        if (timeline != null && ControlNodos != null)
        {
            Debug.Log("Guardando nodo " + ControlNodos.nodoActual + " con tiempo " + (float)timeline.time);

            // Guarda la posición actual del timeline
            PlayerPrefs.SetFloat(saveTimeKey, (float)timeline.time);

            // Guarda el nodo actual
            PlayerPrefs.SetInt(saveNodeKey, ControlNodos.nodoActual);

            PlayerPrefs.Save();
        }
    }

    private void CargarTime()
    {
        if (timeline != null && ControlNodos != null)
        {
            // Cargar el tiempo guardado
            float savedTime = PlayerPrefs.GetFloat(saveTimeKey);
            timeline.time = savedTime; // Posiciona el timeline
            timeline.Play();           // Reproduce el timeline

            Debug.Log("Reproduciendo desde el tiempo " + savedTime);

            // Pausa el timeline después de un pequeño retraso
            StartCoroutine(PausarTimeline());

            // Cargar el nodo guardado
            int savedNode = PlayerPrefs.GetInt(saveNodeKey);
            ControlNodos.nodoActual = savedNode;

            Debug.Log("Cargando nodo " + savedNode);
        }
    }

    private System.Collections.IEnumerator PausarTimeline()
    {
        yield return null; // Espera un frame
        timeline.Pause();
        Debug.Log("Timeline pausado.");
    }

}
