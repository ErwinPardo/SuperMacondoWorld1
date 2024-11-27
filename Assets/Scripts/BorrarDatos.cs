using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    // Este método se llamará al iniciar el juego
    void Start()
    {
        ResetData();
    }

    void ResetData()
    {
        PlayerPrefs.DeleteAll(); // Elimina todos los datos de PlayerPrefs
        PlayerPrefs.Save(); // Asegúrate de guardar los cambios
        Debug.Log("Todos los PlayerPrefs han sido reiniciados.");
    }
}
