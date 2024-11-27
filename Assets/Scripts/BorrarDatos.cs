using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    // Este m�todo se llamar� al iniciar el juego
    void Start()
    {
        ResetData();
    }

    void ResetData()
    {
        PlayerPrefs.DeleteAll(); // Elimina todos los datos de PlayerPrefs
        PlayerPrefs.Save(); // Aseg�rate de guardar los cambios
        Debug.Log("Todos los PlayerPrefs han sido reiniciados.");
    }
}
