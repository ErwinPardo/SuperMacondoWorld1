using UnityEngine;

public class RewindButtonController : MonoBehaviour
{
    public DirectorController directorController;  // Asignar el DirectorController desde el inspector

    // Detectar cuando se pulsa el botón
    void OnMouseDown()
    {
        // Llama al método de retroceso en el DirectorController
        directorController.RewindToPreviousTutorial();
    }
}
