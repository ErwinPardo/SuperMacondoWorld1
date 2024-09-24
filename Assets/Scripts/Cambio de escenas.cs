using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Variable p�blica para arrastrar la escena en el Inspector

    // Funci�n p�blica que cambiar� a la escena definida
    public void ChangeScene(string sceneToLoad)
    {
        // Verifica si la escena no est� vac�a
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // Cambia a la escena que se ha asignado en el Inspector
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No se ha asignado una escena para cargar.");
        }
    }
}
