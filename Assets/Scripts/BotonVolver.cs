using UnityEngine;

public class RewindButtonController : MonoBehaviour
{
    public DirectorController directorController;  // Asignar el DirectorController desde el inspector

    // Detectar cuando se pulsa el bot�n
    void OnMouseDown()
    {
        // Llama al m�todo de retroceso en el DirectorController
        directorController.RewindToPreviousTutorial();
    }
}
