using UnityEngine;
using UnityEngine.UI;

public class BotonCerrarJuego : MonoBehaviour
{
    // Este m�todo ser� llamado cuando el bot�n sea presionado
    public void CerrarJuego()
    {
        Debug.Log("Juego cerrado.");
        Application.Quit(); // Cierra la aplicaci�n

        // Para editor de Unity (solo funcionar� dentro del editor de Unity)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}