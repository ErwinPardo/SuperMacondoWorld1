using UnityEngine;
using UnityEngine.UI;  // Necesario para interactuar con componentes de UI
using UnityEngine.Playables;  // Para usar se�ales en el Timeline

public class BotonVolver : MonoBehaviour
{
    private Button boton;  // Variable para almacenar el componente Button

    // Start se ejecuta una vez antes de que el Update comience a ejecutarse
    private void Start()
    {
        // Obtiene el componente Button al inicio
        boton = GetComponent<Button>();
        gameObject.SetActive(false);
        // Desactiva el bot�n inicialmente
        boton.enabled = false;
    }

    // Esta funci�n se puede usar para alternar el estado del bot�n
    public void ToggleButton()
    {
        // Alterna la propiedad "enabled" del bot�n para activarlo/desactivarlo
        boton.enabled = !boton.enabled;
    }
}