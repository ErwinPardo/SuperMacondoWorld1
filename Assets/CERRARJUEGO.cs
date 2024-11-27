using UnityEngine;
using UnityEngine.UI;

public class BotonCerrarJuego : MonoBehaviour
{
    // Este método será llamado cuando el botón sea presionado
    public void CerrarJuego()
    {
        Debug.Log("Juego cerrado.");
        Application.Quit(); // Cierra la aplicación

        // Para editor de Unity (solo funcionará dentro del editor de Unity)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}